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

        public string address { get; set; }
        public string contactno { get; set; }
        public string passwordhash { get; set; }

        




    }
}
