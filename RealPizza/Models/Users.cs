namespace RealPizza.Models
{
    using RealPizza.Controllers.ControlloCampi;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Ordini = new HashSet<Ordini>();
            Ordini1 = new HashSet<Ordini>();
        }

        [Key]
        public int ID_Utente { get; set; }

        [Required]
        [StringLength(50)]

        [Display(Name = "Nome Cliente")]
        [Nominativo]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        [Cognome]
        public string Cognome { get; set; }

        [Required]
        [StringLength(50)]
        [Username]
        public string Username { get; set; }

        [Required]
        [Email]
        public string Email { get; set; }

        
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Password]
        [Required]
        public string Password { get; set; }

        [Required]
        public string Indirizzo { get; set; }

        [Required]
        [StringLength(50)]
        public string Citta { get; set; }

        [Required]
        [StringLength(5)]
        public string CAP { get; set; }

        [Required]
        [StringLength(10)]
        public string Ruolo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini1 { get; set; }
    }
}
