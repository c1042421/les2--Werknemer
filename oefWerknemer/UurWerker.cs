using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace oefWerknemer
{
    class UurWerker : Werknemer
    {
        private double _uren;

        public double Uren { get => _uren; set
            {
                _uren = value;
                RaisedPropertyChanged("Uren");
            }
        }

        public UurWerker(string naam, string voornaam, decimal loon, int aantalUren, BitmapImage geslacht): base(naam, voornaam, loon, geslacht)
        {
            Uren = aantalUren;
        }

        public UurWerker(): this("", "", 0, 0, null) { }

        public override decimal Verdiensten()
        {
            decimal verdiensten = Loon * (decimal)Uren;
            return verdiensten > 40 ? verdiensten * 2: verdiensten;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), "UurWerker");
        }

        public override string this[string columnName]
        {
            get
            {
                bool urenIsKleinerDanNul = columnName == "Uren" && Uren < 0;

                if (urenIsKleinerDanNul)
                {
                    return "Uren moet groter of gelijk zijn dan 0!";
                }

                return base[columnName];
            }
        }
    }
}
