namespace WindowsFormsApp1.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales
    {
        public int Id { get; set; }

        public int? FK_Inventory { get; set; }

        public int? Pricing { get; set; }

        public int? Amouth { get; set; }

        public DateTime? Date { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
