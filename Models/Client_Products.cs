namespace CoderByte.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client_Products
    {
        public int Id { get; set; }

        public int? ClientID { get; set; }

        public int? ProductID { get; set; }

        public decimal? Discount { get; set; }

        public DateTime? ActiveDate { get; set; }

        public DateTime? InactiveDate { get; set; }

        public virtual Client Client { get; set; }

        public virtual Product Product { get; set; }
    }
}
