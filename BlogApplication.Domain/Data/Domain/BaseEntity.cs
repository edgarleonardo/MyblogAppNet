using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.Domain.Data.Domain
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
