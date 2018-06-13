using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Plate.Models
{
    public class Shopping : BaseEntity
    {
        public int Personid{get; set;}
        public int Recipeid{get; set;}
        
        public Person Person{set; get;}
        public Recipes Recipe{set; get;}
        public List<Others> Other {get;set;}
        public Shopping()
        {
            Other = new List<Others>();
        }
    }
    public class Others : BaseEntity
    {
        public int Shoppingid{get; set;}
        public Shopping Shopping {get; set;}
        
    }

}

