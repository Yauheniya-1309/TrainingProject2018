namespace My3Common
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "The field Name couldn't be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Name couldn't be empty")]
        [EmailAddress(ErrorMessage = "The field e-mail is incorrect")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The Password must contain more than 6 symbols")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "The field PhoneNumber couldn't be empty")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Role must be set")]
        public string Role { get; set; }

        [Required(ErrorMessage = "The field Login couldn't be empty")]
        public string Login { get; set; }
    }
}
