using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Plate.Models
{
    public class Network : BaseEntity
    {
        public int Personid{get; set;}
        public int Followerid{get; set;}
        
        public Following PersonFollowed{set; get;}
        public Person PersonFollowing {set; get;}
        
    }
}

