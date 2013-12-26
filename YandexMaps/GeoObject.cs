namespace YandexMaps
{
    using System;
    using System.Drawing;
    using System.Net;

    public sealed class GeoObject
    {
        public Address Address { get; private set; }
        public Coordinates Coordinates { get; private set; }

        /// <summary>
        /// Клиентский метод обратного вызова при загрузке изображения
        /// </summary>
        private Action<StaticMapsResponse> _getImageResponse; 

        public GeoObject(Address address, Coordinates coordinates)
        {
            Address = address;
            Coordinates = coordinates;
        }

        public GeoObject(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public GeoObject(double latitude, double longitude)
        {
            Coordinates = new Coordinates(latitude, longitude);
        }

        /// <summary>
        /// Синхронно загружает изображение гео-объекта
        /// </summary>
        /// <param name="size">Размер карты</param>
        /// <param name="zoom">Приближение</param>
        /// <param name="labelColor">Цвет метки</param>
        /// <returns>Изображение гео-объекта</returns>
        public Image GetImage(Size size, int zoom, LabelColor labelColor)
        {
            if (size.Width < 0 || size.Width > 650 ||
                 size.Height < 0 || size.Height > 450)
            {
                throw new ArgumentOutOfRangeException("size", "Максимальное значение параметра: 650x450 пикселей");
            }
            if (zoom < 0 || zoom > 17)
            {
                throw new ArgumentOutOfRangeException("zoom", "Значение параметра должно быть в пределах от 0 до 17");
            }
            var url = string.Format(
                "http://static-maps.yandex.ru/1.x/?ll={0}&size={1}&z={2}&l=map&pt={0},pm2{3}l",
                Coordinates.ToApiFormatString(),
                string.Format("{0},{1}", size.Width, size.Height),
                zoom,
                labelColor.GetDescription());
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
        /// Инициирует асинхронный запрос для получения изображения гео-объекта
        /// </summary>
        /// <param name="size">Размер карты</param>
        /// <param name="zoom">Приближение</param>
        /// <param name="labelColor">Цвет метки</param>
        /// <param name="callback">Метод обратного вызова, вызываемый при получении ответа</param>
        public void BeginGetImage(Size size, int zoom, LabelColor labelColor, Action<StaticMapsResponse> callback)
        {
            if (size.Width < 0 || size.Width > 650 ||
                size.Height < 0 || size.Height > 450)
            {
                throw new ArgumentOutOfRangeException("size", "Максимальное значение параметра: 650x450 пикселей");
            }
            if (zoom < 0 || zoom > 17)
            {
                throw new ArgumentOutOfRangeException("zoom", "Значение параметра должно быть в пределах от 0 до 17");
            }
            _getImageResponse = callback;
            var url = string.Format(
               "http://static-maps.yandex.ru/1.x/?ll={0}&size={1}&z={2}&l=map&pt={0},pm2{3}l",
               Coordinates.ToApiFormatString(),
               string.Format("{0},{1}", size.Width, size.Height),
               zoom,
               labelColor.GetDescription());
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.BeginGetResponse(GetImageCallback, request);
        }

        /// <summary>
        /// Метод обратного вызова, вызываемый при получении ответа от Static Maps API
        /// </summary>
        /// <param name="asynchronousResult">Результат выполнения операции</param>
        private void GetImageCallback(IAsyncResult asynchronousResult)
        {
            StaticMapsResponse result;
            var requestState = (HttpWebRequest)asynchronousResult.AsyncState;
            try
            {
                using (var response = requestState.EndGetResponse(asynchronousResult))
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream == null)
                        {
                            throw new YandexMapsApiException("Ответ геокодера содержит пустой поток");
                        }
                        var map = Image.FromStream(responseStream);
                        result = new StaticMapsResponse(map);
                    }
                }
            }
            catch (Exception e)
            {
                result = new StaticMapsResponse(e);
            }
            _getImageResponse(result);
        }

        public override string ToString()
        {
            return Address == null ? 
                Coordinates.ToString() : 
                string.Format("{0} ({1})", Address, Coordinates);
        }
    }
}
