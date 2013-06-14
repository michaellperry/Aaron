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
                    .AddCard("Bad Weather", "Weather.png")
            };
        }

        public IEnumerable<Group> Groups
        {
            get { return _groups; }
        }
    }
}
