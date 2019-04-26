using AmigosAuction.Data;
using AmigosAuction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigosAuction.Services
{
    public class CategoriesService
    {
        AmigosAuctionContext context;

        //List all
        public List<Category> GetCategories()
        {
            context = new AmigosAuctionContext();
            return context.Categories.ToList();
        }

        //Find Specific
        public Category GetCategoryByID(int ID)
        {
            context = new AmigosAuctionContext();
            return context.Categories.Find(ID);
        }

        //save 
        public void SaveCategory(Category category)
        {
            try
            {
                context = new AmigosAuctionContext();
                //Need to add EnityFramework from NuggetPackageManager
                context.Categories.Add(category);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public Category GetCategoryByID(int? id)
        {
            context = new AmigosAuctionContext();
            return context.Categories.Find(id);
        }

        //Update
        public void UpdateCategory(Category category)
        {
            context = new AmigosAuctionContext();
            context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        //Delete
        public void DeleteCategory(Category category)
        {
            context = new AmigosAuctionContext();
            context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
