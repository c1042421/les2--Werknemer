using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefWerknemer
{
    class Werknemer
    {
        private decimal _loon;
        private string _naam;
        private string _voornaam;

        public Werknemer( string naam, string voornaam, decimal loon)
        {
            Loon = loon;
            Naam = naam;
            Voornaam = voornaam;
        }

        public decimal Loon { get => _loon; set => _loon = value; }
        public string Naam { get => _naam; set => _naam = value; }
        public string Voornaam { get => _voornaam; set => _voornaam = value; }

        public virtual decimal Verdiensten()
        {
            return Loon;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2}€)", Naam, Voornaam, Verdiensten().ToString());
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
