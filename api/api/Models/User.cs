﻿using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }

        public string? Address { get; set; }
        public string? Role { get; set; }
        public ICollection<UserPromotion> UserPromotions { get; set; }
    }
}
