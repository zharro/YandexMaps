namespace YandexMaps
{
    public sealed class Address
    {
        public string Country { get; private set; }
        public string AdministrativeArea { get; private set; }
        public string SubAdministrativeArea { get; private set; }
        public string Locality { get; private set; }
        public string Street { get; private set; }
        public string Building { get; private set; }

        public Address(
            string country, 
            string administrativeArea, 
            string subAdministrativeArea,
            string locality,
            string street,
            string building)
        {
            Country = country;
            AdministrativeArea = administrativeArea;
            SubAdministrativeArea = subAdministrativeArea;
            Locality = locality;
            Street = street;
            Building = building;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}, {1}, {2}, {3}, {4}, {5}",
                Country,
                AdministrativeArea,
                SubAdministrativeArea,
                Locality,
                Street,
                Building);
        }
    }
}
