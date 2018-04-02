using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Page
    {
        public DashBoard()
        {
            InitializeComponent();
            // Supply the control with the list of sections
            List<string> sections = new List<string> {"Title", "Text", "Audio"};
            m_txtTest.SectionsList = sections;

            // Choose a style for displaying sections
            m_txtTest.SectionsStyle = SearchTextBox.SectionsStyles.RadioBoxStyle;

            // Add a routine handling the event OnSearch
            m_txtTest.OnSearch += new RoutedEventHandler(m_txtTest_OnSearch);

            //Result r = new Result();
            //r.RecordingDate = Convert.ToDateTime("2000-12-15T22:11:03");
            //r.Duration = 5;
            //r.SessionName = "First recording";
            //r.Attendees = 3;

            //List<Result> tmpResultList  = new List<Result>();
            //tmpResultList.Add(r);

            //ResultList rl = new ResultList();
            //rl.results = tmpResultList;


            //var myjson = JsonConvert.SerializeObject(rl);


  

            string json = File.ReadAllText("Result.json");
            var tmp = JsonConvert.DeserializeObject<ResultList>(json);

            ICollectionView  cvResults = CollectionViewSource.GetDefaultView(tmp.results);

            dgResult.ItemsSource = cvResults;
            //cvResults.Filter = TextFilter;





        }

    void m_txtTest_OnSearch(object sender, RoutedEventArgs e)
        {
            SearchEventArgs searchArgs = e as SearchEventArgs;

            // Display search data
            string sections = ""; //Sections(s): 
            foreach (string section in searchArgs.Sections)
                sections += (section);
            MessageBox.Show("Filter for " + sections + " contains " + searchArgs.Keyword);

            ICollectionView cv = CollectionViewSource.GetDefaultView(dgResult.ItemsSource);

            string filter = searchArgs.Keyword;

            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Result p = o as Result;

                    if (sections == "Title") 
                        return p.Title.ToUpper().Contains(filter.ToUpper());
                    else
                        return false;

                };
            }


        }

        private void WebPageClick(object sender, RoutedEventArgs e)
        {
            Hyperlink link = e.OriginalSource as Hyperlink;
            //Process.Start(link.NavigateUri.AbsoluteUri);
            string newLink = "SessionPage.xaml#" + link.NavigateUri.OriginalString;
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new System.Uri(newLink, UriKind.RelativeOrAbsolute));

        }

    }



}
