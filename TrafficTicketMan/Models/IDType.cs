using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class IDType
    {
        public int IDTypeId { get; set; }
        [Required]
        [Display(Name = "Identity Description")]
        public string IDDescription { get; set; }
    }
}