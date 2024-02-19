using System.ComponentModel.DataAnnotations;

namespace ksr.Models
{
    public class Pelanggan
    {
        [Key]
        public int Id { get; set; }

        public string Nama  { get; set; }
        public string Alamat { get; set; }
        public string NomorTelepon { get; set; }

    }

}
