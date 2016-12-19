using System;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Library.Models
{
    [Table(Name = "Author")]
    public class Author
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid Author_Id { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
    }    
}