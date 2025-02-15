using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class ProjectResources
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Projectresource_ID { get; set; }

        public int Addedby {  get; set; }

        public DateTime Addeddate { get; set; }

        public int Project_ID { get; set; }

        public Project Project { get; set; }

        public string comment { get; set; }

        public string link { get; set; }

        public string category { get; set; }



    }
}
