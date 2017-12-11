using System;
namespace BardsTale.Model
{
    public class Character
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Adjective { get; set; }
        public string Likes { get; set; }

        public Character()
        {
        }

        public Character(string type){
            this.Type = type;    
        }
    }
}
