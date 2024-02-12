using System.ComponentModel.DataAnnotations.Schema;

namespace ksr.Models
{
    public class DetailPenjualan
    {
        public int Id { get; set; }


        [ForeignKey("Penjualan_Id")]
        public Penjualan Penjualan { get; set;}

        [ForeignKey("Produk_id")]
        public Produk Produk { get; set; }

        public int Jumlah { get; set; }

        public double SubTotal { get; set; }
    }
}
