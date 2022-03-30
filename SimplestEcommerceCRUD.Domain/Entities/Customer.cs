﻿namespace SimplestEcommerceCRUD.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual List<Purchase> Purchases { get; set; }
    }
}
