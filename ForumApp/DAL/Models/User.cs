namespace DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string Password_confirmation { get; set; }

        public DateTime RegistrationDate { get; set; }
        public string TypeUser { get; set; }
        public int CountMessages { get; set; }
    }
}
