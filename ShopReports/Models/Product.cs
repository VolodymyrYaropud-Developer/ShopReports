﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("shop_products")]
    public class Product
    {
        [Key]
        [Column("product_id", TypeName ="int")]
        public int Id { get; set; }

        [ForeignKey(nameof(Title))]
        [Column("product_title_id", TypeName ="int")]
        public int TitleId { get; set; }

        [ForeignKey(nameof(Manufacturer))]
        [Column("product_manufacturer_id", TypeName = "int")]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(Supplier))]
        [Column("product_supplier_id", TypeName = "int")]
        public int SupplierId { get; set; }

        [Column("unit_price", TypeName = "decimal")]
        public decimal UnitPrice { get; set; }

        [Column("comment", TypeName = "string")]
        public string Description { get; set; }

        public ProductTitle Title { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public Supplier Supplier { get; set; }

        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}
