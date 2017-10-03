using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace oefWerknemer
{
    class StukWerker : Werknemer
    {
        private int _aantal;

        public int Aantal { get => _aantal; set => _aantal = value; }
    
        public StukWerker(string naam, string voornaam, decimal loonPerStuk, int aantal, BitmapImage geslacht ) : base(naam, voornaam, loonPerStuk, geslacht)
        {
            Aantal = aantal;
        }

        public override decimal Verdiensten()
        {
            return Loon * Aantal;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), "StukWerker");
        }
    }
}
