using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotStuffPizzaAPI.DAL.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string Description { get; set; }
        public String ImageUrl { get; set; }
    }
}