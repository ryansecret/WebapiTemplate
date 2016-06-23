using System;

namespace Ryan.Model
{
    public class BallEntity
    {
        public BallEntity(string name,string color)
        {
            this.Name = name;
            this.Color = color;
        }
        public string Name { get; private set; }

        public string Color { get; private set; }
    }
}