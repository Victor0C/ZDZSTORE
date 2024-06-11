﻿using System.ComponentModel.DataAnnotations;
using ZDZSTORE.Validations;

namespace ZDZSTORE.User.DTO
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "The name field is required.")]
        [MaxLength(64, ErrorMessage = "The name field must have a maximum of 64 characters")]
        public string name { get; set; }

        [EmailAvailable]
        [MaxLength(100, ErrorMessage = "The email field must have a maximum of 100 characters")]
        public string email { get; set; }

        [Required(ErrorMessage = "The password field is required.")]
        [MaxLength(21,ErrorMessage = "The password field must have a maximum of 21 characters")]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
        public string password { get; set; }

    }
}
