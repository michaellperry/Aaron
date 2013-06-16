using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Aaron.WP7.Models;

namespace Aaron.WP7.ViewModels
{
    public class BoardViewModel
    {
        private readonly Board _board;
        private readonly Selection _selection;
        private readonly Func<Group, GroupViewModel> _makeGroupViewModel;

        public BoardViewModel(Board board, Selection selection, Func<Group, GroupViewModel> makeGroupViewModel)
        {
            _board = board;
            _selection = selection;
            _makeGroupViewModel = makeGroupViewModel;
        }

        public IEnumerable<GroupViewModel> Groups
        {
            get
            {
                return
                    from g in _board.Groups
                    select _makeGroupViewModel(g);
            }
        }

        public string SelectedCardName
        {
            get { return _selection.SelectedCard == null ? null : _selection.SelectedCard.Name; }
        }

        public Color SelectedCardColor
        {
            get { return _selection.SelectedGroup == null ? Colors.Black : _selection.SelectedGroup.Color; }
        }

        public event EventHandler FlipForward
        {
            add { _selection.FlipForward += value; }
            remove { _selection.FlipForward -= value; }
        }

        public void RaiseFlipBackward()
        {
            _selection.RaiseFlipBackward();
        }
    }
}
