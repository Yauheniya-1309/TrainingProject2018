using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace My3Common
{
    public class Event : IEvent
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле Name должно быть установлено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле place некорректно")]
        public string Place { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public int CategoryID { get; set; }

        public List<Category> Categories { get; set; }
    }
}
