using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Plate.Models
{
    public class Favorites : BaseEntity
    {
        public int Personid{get; set;}
        public int Recipeid{get; set;}
        
        public Person Person{set; get;}
        public Recipes Recipe{set; get;}
    }
}

