
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace RestaurantsClientApp.Models
{
    [Table("DetailOrder")]
    public class DetailOrder
    {
      [PrimaryKey, AutoIncrement, Column("DetailOrderId")]
        public int DetailOrderId { get; set; }

        public int Quantity { get; set; }
      
        [ForeignKey(typeof(DetailOrder))]
        public string OrderId { get; set; }   // ORDER-DETAILORDERS

        [ForeignKey(typeof(DetailOrder))]
        public string MealId { get; set; }    // Detailorder-Food

    }
   
}
