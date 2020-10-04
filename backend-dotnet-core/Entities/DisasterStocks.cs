using System;

namespace WebApi.Entities
{
    public class DisasterStocks
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}