using System.ComponentModel.DataAnnotations.Schema;

namespace ksr.Models
{
    public class Penjualan
    {
        public int Id { get; set; }

        public DateTime Tanggal { get; set; }

        public double  TotalHarga { get; set; }


        [ForeignKey("Pelanggan_Id")]
        public Pelanggan Pelanggan { get; set; }


        [ForeignKey("user_id")]
        public User User { get; set; }


        public ICollection<DetailPenjualan>Detail { get; set; }
    }

}
