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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtToevoegen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void radioButtonClicked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            updateViewFor(rb.Name);
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
