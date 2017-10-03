using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace oefWerknemer
{
    class Werknemer
    {
        private decimal _loon;
        private string _naam;
        private string _voornaam;
        private BitmapImage _geslacht;

        public Werknemer( string naam, string voornaam, decimal loon, BitmapImage geslacht)
        {
            Loon = loon;
            Naam = naam;
            Voornaam = voornaam;
            Geslacht = geslacht;
        }

        public decimal Loon { get => _loon; set => _loon = value; }
        public string Naam { get => _naam; set => _naam = value; }
        public string Voornaam { get => _voornaam; set => _voornaam = value; }
        public BitmapImage Geslacht { get => _geslacht; set => _geslacht = value; }
        public string Gegevens { get => ToString(); }

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
