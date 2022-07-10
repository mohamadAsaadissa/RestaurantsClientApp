using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestaurantsClientApp.Models
{
    [Table("Order")]
    public class Order
    {
        [PrimaryKey, Column("OrderId")]
        public string OrderId { get; set; } = Guid.NewGuid().ToString();
        public DateTime ODate { get; set; } = DateTime.Now;
        public int DisCount { get; set; } = 0;
        public string TableId { get; set; }= Dns.GetHostAddresses(Dns.GetHostName()).ToString();// table number
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.BankCard;

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public virtual List<DetailOrder> DetailOrders { get; set; } // detail about order

        [ForeignKey(typeof(Client))]
        public string ClientId { get; set; } = ""; // client-orders

        [ForeignKey(typeof(Worker))]
        public string WorkerId { get; set; } = "";      // worker-orders

    }
    public enum PaymentMethod {  BankCard, Debt, Swish  }

}
