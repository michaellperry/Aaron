using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Aaron.WP7.Models
{
    public class Board
    {
        private List<Group> _groups;

        public Board()
        {
            _groups = new List<Group>
            {
                new Group("Help/Emergency", Color.FromArgb(0xff, 0xD9, 0x42, 0x41))
                    .AddCard("Ambulance", "Ambulance.png")
                    .AddCard("Pain/Hurt", "Hurt.png")
                    .AddCard("Police", "Police.png")
                    .AddCard("Fire", "Fire.png")
                    .AddCard("I'm Sick", "Sick.png")
                    .AddCard("Bad Weather", "Weather.png"),
                new Group("I Want...", Color.FromArgb(0xFF, 0xF5, 0x81, 0x27))
                    .AddCard("Sandwich", "Sandwich.png")
                    .AddCard("Juice", "Juice.png")
                    .AddCard("Fruit", "Fruit.png")
                    .AddCard("Breakfast", "Breakfast.png")
                    .AddCard("Dinner", "Dinner.png")
                    .AddCard("Water", "Water.png"),
                new Group("Let's Play", Color.FromArgb(0xFF, 0x00, 0xE1, 0x01))
                    .AddCard("Watch TV", "TV.png")
                    .AddCard("Exercise", "Exercise.png")
                    .AddCard("Swing", "Swing.png")
                    .AddCard("Play with Blocks", "Blocks.png")
                    .AddCard("Ride Bicycle", "Bike.png")
                    .AddCard("Play with Toys", "Toys.png"),
                new Group("School/Education", Color.FromArgb(0xFF, 0xFF, 0xDF, 0x2C))
                    .AddCard("Reading", "Reading.png")
                    .AddCard("Math", "Math.png")
                    .AddCard("Science", "Science.png")
                    .AddCard("Writing", "Writing.png")
                    .AddCard("Coloring", "Coloring.png")
                    .AddCard("Music", "Music.png"),
                new Group("Cleanliness", Color.FromArgb(0xFF, 0x64, 0xA7, 0xD1))
                    .AddCard("Brush Teeth", "Brush.png")
                    .AddCard("Take Bath", "Bath.png")
                    .AddCard("Wash Hair", "Hair.png")
                    .AddCard("Clean Clothes", "Clothes.png")
                    .AddCard("Wash Face", "Face.png")
                    .AddCard("Wash Hands", "Hands.png"),
            };
        }

        public IEnumerable<Group> Groups
        {
            get { return _groups; }
        }
    }
}
