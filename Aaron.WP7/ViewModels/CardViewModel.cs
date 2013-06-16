using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using Aaron.WP7.Models;
using UpdateControls.XAML;

namespace Aaron.WP7.ViewModels
{
    public class CardViewModel
    {
        private readonly Card _card;
        private readonly Group _group;
        private readonly Selection _selection;

        public event EventHandler Selected;
        
        public CardViewModel(Card card, Group group, Selection selection)
        {
            _card = card;
            _group = group;
            _selection = selection;
        }

        public Color Color
        {
            get { return _group.Color; }
        }

        public string Image
        {
            get { return String.Format("/Assets/{0}", _card.Image); }
        }

        public ICommand Select
        {
            get
            {
                return MakeCommand
                    .Do(delegate
                    {
                        _selection.SelectedCard = _card;
                        _selection.SelectedGroup = _group;
                        if (Selected != null)
                            Selected(this, new EventArgs());
                    });
            }
        }

        public void RaiseFlipForward()
        {
            _selection.RaiseFlipForward();
        }

        public event EventHandler FlipBackward
        {
            add { _selection.FlipBackward += value; }
            remove { _selection.FlipBackward -= value; }
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
