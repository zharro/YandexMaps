namespace YandexMaps
{
    using System.Collections.Generic;

    public sealed class GeoCoderResponse
    {
        /// <summary>
        /// Общее число объектов, обнаруженных геокодером по переданному адресу
        /// </summary>
        public int CountOfFoundObjects { get; private set; }

        /// <summary>
        /// Объекты, содержащиеся в ответе геокодера.
        /// Их число можно настраивать доп. параметром results
        /// (http://api.yandex.ru/maps/doc/geocoder/desc/concepts/input_params.xml)
        /// </summary>
        public IEnumerable<GeoObject> GeoObjects {get; private set;}

        public GeoCoderResponse(int countOfFoundObjects, IEnumerable<GeoObject> geoObjects)
        {
            CountOfFoundObjects = countOfFoundObjects;
            GeoObjects = geoObjects;
        }
    }
}
