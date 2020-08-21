namespace CoderByte.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Client_Products = new HashSet<Client_Products>();
            User_Log = new HashSet<User_Log>();
        }

        public int Id { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MonthlyBasePrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client_Products> Client_Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Log> User_Log { get; set; }
    }
}
