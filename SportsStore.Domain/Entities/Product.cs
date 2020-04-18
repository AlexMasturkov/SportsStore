using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        [HiddenInput(DisplayValue = true)] // this way the value will be displayed but can not be edited
        public string ImageDataFileName { get; set; }

       
        public byte[] ProductData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ProductMimeType { get; set; }

        [HiddenInput(DisplayValue = true)] // this way the value will be displayed but can not be edited
        public string ProductDataFileName { get; set; }

    }
}
