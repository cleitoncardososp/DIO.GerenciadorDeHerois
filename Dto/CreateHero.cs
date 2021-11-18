using System;

namespace DIO.Marvel.Dto
{
    public class CreateHero
    {
        public string Name { get; set; }
        public string RealName { get; set; }
        //Relacionamento
        public int? GroupId { get; set; }
    }
}