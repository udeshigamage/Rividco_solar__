using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class Projectitem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Projectitem_ID { get; set; }

        public int Project_ID { get; set; }

        public Project Project { get; set; }
        

        public int Vendor_ID { get; set; }

        public Vendor Vendor { get; set; }



        public int Vendoritem_ID { get; set; }

        public Vendoritem Vendoritem { get; set; }


        public string serialno { get; set; }

         public string warranty_duration { get; set; }

        public int Added_by { get; set; }

        public DateTime Added_Date {  get; set; } 

        public string comment { get; set; }

        




    }
}
