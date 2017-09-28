using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefWerknemer
{
    class UurWerker : Werknemer
    {
        private double _uren;

        public double Uren { get => _uren; set => _uren = value; }

        public UurWerker(string naam, string voornaam, decimal loon, int aantalUren): base(naam, voornaam, loon)
        {
            Uren = aantalUren;
        }

        public override decimal Verdiensten()
        {
            decimal verdiensten = Loon * (decimal)Uren;
            return verdiensten > 40 ? verdiensten * 2: verdiensten;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", base.ToString(), "UurWerker");
        }
    }
}
