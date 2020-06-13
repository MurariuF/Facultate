using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licenta.Models
{
    public class Detalii
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }


        [Required]
        [Range(18, 65, ErrorMessage = "{0} trebuie sa aveti intre {1} si {2} ani")]
        [PersonalData]
        [DisplayName("Varsta")]
        [Column(TypeName = "int")]
        public int Varsta { get; set; }

        [PersonalData]
        [DisplayName("Greutate")]
        [Column(TypeName = "int")]
        public int Greutate { get; set; }

        [PersonalData]
        [DisplayName("Inaltimea")]
        [Column(TypeName = "int")]

        public int Inaltimea { get; set; }


        [DisplayName("Data")]
        [Column(TypeName = "DateTime")]
        public DateTime Data { get; set; } = DateTime.Now;

        [PersonalData]
        [DisplayName("Grasime Corporala")]
        [Column(TypeName = "float")]

        public float Rezultat1 { get; set; }

        [PersonalData]
        [DisplayName("Grad")]
        [Column(TypeName = "nvarchar(100)")]
        public string Rezultat2 { get; set; }
    }
}