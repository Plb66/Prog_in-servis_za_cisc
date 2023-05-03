namespace SZC_API.Models
{
    public class Ciscenja
    {
        public int id_ciscenja { get; set; }
        public int id_klijenta { get; set; }
        public string termin_c { get; set; }
        public string adresa_c { get; set; }
        public string tip_ciscenje_c { get; set; }
        public string tip_apartman_c { get; set; }
        public string tel_broj_c { get; set; }
    }
}