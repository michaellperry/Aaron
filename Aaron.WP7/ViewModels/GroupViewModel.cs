using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aaron.WP7.Models;

namespace Aaron.WP7.ViewModels
{
    public class GroupViewModel
    {
        private readonly Group _group;

        public GroupViewModel(Group group)
        {
            _group = group;
        }

        public IEnumerable<CardViewModel> Cards
        {
            get
            {
                return
                    from card in _group.Cards
                    select new CardViewModel(card, _group);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            GroupViewModel that = obj as GroupViewModel;
            if (that == null)
                return false;
            return Object.Equals(this._group, that._group);
        }

        public override int GetHashCode()
        {
            return _group.GetHashCode();
        }
    }
}
