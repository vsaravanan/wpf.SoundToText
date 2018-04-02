using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using UIControls;

namespace SoundToText
{
    /// <summary>
    /// Interaction logic for SessionPage.xaml
    /// </summary>
    public partial class SessionPage : Page
    {
        Speakers speakers = new Speakers();
        //ObservableCollection<Speaker> list = new ObservableCollection<Speaker>();

        public SessionPage()
        {
            InitializeComponent();

            string json = File.ReadAllText("Speakers.json");
            var tmp = JsonConvert.DeserializeObject<Speakers>(json);
            //list = tmp.list;
            //ICollectionView cvResults = CollectionViewSource.GetDefaultView(list);
            speakers.list = tmp.list;
            ICollectionView cvResults = CollectionViewSource.GetDefaultView(speakers.list);


            dgSpeakers.ItemsSource = cvResults;




        }

        private void OnPause(object sender, RoutedEventArgs e)
        {
            speakers.list[0].Status = "offline";
              var tmp  = JsonConvert.SerializeObject(speakers.list[0]);
            var tmp2 = JsonConvert.DeserializeObject<Speaker>(tmp);
            speakers.list[0] = tmp2;
            speakers.list.Add(new Speaker() { Mic = "5", Name = "User5", Status = "online" });

        }
    }
}
