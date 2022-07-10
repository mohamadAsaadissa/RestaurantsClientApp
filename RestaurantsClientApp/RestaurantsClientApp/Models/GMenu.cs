using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace RestaurantsClientApp.Models
{

    [Table("GMenu")]
    public class GMenu
    {

        [PrimaryKey, Column("GMenuId")]
        public string GMenuId { get; set; } 
      
        public string Path { get; set; }//foto  
        public string MenuName { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; } = true;

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public virtual IEnumerable<Meal> Meals { get; set; }  // Meals-Menu
    }

  
}
