using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rividco_solar__.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Employee_ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string email { get; set; }

        public string Address { get; set; }

       

       

        public string mobileno { get; set; }

        public string officeno { get; set; }

        public int Lastupdatedby { get; set; }

        public DateTime Lastupdatedtime { get; set; }
    }
}
