using LogicUniversityStore.Dao;
using LogicUniversityStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.Util
{
    public class Common
    {
        public CategoryDao CategoryDao { get; set; }

        public Common()
        {
            CategoryDao = new CategoryDao();
        }

        public List<Category> GetCategories()
        {
            return CategoryDao.GetCategories();
        }

        public List<Item> GetItemsByCategoryId(int categoryId)
        {
            return CategoryDao.GetItemsByCategoryId(categoryId);
        }
    }
}