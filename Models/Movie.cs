using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Id { get; set; }
        
        public Genre Genre { get; set; }
        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Stock Available")]
        public int NumberInStock { get; set; }
    }
}