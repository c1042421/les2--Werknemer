using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefWerknemer
{
    class CommissieWerker: Werknemer
    {
        private int _aantal;
        private decimal _commissie;

        public int Aantal { get => _aantal; set => _aantal = value; }
        public decimal Commissie { get => _commissie; set => _commissie = value; }

        public CommissieWerker(string naam, string voornaam, decimal loon, decimal commissie, int aantal) : base(naam, voornaam, loon)
        {
            Commissie = commissie;
            Aantal = aantal;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", base.ToString(), "CommissieWerker");
        }

        public override decimal Verdiensten()
        {
            return Loon + Aantal * Commissie;
        }
    }
}
