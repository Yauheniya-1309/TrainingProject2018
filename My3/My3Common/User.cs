using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3Common
{
    public class User:IUser
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле Name должно быть установлено")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Поле e-mail некорректно")]
        public string Email { get; set; }

        [RegularExpression(@"^(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{6,})$", ErrorMessage = "Пароль должен содержать буквы и цифры и длина не меньше 6")]
        public string Password { get; set; }
    

        public DateTime AddedDate { get; set; }

        [Phone(ErrorMessage = "Поле PhoneNumber должно быть установлено")]
        public string PhoneNumber { get; set; }

        public int RoleID { get; set; }

        public string Login { get; set; }
    }
}
