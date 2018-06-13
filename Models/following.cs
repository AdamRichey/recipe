using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Plate.Models
{
    public class Following : BaseEntity
    {
        public int Personid{get; set;}
        public DateTime Start { get; set; }
        public Person Person{set; get;}
        public List<Network> Network {get;set;}
public Following()
        {
            Network = new List<Network>();

        }


    }
}

