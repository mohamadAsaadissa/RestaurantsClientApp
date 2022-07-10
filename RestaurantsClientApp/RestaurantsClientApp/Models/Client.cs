using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace RestaurantsClientApp.Models
{

    [Table("Client")]
    public class Client
    {

        [PrimaryKey, Column("ClientId")]
        public string ClientId { get; set; } = Guid.NewGuid().ToString();

        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime SDate { get; set; } = DateTime.Now;
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        
        public virtual IEnumerable<Order>  Orders { get; set; }  // client-orders
    }
}
