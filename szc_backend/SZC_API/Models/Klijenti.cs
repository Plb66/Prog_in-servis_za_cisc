using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookmarks4projects.Models
{
    public class Klijenti
    {
        public int id_klijenta { get; set; }
        public string naziv { get; set; }
        public string kor_ime { get; set; }
        public string lozinka { get; set; }
    }
}