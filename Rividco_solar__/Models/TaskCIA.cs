﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rividco_solar__.Models
{
    public class TaskCIA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Task_ID { get; set; }

        public string category { get; set; }

        public int Addedby { get; set; }

        public DateTime AddedDate { get; set; }

        public int Requestedby { get; set; }

        public int Assignedto { get; set; }

       

        public string Urgencylevel { get; set; }

        [ForeignKey("Project")]
        public int Project_ID { get; set; }

        [ValidateNever]
        public Project Project { get; set; }

        public string callbackno { get; set; }

        public string status { get; set; }

        public string comment { get; set; }

       

        



    }
}
