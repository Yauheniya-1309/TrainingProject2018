namespace My3Common
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Web;
    #endregion

    public class Event
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name must be set")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Place must be set")]
        public string Place { get; set; }

        public string UserName { get; set; }

        [Required]
        [ValidateYears(ErrorMessage = "The Date must be in future")]
        public DateTime Date { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "Description maust be set")]
        public string Description { get; set; }

        public string Picture { get; set; }

        [Required(ErrorMessage = "Choose one of the Category")]
        public string Category { get; set; }
    }

    public class ValidateYearsAttribute : ValidationAttribute
    {
        private readonly DateTime _minValue = DateTime.Now;

        private readonly DateTime _maxValue = DateTime.Now.AddYears(100);

        public override bool IsValid(object value)
        {
            DateTime val = (DateTime)value;
            return val >= _minValue && val <= _maxValue;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, _minValue, _maxValue);
        }
    }
}
