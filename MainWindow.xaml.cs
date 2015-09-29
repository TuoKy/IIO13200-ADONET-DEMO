//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
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

namespace JAMK.ICT.ADOBlanco
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
        


    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }

    private void IniMyStuff()
    {
      //TODO täytetään combobox asiakkaitten maitten nimillä
      //esimerkki kuinka App.Configissa oleva connectionstring luetaan
      lbMessages.Content = JAMK.ICT.Properties.Settings.Default.Tietokanta;

      cbCountries.ItemsSource = Data.DBPlacebo.getCities(Properties.Settings.Default.Tietokanta, Properties.Settings.Default.Taulu).DefaultView;
            
    }

    private void btnGet3_Click(object sender, RoutedEventArgs e)
    {
          dgCustomers.ItemsSource = Data.DBPlacebo.GetTestCustomers().DefaultView;
    }

    private void btnGetAll_Click(object sender, RoutedEventArgs e)
    {
            string paska = "";
            dgCustomers.ItemsSource = Data.DBPlacebo.GetAllCustomersFromSQLServer(Properties.Settings.Default.Tietokanta, Properties.Settings.Default.Taulu, out paska).DefaultView;
            lbMessages.Content = paska;
    }

    private void btnGetFrom_Click(object sender, RoutedEventArgs e)
    {
            dgCustomers.ItemsSource = Data.DBPlacebo.getFrom(Properties.Settings.Default.Tietokanta, Properties.Settings.Default.Taulu, cbCountries.Text).DefaultView;
    }

        private void btnYield_Click(object sender, RoutedEventArgs e)
        {
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }
    }
}
