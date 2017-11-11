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

namespace oefWerknemer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string werknemerType;
        List<Werknemer> werknemers;
        StukWerker stukWerker;
        CommissieWerker commissieWerker;
        UurWerker uurWerker;
        private bool enabled = false;

        public MainWindow()
        {
            InitializeComponent();

            werknemers = new List<Werknemer>();
            lbOutput.ItemsSource = werknemers;
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            Werknemer werknemer = null;
            string geslachtUrl = rbMan.IsChecked ?? false ? "man.jpg" : "vrouw.jpg";
            BitmapImage geslacht = MakeBitmapImageFor("images/" + geslachtUrl);

            switch (werknemerType)
            {
                case WerknemerType.CommissieWerker:
                    werknemer = commissieWerker;
                    werknemer.Geslacht = geslacht;
                    break;

                case WerknemerType.StukWerker:
                    werknemer = stukWerker;
                    werknemer.Geslacht = geslacht;
                    break;

                case WerknemerType.Uurwerker:
                    werknemer = uurWerker;
                    werknemer.Geslacht = geslacht;
                    break;
            }

            if (werknemer.isValid())
            {
                VoegToeAanOutputAndRefresh(werknemer);
                toggleEnableRadioButtons();
            }
            else
            {
                MessageBox.Show("Niet alle velden zijn in orde!");
            }

        }

        private void updateDataContextForType()
        {
            switch (werknemerType)
            {
                case WerknemerType.CommissieWerker:
                    commissieWerker = new CommissieWerker();

                    txtAantal.DataContext = commissieWerker;
                    txtCommissie.DataContext = commissieWerker;
                    txtLoon.DataContext = commissieWerker;
                    txtNaam.DataContext = commissieWerker;
                    txtVoornaam.DataContext = commissieWerker;

                    InstellenBindingAantal();
                    break;

                case WerknemerType.StukWerker:
                    stukWerker = new StukWerker();

                    txtAantal.DataContext = stukWerker;
                    txtCommissie.DataContext = stukWerker;
                    txtLoon.DataContext = stukWerker;
                    txtNaam.DataContext = stukWerker;
                    txtVoornaam.DataContext = stukWerker;

                    InstellenBindingAantal();
                    break;

                case WerknemerType.Uurwerker:
                    uurWerker = new UurWerker();

                    txtAantal.DataContext = uurWerker;
                    txtCommissie.DataContext = uurWerker;
                    txtLoon.DataContext = uurWerker;
                    txtNaam.DataContext = uurWerker;
                    txtVoornaam.DataContext = uurWerker;

                    InstellenBindingAantal("Uren");
                    break;

                default:
                    break;
            }
        }

        private void InstellenBindingAantal(string veld = "Aantal")
        {
            Binding myBinding = new Binding(veld);
            myBinding.ValidatesOnDataErrors = true;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
            BindingOperations.SetBinding(txtAantal, TextBox.TextProperty, myBinding);
        }

        private BitmapImage MakeBitmapImageFor(string url)
        {
            Uri uri = new Uri(url, UriKind.Relative);
            return new BitmapImage(uri);
        }

        private void VoegToeAanOutputAndRefresh(Werknemer werknemer)
        {
            werknemers.Add(werknemer);
            lbOutput.ItemsSource = null;
            lbOutput.ItemsSource = werknemers;
        }

        private void radioButtonClicked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            werknemerType = rb.Name;
            updateViewFor(werknemerType);
            updateDataContextForType();
        }

        private void updateViewFor(string type)
        {
            switch (type)
            {
                case WerknemerType.CommissieWerker:
                    stpAantal.Visibility = Visibility.Visible;
                    stpCommissie.Visibility = Visibility.Visible;
                    break;
                case WerknemerType.StukWerker:
                    stpAantal.Visibility = Visibility.Visible;
                    stpCommissie.Visibility = Visibility.Hidden;
                    break;
                case WerknemerType.Uurwerker:
                    stpAantal.Visibility = Visibility.Visible;
                    stpCommissie.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            toggleEnableRadioButtons();
        }

        private void toggleEnableRadioButtons()
        {
            enabled = !enabled;

            btnToevoegen.IsEnabled = enabled;
            rbCommissieWerker.IsEnabled = enabled;
            rbStukWerker.IsEnabled = enabled;
            rbUurWerker.IsEnabled = enabled;
            lbOutput.SelectedIndex = -1;
        }

        private void lbOutput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object werknemer = lbOutput.SelectedValue;

            if (werknemer.GetType() == typeof(UurWerker))
            {
                UurWerker uurWerker = (UurWerker)werknemer;

                InstellenBindingAantal("Uren");

                txtAantal.DataContext = uurWerker;
                txtCommissie.DataContext = uurWerker;
                txtLoon.DataContext = uurWerker;
                txtNaam.DataContext = uurWerker;
                txtVoornaam.DataContext = uurWerker;
            
            } else if (werknemer.GetType() == typeof(CommissieWerker))
            {
                CommissieWerker commissieWerker = (CommissieWerker)werknemer;

                InstellenBindingAantal();

                txtAantal.DataContext = commissieWerker;
                txtCommissie.DataContext = commissieWerker;
                txtLoon.DataContext = commissieWerker;
                txtNaam.DataContext = commissieWerker;
                txtVoornaam.DataContext = commissieWerker;

            } else if (werknemer.GetType() == typeof(StukWerker))
            {
                StukWerker stukWerker = (StukWerker)werknemer;

                InstellenBindingAantal();

                txtAantal.DataContext = stukWerker;
                txtCommissie.DataContext = stukWerker;
                txtLoon.DataContext = stukWerker;
                txtNaam.DataContext = stukWerker;
                txtVoornaam.DataContext = stukWerker;
            }
        }
    }
}

public sealed class WerknemerType
{
    public const string CommissieWerker = "rbCommissieWerker";
    public const string StukWerker = "rbStukWerker";
    public const string Uurwerker = "rbUurWerker";
    public const string Werknemer = "rbWerknemer";
}