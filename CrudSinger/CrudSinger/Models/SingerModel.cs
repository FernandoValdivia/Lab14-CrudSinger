using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrudSinger.Models
{
    public class SingerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSingerModel { get; set; }
        public string NameSingerModel { get; set; }
        public DateTime BirthSingerModel { get; set; }
        public bool ActiveModel { get; set; }
    }
}
