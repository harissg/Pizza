using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HotStuffPizzaAPI.DAL.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public String Description { get; set; }
        public String ImageUrl { get; set; }
        public int ProductTypeID { get; set; }
    }
}