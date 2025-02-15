using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class Projecttest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

       public int ProjectTest_ID { get; set; }

        public int Project_ID { get; set; }

        public Project Project { get; set; }

        public int Conducted_by { get; set; }
        public DateTime Conducted_date { get; set; }
        public string result { get; set; }
        public string comment { get; set; }
        public string test_name { get; set; }

    }
}
