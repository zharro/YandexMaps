namespace YandexMaps
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml;

    public sealed class GeoCoder
    {
        private const string GeoCodeUrl = "http://geocode-maps.yandex.ru/1.x/?geocode=";
        private const string StaticMapsUrl = "http://static-maps.yandex.ru/1.x";

        /// <summary>
        /// Возвращает список гео-объектов, расположенных в заданном местоположении
        /// </summary>
        /// <param name="location">Метоположение, может определяться адресом, либо координатами</param>
        /// <returns>Ответ, содержащий общее число найденных объектов и 10 первых из них</returns>
        public GeoCoderResponse SearchObjectsInLocation(string location)
        {
            if (String.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException("Пустая строка", "location");
            }
            var request = (HttpWebRequest)WebRequest.Create(GeoCodeUrl + location);
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        throw new YandexMapsApiException("Ответ геокодера содержит пустой поток");
                    }
                    int countOfFoundObjects;
                    var geoObjects = ParseGeoResponse(responseStream, out countOfFoundObjects);
                    return new GeoCoderResponse(countOfFoundObjects, geoObjects);
                }
            }
        }

        /// <summary>
        /// Возвращает изображение карты города с нанесенными метками
        /// </summary>
        /// <param name="locality">Название населенного пункта</param>
        /// <param name="size">Размер карты</param>
        /// <param name="zoom">Zoom карты</param>
        /// <param name="geoObjects">Метки</param>
        /// <returns>Изображение карты города с нанесенными метками</returns>
        public Image GetImageForObjects(
            string locality,
            Size size, 
            int zoom, 
            IDictionary<GeoObject, LabelColor> geoObjects)
        {
            if (string.IsNullOrWhiteSpace(locality))
            {
                throw new ArgumentException("Пустая строка", "locality");
            }
            if (size.Width < 0 || size.Width > 650 ||
                size.Height < 0 || size.Height > 450)
            {
                throw new ArgumentException("Максимальное значение параметра: 650x450 пикселей", "size");
            }
            if (zoom < 0 || zoom > 17)
            {
                throw new ArgumentException("Значение параметра должно быть в пределах от 0 до 17", "zoom");
            }
            if (geoObjects.Count > 100)
            {
                throw new ArgumentException("Максимальное число меток на карте: 100", "geoObjects");
            }
            var labelSize = geoObjects.Count > 20 ? "m" : "l";
            // Загрузим координаты центра города, будем использовать их как центр создаваемой карты
            var center = SearchObjectsInLocation(locality);
            var url = string.Format(
                "{0}/?ll={1}&size={2}&z={3}&l=map&pt=",
                StaticMapsUrl,
                center.GeoObjects.First().Coordinates,
                string.Format("{0},{1}", size.Width, size.Height),
                zoom);
            foreach (var geoObject in geoObjects)
            {
                url += string.Format(
                    "{0},pm2{1}{2}~", 
                    geoObject.Key.Coordinates, 
                    geoObject.Value.GetDescription(),
                    labelSize);
            }
            url = url.Remove(url.Length - 1);
            var request = (HttpWebRequest)WebRequest.Create(url);
            Image resultImage;
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        throw new YandexMapsApiException("Ответ геокодера содержит пустой поток");
                    }
                    resultImage = Image.FromStream(responseStream);
                }
            }
            return resultImage;
        }

        /// <summary>
        /// Парсит XML ответ геокодера
        /// </summary>
        /// <param name="responseStream">Поток ответа геокодера</param>
        /// <param name="countOfFoundObjects">Количество найденных гео-объектов</param>
        /// <returns>Гео-объекты, возвращенные геокодером</returns>
        private static IEnumerable<GeoObject> ParseGeoResponse(Stream responseStream, out int countOfFoundObjects)
        {
            var doc = new XmlDocument();
            doc.Load(responseStream);
            // Получить общее число найденых объектов
            var foundNode = doc.GetElementsByTagName("found")[0];
            countOfFoundObjects = Int32.Parse(foundNode.InnerText);
            // Получить список найденых объектов
            var geoNodes = doc.GetElementsByTagName("featureMember");
            var foundGeoObjects = new List<GeoObject>();
            foreach (XmlNode geoNode in geoNodes)
            {
                string coordinates = null;
                string country = null;
                string administrativeArea = null;
                string subAdministrativeArea = null;
                string locality = null;
                string street = null;
                string building = null;
                try
                {
                    coordinates = geoNode.GetChild("GeoObject/Point/pos").InnerText;
                    var countryNode =
                        geoNode.GetChild("GeoObject/metaDataProperty/GeocoderMetaData/AddressDetails/Country");
                    country = countryNode.GetChild("CountryName").InnerText;
                    var administrativeAreaNode = countryNode.GetChild("AdministrativeArea");
                    if (administrativeAreaNode == null)
                    {
                        throw new YandexMapsApiException(
                            "Неожиданный формат ответа геокодера (нет поля {0})",
                            "AdministrativeArea");
                    }
                    administrativeArea = administrativeAreaNode.GetChild("AdministrativeAreaName").InnerText;
                    var subAdministrativeAreaNode = administrativeAreaNode.GetChild("SubAdministrativeArea");
                    if (subAdministrativeAreaNode == null)
                    {
                        throw new YandexMapsApiException(
                            "Неожиданный формат ответа геокодера (нет поля {0})",
                            "SubAdministrativeArea");
                    }
                    subAdministrativeArea =
                        subAdministrativeAreaNode.GetChild("SubAdministrativeAreaName").InnerText;
                    var localityNode = subAdministrativeAreaNode.GetChild("Locality");
                    if (localityNode == null)
                    {
                        throw new YandexMapsApiException(
                            "Неожиданный формат ответа геокодера (нет поля {0})",
                            "Locality");
                    }
                    locality = localityNode.GetChild("LocalityName").InnerText;
                    var streetNode = localityNode.GetChild("Thoroughfare/ThoroughfareName");
                    if (streetNode == null)
                    {
                        throw new YandexMapsApiException(
                            "Неожиданный формат ответа геокодера (нет поля {0})",
                            "ThoroughfareName");
                    }
                    street = streetNode.InnerText;
                    var buildingNode = localityNode.GetChild("Thoroughfare/Premise/PremiseNumber");
                    if (buildingNode != null)
                    {
                        building = buildingNode.InnerText;
                    }
                }
                catch (YandexMapsApiException)
                { }
                foundGeoObjects.Add(new GeoObject(
                    new Address(
                        country,
                        administrativeArea,
                        subAdministrativeArea,
                        locality,
                        street,
                        building),
                    new Coordinates(coordinates)));
               
            }
            return foundGeoObjects;
        }
    }
}
