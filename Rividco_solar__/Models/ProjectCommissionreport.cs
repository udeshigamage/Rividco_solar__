using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class ProjectCommissionreport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Projectcommisionrepo_Id { get; set; }

        public int Project_ID { get; set; }

        public Project Project { get; set; }

        public DateTime Project_Date { get; set; }

        public int Addedby {  get; set; }

        public int commissionreportno { get; set; }

        public string Link { get; set; }

        public string description { get; set; }

    }
}
