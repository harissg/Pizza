using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotStuffPizzaAPI.DAL.Models
{
    public class Reciepe
    {
        public int ReciepeID { get; set; }
        public string Description { get; set; }
        //public int IngredientID { get; set; }
        //public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}