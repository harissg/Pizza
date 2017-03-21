using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotStuffPizzaAPI.DAL.Models
{
    public class ProductReciepe
    {
        public int ProductReciepeID { get; set; }
        public int ReciepeID { get; set; }
        public int ProductID { get; set; }
        public int IngredientID { get; set; }
        public Reciepe Reciepe { get; set; }
        public Product Product { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}