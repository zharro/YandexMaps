namespace YandexMaps
{
    using System;
    using System.Drawing;

    public sealed class StaticMapsResponse
    {
        public Image Map { get; private set; }
        public Exception Error { get; private set; }

        public StaticMapsResponse(Image map)
        {
            Map = map;
        }

        public StaticMapsResponse(Exception error)
        {
            Error = error;
        }
    }
}
