using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class ApplicationUser: IdentityUser
    {
        [PersonalData]
        [DisplayName("Nume")]
        [Column(TypeName = "nvarchar(100)")]
        public string Nume { get; set; }

        [PersonalData]
        [DisplayName("Prenume")]
        [Column(TypeName = "nvarchar(100)")]
        public string Prenume { get; set; }

        [PersonalData]
        [DisplayName("Sex")]
        [Column(TypeName = "nvarchar(100)")]
        public string Sex { get; set; }

        public ICollection<Detalii> Detaliis { get; set; }
    }
}
