using System;
using System.ComponentModel.DataAnnotations;

namespace net5_catalog.Dtos {
    public record ItemDto {
        public Guid Id { get; init; }    
        public string Name { get; init; }    
        public decimal Price { get; init; }    
        public DateTimeOffset CreatedDate { get; init; }    
    }
}