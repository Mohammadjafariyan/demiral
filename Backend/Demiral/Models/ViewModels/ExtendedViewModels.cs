using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demiral.Models.ViewModels
{
    public class CategoryVM : Category
    {
        public int? RowCount { get; set; }
    }
}