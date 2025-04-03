using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace files
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManager file;
        int num;
        public MainWindow()
        {
            InitializeComponent();
            file = new FileManager("data.txt");
            Start();
            otherStart();
        }
        void Start()
        {   
            List<Cars> all = file.Read();
            allSP.Children.Clear();
            foreach (Cars item in all)
            {
                Label label = new Label() { Content = item.Model, FontSize = 20, Tag = item };
                label.MouseLeftButtonDown += Click;
                label.MouseRightButtonDown += EClick;
                allSP.Children.Add(label);
            }
        }
        void Create(object s, EventArgs e)
        {
            if (EditB.IsEnabled)
            {
                EditB.IsEnabled = false;
                ManufacturerI.Clear();
                ModelI.Clear();
                PowerI.Clear();
                WeightI.Clear();
                CreateB.Content = "Létrehozás";
                return;
            }
            if (!Check()) return;
            file.Write(new Cars(ManufacturerI.Text, ModelI.Text, int.Parse(PowerI.Text), int.Parse(WeightI.Text)));
            Start();
        }
        void Edit(object s, EventArgs e)
        {
            if (!Check()) return;
            file.Update(num, new Cars(ManufacturerI.Text, ModelI.Text, int.Parse(PowerI.Text), int.Parse(WeightI.Text)));
            Start();
        }
        void Click(object s, EventArgs e)
        {
            Cars car = (s as Label).Tag as Cars;
            MessageBox.Show($"{car.Manufacturer}, {car.Model}, {car.Power}, {car.Weight}, {car.PowerToWeight}");
        }
        void EClick(object s, EventArgs e)
        {
            Cars car = (s as Label).Tag as Cars;
            ManufacturerI.Text = car.Manufacturer;
            ModelI.Text = car.Model;
            PowerI.Text = car.Power.ToString();
            WeightI.Text = car.Weight.ToString();
            EditB.IsEnabled = true;
            CreateB.Content = "Vissza";
            num = allSP.Children.IndexOf(s as Label);
        }
        bool Check()
        {
            if (ManufacturerI.Text.Length < 2 || ModelI.Text.Length < 2 || PowerI.Text.Length < 1 || !int.TryParse(PowerI.Text, out _) || WeightI.Text.Length < 3 || !int.TryParse(WeightI.Text, out _))
            {
                MessageBox.Show("Invalid input");
                return false;
            }
            return true;
        }

        void otherStart()
        {
            List<Epitoanyagok> list = new List<Epitoanyagok>();

            list.Add(new Fa { faanyag = "tölgy", hardness = 0.1f, weight = 30.25, name = "tölgyfa", price = 100 });
            list.Add(new Vas { femtipus = "rozsdamentes acél", density = 5f, weight = 1500.25, name = "acél", price = 1500 });
            list.Add(new Tegla { type = "tegla", color = "piros", weight = 50.25, name = "piros tégla", price = 3800 });
            foreach (Epitoanyagok item in list)
            {
                if (item is Fa)
                {
                    MessageBox.Show((item as Fa).faanyag);
                }
                else if (item is Vas)
                {
                    MessageBox.Show((item as Vas).femtipus);
                }
                else if (item is Tegla)
                {
                    MessageBox.Show((item as Tegla).type);
                }
                item.price += 50;
            }
        }
    }
}
