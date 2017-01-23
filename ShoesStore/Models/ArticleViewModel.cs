using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesStore.Models
{
    public class ArticleViewModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public double price { get; set; }

        public double total_in_shelf { get; set; }

        public double total_in_vault { get; set; }

        public string store_name { get; set; }
    }
}