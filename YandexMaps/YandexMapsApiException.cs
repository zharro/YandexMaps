namespace YandexMaps
{
    using System;

    public sealed class YandexMapsApiException : Exception
    {
        public YandexMapsApiException(string message)
            : base(message) { }

        public YandexMapsApiException(string message, Exception innerException)
            : base(message, innerException) { }

        public YandexMapsApiException(string format, params Object[] args)
            : base(string.Format(format, args)) { }
    }
}
