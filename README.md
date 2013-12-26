YandexMaps
==========

Библиотека позволяет загружать все географические объекты, расположенные в указанном месте (адрес или координаты). Таким образом можно узнать координаты объекта по адресу и наоборот. Также можно загружать статическое изображение географического объекта, указав задав такие параметры карты как размер в пикселях, приближение и цвет метки, указывающей в центр выбранного объекта. Этот сценарий в тестовом приложении:
![11](https://f.cloud.github.com/assets/1455146/1773793/31e2a8f2-67ef-11e3-80d2-d7e072df0cf6.jpg)

Библиотека также позволяет получать изображения нескольких объектов, расположенных в пределах одного населенного пункта. Этот сценарий в тестовом приложении:
![scen2](https://f.cloud.github.com/assets/1455146/1782246/fe284198-68a7-11e3-8f6d-784584207f4a.jpg)

Пример исходного кода работы с библиотекой (синхронно):

            var geoCoder = new GeoCoder();
            // Найти все гео-объекты, расположенные по адресу 'Москва, ул. Тверская, дом 7'
            var geoObject1 = geoCoder.SearchObjectsInLocation("Москва, ул. Тверская, дом 7");

            // Результат: address="Россия, Московская область, Москва, Москва, Тверская улица, 7"
            var address = geoObject1.GeoObjects.First().Address;
            // Результат: coordinates="55.757962, 37.611006"
            var coordinates = geoObject1.GeoObjects.First().Coordinates;

            // Получить изображение точки на карте с адресом 'Москва, ул. Тверская, дом 7'
            // размером 600x400 пикселей и приближением 12 в виде зеленой метки
            var imageWithOneLabel = geoObject1.GeoObjects.First().GetImage(
                new Size(600, 400),
                12,
                LabelColor.Green);

            var geoObjects = new Dictionary<GeoObject, LabelColor>
            {
                {geoObject1.GeoObjects.First(), LabelColor.Red},
                {new GeoObject(55.796812, 37.617868), LabelColor.Yellow}
            };
            // Получить изображение двух объявленных выше точек на карте города Москвы
            var imageWithTwoLabels = geoCoder.GetImageForObjects("город Москва", new Size(600, 400), 10, geoObjects);
