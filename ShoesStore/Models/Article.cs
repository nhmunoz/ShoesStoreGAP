using System.ComponentModel.DataAnnotations;

namespace ShoesStore.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Total in shelf")]
        public double total_in_shelf { get; set; }

        [Display(Name = "Total in vault")]
        public double total_in_vault { get; set; }

        [Display(Name = "Store")]
        public int StoreId { get; set; }

        [Display(Name = "Store")]
        public Store Store { get; set; }
    }
}