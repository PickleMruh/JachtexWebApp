using System;
using System.Collections.Generic;

#nullable disable

namespace JachtexWebApp.Models
{
    public partial class Wypozyczenium
    {
        public int IdWypo { get; set; }
        public int IdKlient { get; set; }
        public int IdJacht { get; set; }
        public DateTime WypoStart { get; set; }
        public DateTime WypoKoniec { get; set; }

        public virtual Jachty IdJachtNavigation { get; set; }
        public virtual Klienci IdKlientNavigation { get; set; }
    }
}
