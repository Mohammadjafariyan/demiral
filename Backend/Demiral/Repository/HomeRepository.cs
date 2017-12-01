using Demiral.Models;
using Demiral.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demiral.Controllers
{
    public class HomeRepository
    {

        private static Category[] groups;
        private DemiralEntities db = new DemiralEntities();

        private string getGroupName(List<Category> categories)
        {
            string name = "";
            categories.ForEach(c =>
            {
                name += c.Name + "/";
            });
            return name;
        }
        public Category[] Groups
        {
            get
            {
                if (groups == null || groups.Length == 0)
                {
                    lock (groups)
                    {
                        groups = db.Categories.Include("Category1").Include("Category1.Category1")
                            .OrderBy(c => c.Row).ToArray();
                        foreach (var g in groups)
                        {
                            g.Category2 = null;
                        }
                        List<Category> temp = new List<Category>();
                        groups = groups.GroupBy(g => g.Row).Select(g => g.ToList())
                              .Select(g => new Category { Name = getGroupName(g), Category1 = g }).ToArray();
                    }
                }
                

                return groups;
            }
            set
            {
                lock (groups)
                {
                    groups = value;
                }
            }
        }

        public static void Init()
        {
            groups = new Category[0];
        }

    }
}