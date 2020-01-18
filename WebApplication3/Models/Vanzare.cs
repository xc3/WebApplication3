using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Vanzare
    {
        [Key]
        public int vanzareId { get; set; }
        public int produsId { get; set; }
        public int locatieId { get; set; }
        public int dataId { get; set; }
        public int clientId { get; set; }
        public int pret { get; set; }
        public int cantitate { get; set; }

        public virtual Produs Produs { get; set; }
        public virtual Locatie Locatie { get; set; }
        public virtual Data Data { get; set; }
        public virtual Client Client { get; set; }


    }
}