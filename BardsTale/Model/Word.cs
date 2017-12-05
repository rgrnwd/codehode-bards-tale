using System;
namespace BardsTale.Model
{
    public class Word
    {
        public Word(String value, WordType type){
            this.Value = value;
            this.Type = type;
        }
        public WordType Type { get; set; }
        public String Value { get; set; }
    }
}
