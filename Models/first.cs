using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Plate.Models
{
    public class Person : BaseEntity
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Recipes> Recipes {get;set;}
        public List<Favorites> Favorites {get;set;}
        public List<Shopping> Shopping {get;set;}
        public List<Comments> Comments {get;set;}
        public List<Network> Network {get;set;}
        public List<Following> Following {get;set;}
        public Person()
        {
            Recipes = new List<Recipes>();
            Favorites = new List<Favorites>();
            Shopping = new List<Shopping>();
            Comments = new List<Comments>();
            Network = new List<Network>();
            Following = new List<Following>();

        }

    }
}

