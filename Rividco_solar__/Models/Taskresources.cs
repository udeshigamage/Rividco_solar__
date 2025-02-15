using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class Taskresources
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Taskresource_Id { get; set; }

        public string Resourceurl { get; set; }

        public DateTime Addeddate { get; set; }

        public int Addedby { get; set; }

        public string comment { get; set; }

    }
}
