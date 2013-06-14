using System.Collections.Generic;
using System.Windows.Media;

namespace Aaron.WP7.Models
{
    public class Group
    {
        private readonly string _name;
        private readonly Color _color;
        private List<Card> _cards = new List<Card>();
        
        public Group(string name, Color color)
        {
            _name = name;
            _color = color;
        }

        public string Name
        {
            get { return _name; }
        }

        public Color Color
        {
            get { return _color; }
        }

        public Group AddCard(string name, string image)
        {
            _cards.Add(new Card(name, image));
            return this;
        }

        public IEnumerable<Card> Cards
        {
            get { return _cards; }
        }
    }
}
