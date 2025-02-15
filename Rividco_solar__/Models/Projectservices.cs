using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class Projectservices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Projectservice_ID { get; set; }

        public int Project_ID { get; set; }

        public Project Project { get; set; }
        public DateTime Planneddate { get; set; }

        public string status { get; set; }

        public int Conducted_by { get; set; }
        public DateTime Conducted_date { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public string Servicereportlink { get; set; }

        public string service {  get; set; }



    }
}
