﻿namespace budda.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> ProductsList { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}