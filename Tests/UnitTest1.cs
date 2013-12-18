using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    using YandexMaps;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CoordinatesManipulations()
        {
            var coords = new Coordinates(37.611, 55.758);
            Assert.AreEqual("37.611, 55.758", coords.ToString());
            coords = new Coordinates("37.611, 55.758");
            Assert.AreEqual(37.611, coords.Longitude);
            Assert.AreEqual(55.758, coords.Latitude);
        }

        [TestMethod]
        public void DirectGeocoding()
        {
            //var collection1 = new GeoCoderResponse("Ekbwf cjdtncrfz");
            //var collection2 = new GeoCoderResponse("Улица советская");
            //Assert.AreEqual(collection1.CountOfFoundObjects, collection2.CountOfFoundObjects);
        }
    }
}
