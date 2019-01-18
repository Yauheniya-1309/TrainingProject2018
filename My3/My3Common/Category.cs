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

    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }
    }
}
