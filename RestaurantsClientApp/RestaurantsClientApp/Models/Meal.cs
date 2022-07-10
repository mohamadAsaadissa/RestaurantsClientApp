using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
namespace RestaurantsClientApp.Models
{

    [Table("Meal")]
    public class Meal
    {

        [PrimaryKey, Column("MealId")]
        public string MealId { get; set; }

        public string Path { get; set; }//foto  
        public string MealName { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; } = true;
        public int SalePris { get; set; }
        public int CostPris { get; set; }
        public DateTime SDate { get; set; } = DateTime.Now;
        public MealStatus MealStatus { get; set; } = MealStatus.Any;

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public virtual DetailOrder DetailOrder { get; set; }

        [ForeignKey(typeof(GMenu))]
        public string MenuId { get; set; }        // Menu-foods

    }

   public enum MealStatus { Offer, New, Any}
}