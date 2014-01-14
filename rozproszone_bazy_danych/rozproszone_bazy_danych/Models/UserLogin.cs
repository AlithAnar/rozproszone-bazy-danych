using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace rozproszone_bazy_danych.Models
    {
    public class UserLogin
        {

        [DisplayName("Nazwa użytkownika")]
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Hasło")]
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        }
    }