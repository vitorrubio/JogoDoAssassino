using Killer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Killer.Web.Models
{
    public class TeoriaViewModel
    {
        [Required]
        public virtual Armas Arma { get; set; }

        [Required]
        public virtual Locais Local { get; set; }

        [Required]
        public virtual Suspeitos Suspeito { get; set; }
    }
}