namespace SZC_API.Models
{
    public class Zahtjevi
    {
        public int id_zahtjeva { get; set; }
        public int id_klijenta { get; set; }
        public string termin_z { get; set; }
        public string adresa_z { get; set; }
        public string tip_ciscenje_z { get; set; }
        public string tip_apartman_z { get; set; }
        public string tel_broj_z { get; set; }
        public int opravdan { get; set; }
    }
}