using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Plate.Models
{  
    public abstract class BaseEntity{
        [Key]
        public int id{get;set;}
    }

}