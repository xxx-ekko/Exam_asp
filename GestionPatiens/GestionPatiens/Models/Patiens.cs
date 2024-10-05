using System;
using System.ComponentModel.DataAnnotations;

namespace GestionPatients.Models
{
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        public string NomPatient { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères")]
        public string PrenomPatient { get; set; }

        [StringLength(255, ErrorMessage = "L'adresse ne peut pas dépasser 255 caractères")]
        public string AdressePatient { get; set; }

        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse email valide")]
        public string EmailPatient { get; set; }

        [Phone(ErrorMessage = "Veuillez saisir un numéro de téléphone valide")]
        public string TelPatient { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissancePatient { get; set; }
    }
}