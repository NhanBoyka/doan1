﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan1.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        //Relationship
        public List<OrderItem> OrderItems { get; set;}
    }
}
