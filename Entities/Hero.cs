using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIO.Marvel.Dto;

namespace DIO.Marvel.Entities
{
    public class Hero
    {

        public Hero(){}
        public Hero(CreateHero hero)
        {
            Name = hero.Name;
            RealName = hero.RealName;
            GroupId = hero.GroupId;
            Createdat = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        
        [MaxLength(80)]
        [MinLength(3)]
        public string Name { get; set; }

        [MaxLength(80)]
        [Required]
        public string RealName { get; set; }
        public DateTime Createdat { get; set; }

        //Relacionamento
        public int? GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group group { get; set; }
    }
}