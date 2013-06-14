using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aaron.WP7.Models;

namespace Aaron.WP7.ViewModels
{
    public class CardViewModel
    {
        private readonly Card _card;
        private readonly Group _group;

        public CardViewModel(Card card, Group group)
        {
            _card = card;
            _group = group;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            CardViewModel that = obj as CardViewModel;
            if (that == null)
                return false;
            return Object.Equals(this._card, that._card);
        }

        public override int GetHashCode()
        {
            return _card.GetHashCode();
        }
    }
}
