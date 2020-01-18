using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Locatie
    {
        [ForeignKey("Vanzare")]
        public int locatieId { get; set; }
        public string descriere { get; set; }

        public virtual Vanzare Vanzare { get; set; }


    }
}