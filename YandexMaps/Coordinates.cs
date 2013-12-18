﻿namespace YandexMaps
{
    using System;
    using System.Globalization;

    public sealed class Coordinates
    {
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }

        public Coordinates(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public Coordinates(string coordinatesString)
        {
            if (string.IsNullOrWhiteSpace(coordinatesString))
            {
                throw new ArgumentException("Пустая строка", "coordinatesString");
            }
            var coordinates = coordinatesString.Trim().Split(new[] { ',', ' ' });
            if (coordinates.Length != 2)
            {
                throw new ArgumentException(
                    "Строка имеет неправильный формат. Ожидаемый формат 'log-de,lat-de' или 'log-de lat-de'", 
                    "coordinatesString");
            }
            var properCulture = GetProperCulture();
            double newLongitude;
            double newLatitude;
            if (!double.TryParse(coordinates[0], NumberStyles.Number, properCulture, out newLongitude) ||
                !double.TryParse(coordinates[1], NumberStyles.Number, properCulture, out newLatitude))
            {
                throw new ArgumentException("Не удается преобразовать параметр к типу Double", "coordinatesString");
            }
            Longitude = newLongitude;
            Latitude = newLatitude;
        }

        public override string ToString()
        {
            var properCulture = GetProperCulture();
            return string.Format(
                "{0},{1}", 
                Longitude.ToString(properCulture), 
                Latitude.ToString(properCulture));
        }

        /// <summary>
        /// Возвращает текущую культуру, указывая символ '.' в качестве NumberDecimalSeparator
        /// </summary>
        /// <returns>Текущая культура с символом '.' в качестве NumberDecimalSeparator</returns>
        private static CultureInfo GetProperCulture()
        {
            var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.NumberDecimalSeparator = ".";
            return ci;
        }
    }
}
