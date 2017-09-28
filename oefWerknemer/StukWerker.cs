using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefWerknemer
{
    class StukWerker : Werknemer
    {
        private int _aantal;

        public int Aantal { get => _aantal; set => _aantal = value; }
    
        public StukWerker(string naam, string voornaam, decimal loonPerStuk, int aantal) : base(naam, voornaam, loonPerStuk)
        {
            Aantal = aantal;
        }

        public override decimal Verdiensten()
        {
            return Loon * Aantal;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", base.ToString(), "StukWerker");
        }
    }
}
