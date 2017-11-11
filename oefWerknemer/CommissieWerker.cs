using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace oefWerknemer
{
    class CommissieWerker: Werknemer
    {
        private int _aantal;
        private decimal _commissie;

        public int Aantal
        {
            get => _aantal;
            set
            {
                _aantal = value;
                RaisedPropertyChanged("Aantal");
            }
        }

        public decimal Commissie { get => _commissie; set
            {
                _commissie = value;
                RaisedPropertyChanged("Commissie");
            }
        }

        public CommissieWerker(string naam, string voornaam, decimal loon, decimal commissie, int aantal, BitmapImage geslacht) : base(naam, voornaam, loon, geslacht)
        {
            Commissie = commissie;
            Aantal = aantal;
        }

        public CommissieWerker() : this("", "", 0, 0, 0, null) { }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), "CommissieWerker");
        }

        public override decimal Verdiensten()
        {
            return Loon + Aantal * Commissie;
        }

        public override string this[string columnName]
        {
            get
            {
                bool aantalIsKleinerDanNul = columnName == "Aantal" && Aantal < 0;
                bool commissieIsKleinerDanNul = columnName == "Commissie" && Commissie < 0;

                if (aantalIsKleinerDanNul)
                {
                    return "Aantal moet groter of gelijk zijn dan 0!";
                }

                if (commissieIsKleinerDanNul)
                {
                    return "Commissie moet groter of gelijk zijn dan 0!";
                }

                return base[columnName] ;
            }
        }
    }
}
