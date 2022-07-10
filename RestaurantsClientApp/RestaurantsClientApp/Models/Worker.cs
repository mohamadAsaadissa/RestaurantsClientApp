using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace RestaurantsClientApp.Models
{

    [Table("Worker")]
    public class Worker
    {
     
        [PrimaryKey, Column("WorkerId")]
        public string WorkerId { get; set; } = Guid.NewGuid().ToString();

        public DateTime SDate { get; set; } = DateTime.Now;

        public string Path { get; set; }//foto  
        public string FullName { get; set; }
        public string Location { get; set; }      
        public string Phone { get; set; }
        public string Email { get; set; }
        public Position Position { get; set; } = Position.waiter;
            
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public virtual IEnumerable<Order> Orders { get; set; }   // worker-orders
    }

    public enum Position
    {
       Kitchen, waiter, Casher,Chef, Cleanliness
    }
}
