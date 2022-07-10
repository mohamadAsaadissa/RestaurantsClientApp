
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace RestaurantsClientApp.Models
{
    [Table("TempDetailOrder")]
    public class TempDetailOrder
    {
      [PrimaryKey, AutoIncrement, Column("TempDetailOrderId")]
        public int TempDetailOrderId { get; set; }

        public int TempQuantity { get; set; }
        public int TempPrice { get; set; }
        //[ForeignKey(typeof(DetailOrder))]
        //public string OrderId { get; set; }   // ORDER-DETAILORDERS

        //[ForeignKey(typeof(DetailOrder))]
        public string TempMealId { get; set; }    
        public string TempMealName { get; set; }
        public string TempPath { get; set; }
        public double TempSumma { get; set; }
    }
   
}
