using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Plate.Models
{
    public class Recipes : BaseEntity
    {
        [Required]
        public string Name {get; set;}
        [Required]
        public string Description {get; set;}
        public string Serves{get; set;}
        public string Directions {get; set;}
        public DateTime Start { get; set; }
        public int Personid{get; set;}
        public Person Person{get; set;}

        public List<Ingredients> Ingredients {get;set;}
        public List<Favorites> Favorites {get;set;}
        public List<Shopping> Shopping{get; set;}
        public List<Comments> Comments{get; set;}
        public Recipes()
        {
            Ingredients = new List<Ingredients>();
            Favorites = new List<Favorites>();
            Shopping = new List<Shopping>();
            Comments = new List<Comments>();

        }

    }
    public class Ingredients : BaseEntity
    {
        [Required]
        public string Name {get; set;}
        [Required]
        public string Amount {get; set;}
        public string Comment{get; set;}
        public int Recipeid{get; set;}
        public Recipes Recipe{get; set;}
        }
    public class Comments : BaseEntity
    {
        public int Recipeid{get; set;}
        public string Comment{get; set;}
        public Recipes Recipe {get; set;}
        public Person Person {get; set;}
        
    }


}




