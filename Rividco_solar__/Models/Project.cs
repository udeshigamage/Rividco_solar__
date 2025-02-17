using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Project_ID { get; set; }

        public int Customer_ID { get; set; }
        
        public string location { get; set; }
        public string Coordinator_ID { get; set; }
        public string startdate { get; set; }
        public string warranty_period { get; set; }
        public string status { get; set; }
        public string Address { get; set; }

        public int estimatedcost { get; set; }

        public string referencedby { get; set; }

        public string comment { get; set; }
       

        public int Lastupdatedby { get; set; }

        public DateTime Commissioneddate { get; set; }

        public DateTime Lastupdatedtime { get; set; }
    }
}
