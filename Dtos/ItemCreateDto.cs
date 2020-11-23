using System;
using System.ComponentModel.DataAnnotations;

namespace net5_catalog.Dtos {
    public record ItemCreateDto {
        [Required] 
        public string Name { get; init; } 

        [Required]
        [Range(1,1000)]   
        public decimal Price { get; init; }    
    }
}