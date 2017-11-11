using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace oefWerknemer
{
    class Werknemer : INotifyPropertyChanged, IDataErrorInfo
    {
        private decimal _loon;
        private string _naam;
        private string _voornaam;
        private BitmapImage _geslacht;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool isValid() => string.IsNullOrEmpty(Error);

        public void RaisedPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Werknemer( string naam, string voornaam, decimal loon, BitmapImage geslacht)
        {
            Loon = loon;
            Naam = naam;
            Voornaam = voornaam;
            Geslacht = geslacht;
        }

        public string Naam
        {
            get => _naam;
            set
            {
                _naam = value;
                RaisedPropertyChanged("Naam");
            }
        }

        public decimal Loon
        {
            get => _loon;
            set
            {
                _loon = value;
                RaisedPropertyChanged("Loon");
            }
        }

        public string Voornaam
        {
            get => _voornaam;
            set
            {
                _voornaam = value;
                RaisedPropertyChanged("Voornaam");
            }
        }
        public BitmapImage Geslacht { get => _geslacht; set => _geslacht = value; }
        public string Gegevens { get => ToString(); }

        public string Error
        {
            get
            {
                string error = "";
                string result = "";

                foreach (PropertyInfo prop in GetType().GetProperties())
                {
                    error = this[prop.Name];

                    if (!string.IsNullOrEmpty(error))
                    {
                        result = error + Environment.NewLine;
                    }
                }

                return result;
            }
        }

        public virtual string this[string columnName]
        {
            get
            {
                bool NaamIsEmpty = columnName == "Naam" && String.IsNullOrEmpty(Naam);
                bool VoornaamIsEmpty = columnName == "Voornaam" && string.IsNullOrEmpty(Voornaam);
                bool LoonIsKleinerDanNul = columnName == "Loon" && Loon < 0;

                if (NaamIsEmpty)
                {
                    return "Naam is een verplicht veld!";
                }
                if (VoornaamIsEmpty)
                {
                    return "Voornaam is een verplicht veld!";
                }
                if (LoonIsKleinerDanNul)
                {
                    return "Loon moet groter of gelijk zijn dan 0!";
                }

                return null;
            }
        }

        public virtual decimal Verdiensten()
        {
            return Loon;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} € {2}", Naam.PadRight(30), Voornaam.PadRight(30), Verdiensten().ToString().PadRight(15));
        }

        public override bool Equals(object obj)
        {
            var werknemer = obj as Werknemer;
            return werknemer != null &&
                   Loon == werknemer.Loon &&
                   Naam == werknemer.Naam &&
                   Voornaam == werknemer.Voornaam;
        }

        public override int GetHashCode()
        {
            var hashCode = -2020264601;
            hashCode = hashCode * -1521134295 + Loon.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Naam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Voornaam);
            return hashCode;
        }
    }
}
