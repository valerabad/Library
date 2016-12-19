using System;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    [Table(Name = "Book")]
    public class Book
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid Book_Id { get; set; }
        [Column(Name = "Title")]
        public string Title { get; set; }        
        [Column(Name = "is_avaliable")]
        public bool is_avaliable { get; set; }

        //[Required]
        //[RegularExpression(@"[0-9]", ErrorMessage = "You need enter the number")]
        [Column(Name = "quantity")]
        public int quantity { get; set; }

    }
}