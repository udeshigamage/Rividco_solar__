using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class Systemuser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Systemuser_ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string email { get; set; }

        public string Address { get; set; }

        public string category { get; set; }

        public string comment { get; set; }

        public string mobileno { get; set; }

        public string officeno { get; set; }

        public string Role { get; set; }

        public byte[]? Profilpic { get; set; }
        
        public string username { get; set; }

        public string password { get; set; }

        public int Lastupdatedby { get; set; }

        public DateTime Lastupdatedtime { get; set; }




    }
}
