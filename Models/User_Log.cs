namespace CoderByte.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Log
    {
        public int Id { get; set; }

        public int? User_Id { get; set; }

        public DateTime? LoginDate { get; set; }

        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
