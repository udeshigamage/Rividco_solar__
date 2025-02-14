using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rividco_solar__.Models
{
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Vendor_ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string mobileno { get; set; }

        public string officeno { get; set; }

        public string comment { get; set; }

        public string Address { get; set; }

        public string category { get; set; }

        public string Company_ID { get; set; }

        public int Lastupdatedby { get; set; }

        public DateTime Lastupdatedtime { get; set; }



    }
}
