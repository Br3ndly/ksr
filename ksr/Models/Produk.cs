using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ksr.Models
{
    public class Produk
    {
        [Key]
        public int ID { get; set; }

        public string Nama { get; set; }

        public double Harga { get; set; }

        public int Stok { get; set; }

    }


    

}
