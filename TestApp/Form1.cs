namespace TestApp
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using YandexMaps;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private readonly GeoCoder _geoCoder = new GeoCoder();

        public Form1()
        {
            InitializeComponent();
            labelColorCmbbox.SelectedIndex = 0;
        }

        private void downloadImageBtn_Click(object sender, EventArgs e)
        {
            Image image = null;
            var countOfFoundObjects = 0;
            GeoObject firstFoundGeoObject = null;
            try
            {
                var selectedlabelColor = (LabelColor) labelColorCmbbox.SelectedIndex;
                Cursor = Cursors.WaitCursor;
                downloadImageBtn.Enabled = false;
                foundObjectsInfoPanel.Visible = false;

                // Одна локация
                if (oneLocationRbtn.Checked)
                {
                    var searchObjectsTask = new Task<GeoCoderResponse>(() =>
                        _geoCoder.SearchObjectsInLocation(localeTb.Text));
                    searchObjectsTask.Start();
                    searchObjectsTask.ContinueWith(genTask =>
                    {
                        var geoCollection = genTask.Result;
                        countOfFoundObjects = geoCollection.CountOfFoundObjects;
                        firstFoundGeoObject = geoCollection.GeoObjects.First();
                        image = firstFoundGeoObject.GetImage(
                            new Size
                            {
                                Width = (int)WidthNumeric.Value,
                                Height = (int)HeightNumeric.Value
                            },
                            (int)ZoomNumeric.Value,
                            selectedlabelColor);
                    }, TaskContinuationOptions.OnlyOnRanToCompletion)
                    .Wait();
                    if (searchObjectsTask.Exception != null)
                    {
                        throw searchObjectsTask.Exception.InnerException;
                    }
                    countOfFoundObjectsLabel.Text = countOfFoundObjects.ToString(CultureInfo.CurrentCulture);
                    locationInfoTbox.Text = string.Format(
                        "{0} ({1})",
                        firstFoundGeoObject.Address,
                        firstFoundGeoObject.Coordinates);
                    foundObjectsInfoPanel.Visible = true;
                }
                else if (locationsFromFileRbtn.Checked) // Локации из файла
                {
                    var parseLocationsTask = new Task<IDictionary<GeoObject, LabelColor>>(() =>
                        ParseLocations(locationsFilenameTbox.Text));
                    parseLocationsTask.Start();
                    parseLocationsTask.ContinueWith(genTask =>
                    {
                        var geoObjects = genTask.Result;
                        image = _geoCoder.GetImageForObjects(
                            geoObjects.First().Key.Address.Locality,
                            new Size
                            {
                                Width = (int) WidthNumeric.Value,
                                Height = (int) HeightNumeric.Value
                            },
                            (int) ZoomNumeric.Value,
                            geoObjects);
                    }, TaskContinuationOptions.OnlyOnRanToCompletion)
                    .Wait();
                    if (parseLocationsTask.Exception != null)
                    {
                        throw parseLocationsTask.Exception.InnerException;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Произошла ошибка");
                return;
            }
            finally
            {
                Cursor = Cursors.Arrow;
                downloadImageBtn.Enabled = true;
            }

            pictureBox1.Image = image;
            resultsGbox.Visible = true;
        }

        private void selectLocationsFileBtn_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                Multiselect = false,
                RestoreDirectory = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                locationsFilenameTbox.Text = openFileDialog1.FileName;
            }
        }

        private IDictionary<GeoObject, LabelColor> ParseLocations(string fileName)
        {
            var res = new Dictionary<GeoObject, LabelColor>();
            using (var sr = new StreamReader(fileName, Encoding.Default))
            {
                string line;
                while (!string.IsNullOrWhiteSpace(line = sr.ReadLine()))
                {
                    var pieces = line.Split(':');
                    var geoObject = _geoCoder.SearchObjectsInLocation(pieces[0]).GeoObjects.FirstOrDefault();
                    res.Add(geoObject, (LabelColor)int.Parse(pieces[1]));
                }
            }
            return res;
        }
    }
}
