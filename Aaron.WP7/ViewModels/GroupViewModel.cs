using System;
using System.Collections.Generic;
using System.Linq;
using Aaron.WP7.Models;

namespace Aaron.WP7.ViewModels
{
    public class GroupViewModel
    {
        private readonly Group _group;
        private readonly Func<Card, CardViewModel> _makeCardViewModel;
        
        public GroupViewModel(Group group, Func<Card, CardViewModel> makeCardViewModel)
        {
            _group = group;
            _makeCardViewModel = makeCardViewModel;
        }

        public IEnumerable<CardViewModel> Cards
        {
            get
            {
                return
                    from card in _group.Cards
                    select _makeCardViewModel(card);
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
