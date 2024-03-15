namespace RealPizza.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Web.UI;
    using System.Web.WebPages;

    [Table("Pizze")]
    public partial class Pizze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pizze()
        {
            Ordini = new HashSet<Ordini>();
        }

        [Key]
        public int ID_Pizza { get; set; }

        [Required]
        [StringLength(50)]

        [Display(Name = "Nome Pizza")]
        public string Nome { get; set; }

        public decimal Prezzo { get; set; }

        [Display(Name = "Tempo di consegna")]
        public int Tempo_Consegna { get; set; }

        [Required]
        public string Ingredienti { get; set; }

        public string Immagine { get; set; } // Add this property for image path

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }
    }
}
