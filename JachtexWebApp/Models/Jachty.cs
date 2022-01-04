using System;
using System.Collections.Generic;

#nullable disable

namespace JachtexWebApp.Models
{
    public partial class Jachty
    {
        public Jachty()
        {
            Wypozyczenia = new HashSet<Wypozyczenium>();
        }

        public int IdJacht { get; set; }
        public string Kategoria { get; set; }
        public string Nazwa { get; set; }
        public int DziennyKoszt { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Wypozyczenium> Wypozyczenia { get; set; }
    }
}
