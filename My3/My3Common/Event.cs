using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My3Common
{
    public class Event:IEvent
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле Name должно быть установлено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле place некорректно")]
        public string Place { get; set; }

        public int UserID { get; set; }
        
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
    }
}
