using AmigosAuction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosAuction.Web.ViewModels
{
    public class CategoryViewModel
    {
        public Category category { get; set; }
    }

    public class CategoriesViewModels
    {
        public List<Category> Categories { get; set; }
    }

    public class CreateCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Auction> Auctions { get; set; }
    }
}