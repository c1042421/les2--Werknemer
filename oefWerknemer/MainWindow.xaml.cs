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

        public MainWindow()
        {
            InitializeComponent();

            werknemers = new List<Werknemer>();
            lbOutput.ItemsSource = werknemers;
        }

        private void txtToevoegen_Click(object sender, RoutedEventArgs e)
        {
            Werknemer werknemer;

            string naam = txtNaam.Text;
            string voornaam = txtVoornaam.Text;

            if (TextBoxesAreValid())
            {
                decimal loon = decimal.Parse(txtLoon.Text);
                int aantal;
                string geslachtUrl = rbMan.IsChecked ?? false ? "man.jpg" : "vrouw.jpg"; 
                BitmapImage geslacht = MakeBitmapImageFor("images/" + geslachtUrl);

                switch (werknemerType)
                {
                    case WerknemerType.CommissieWerker:
                        decimal commissie = decimal.Parse(txtCommissie.Text);
                        aantal = int.Parse(txtAantal.Text);

                        werknemer = new CommissieWerker(naam, voornaam, loon, commissie, aantal, geslacht);
                        break;

                    case WerknemerType.StukWerker:
                        aantal = int.Parse(txtAantal.Text);

                        werknemer = new StukWerker(naam, voornaam, loon, aantal, geslacht);
                        break;

                    case WerknemerType.Uurwerker:
                        aantal = int.Parse(txtAantal.Text);

                        werknemer = new UurWerker(naam, voornaam, loon, aantal, geslacht);
                        break;

                    default:
                        werknemer = new Werknemer(naam, voornaam, loon, geslacht);
                        break;
                }

                VoegToeAanOutputAndRefresh(werknemer);
            }else
            {
                ShowErrorMessage();
            }
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

        private void ShowErrorMessage()
        {
            if (!LoonIsValid())
            {
                toonMessageBoxMet("Gelieve een numeriek getal in te geven bij loon");
            } else if (!AantalIsValid())
            {
                toonMessageBoxMet("Gelieve een numeriek getal in te geven bij aantal");
            } else if (!CommissieIsValid())
            {
                toonMessageBoxMet("Gelieve een numeriek getal in te geven bij commissie");
            }
        }

        private void toonMessageBoxMet(string message)
        {
            MessageBox.Show(message, "Fout!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool TextBoxesAreValid()
        {
            bool validation = LoonIsValid();
            switch (werknemerType)
            {
                case WerknemerType.StukWerker:
                case WerknemerType.Uurwerker:
                    validation = validation && LoonIsValid() && AantalIsValid();
                    break;
                case WerknemerType.CommissieWerker:
                    validation = validation && CommissieIsValid();
                    break;
            }

            return validation;
        }

        private bool LoonIsValid()
        {
            return CheckTextBoxForDecimalValidation(txtLoon);
        }

        private bool CheckTextBoxForDecimalValidation(TextBox tb)
        {
            decimal dec;
            return decimal.TryParse(tb.Text, out dec);
        }

        private bool CommissieIsValid()
        {
            return CheckTextBoxForDecimalValidation(txtCommissie);
        }

        private bool AantalIsValid()
        {
            int i;
            return int.TryParse(txtAantal.Text, out i);
        }

        private void radioButtonClicked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            werknemerType = rb.Name;
            updateViewFor(werknemerType);
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
                case WerknemerType.Werknemer:
                    stpAantal.Visibility = Visibility.Hidden;
                    stpCommissie.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
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