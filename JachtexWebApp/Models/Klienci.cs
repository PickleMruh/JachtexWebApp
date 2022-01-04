using System;
using System.Collections.Generic;

#nullable disable

namespace JachtexWebApp.Models
{
    public partial class Klienci
    {
        public Klienci()
        {
            Wypozyczenia = new HashSet<Wypozyczenium>();
        }

        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrTel { get; set; }

        public virtual ICollection<Wypozyczenium> Wypozyczenia { get; set; }
    }
}
