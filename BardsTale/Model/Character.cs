using System;
namespace BardsTale.Model
{
    public class Character
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Adjective { get; set; }
        public string FavouriteFood { get; set; }
        public string FavouriteThing { get; set; }

        public Character()
        {
        }

        public Character(string type, String name, String adjective, String favouriteFood){
            this.Type = type;    
            this.Name = name;    
            this.Adjective = adjective;    
            this.FavouriteFood = favouriteFood;    
        }
    }
}
