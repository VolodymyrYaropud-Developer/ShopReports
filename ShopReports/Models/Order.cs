﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("customer_orders")]
    public class Order
    {
        [Key]
        [Column("customer_order_id", TypeName = "int")]
        public int Id { get; set; }

        [Column("operation_time", TypeName = "string")]
        public string OperationTime { get; set; }

        [ForeignKey(nameof(SupermarketLocation))]
        [Column("supermarket_location_id", TypeName ="int")]
        public int SupermarketLocationId { get; set; }

        [ForeignKey(nameof(Customer))]
        [Column("customer_id", TypeName = "int?")]
        public int? CustomerId { get; set; }

        public SupermarketLocation SupermarketLocation { get; set; }

        public Customer? Customer { get; set; }

        public virtual IList<OrderDetail> Details { get; set; }
    }
}
