using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User { 
            public int Id { get; set; }

            [Required(ErrorMessage ="Name is required")]
            [MinLength(3, ErrorMessage ="min length is 3")]
            [MaxLength(20, ErrorMessage ="max length is 20")]
            public string Name { get; set; }
            [Range(20, 80)]
            public int Age { get; set; }
            [Required]
            public string City { get; set; }

    }
}