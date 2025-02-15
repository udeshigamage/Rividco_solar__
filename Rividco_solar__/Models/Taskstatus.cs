using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class Taskstatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Taskstatus_Id { get; set; }

        public string status { get; set; }

        public DateTime Addeddate { get; set; }

        public int changedby { get; set; }

        public string comment { get; set; }

    }
}
