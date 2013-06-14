using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aaron.WP7.Models
{
    public class Card
    {
        private readonly string _name;
        private readonly string _image;

        public Card(string name, string image)
        {
            _name = name;
            _image = image;
        }
    }
}
