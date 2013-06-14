﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
