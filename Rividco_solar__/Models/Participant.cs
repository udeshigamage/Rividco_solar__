using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class Participant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Participant_ID { get; set; }

        public string category { get; set; }

        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string Address { get; set; }

        public string email { get; set; }

        public int Company_ID { get; set; }

        public Company Company { get; set; }

        public string profession {  get; set; }

        public string mobileno { get; set; }

        public string officeno { get; set; }

        public string comment { get; set; }

        public int Lastupdatedby { get; set; }

        public DateTime Lastupdatedtime { get; set; }



    }
}
