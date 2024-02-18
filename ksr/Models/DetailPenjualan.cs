using System.ComponentModel.DataAnnotations.Schema;

namespace ksr.Models
{
    public class DetailPenjualan
    {
        public int Id { get; set; }

        public Penjualan Penjualan { get; set; }
        public Produk Produk { get; set; }

        public int Jumlah { get; set; }

        public double SubTotal => Jumlah * Produk.Harga;
    }
}
