namespace YandexMaps
{
    using System;
    using System.Drawing;
    using System.Net;

    public sealed class GeoObject
    {
        public Address Address { get; private set; }
        public Coordinates Coordinates { get; private set; }

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

        public Image GetImage(Size size, int zoom, LabelColor labelColor)
        {
            if (size.Width < 0 || size.Width > 650 ||
                size.Height < 0 || size.Height > 450)
            {
                throw new ArgumentException("Максимальное значение параметра: 650x450 пикселей", "size");
            }
            if (zoom < 0 || zoom > 17)
            {
                throw new ArgumentException("Значение параметра должно быть в пределах от 0 до 17", "zoom");
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

        public override string ToString()
        {
            return Address == null ? 
                Coordinates.ToString() : 
                string.Format("{0} ({1})", Address, Coordinates);
        }
    }
}
