using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class Vendoritem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vendoritem_ID { get; set; }

        public string item_name { get; set; }

        public float price { get; set; }

        public string Warranty_duration { get; set; }

        public string comment { get; set; }

        public string capacity { get; set; }

        [ForeignKey("Vendor")]
        public int Vendor_ID { get; set; }

        [ValidateNever]
        public Vendor? Vendor { get; set; } = null!;

        public string product_code { get; set; }

        public string brand { get; set; }

        public int Lastupdatedby { get; set; }

        public DateTime Lastupdatedtime { get; set; } = DateTime.Now;









    }
}
