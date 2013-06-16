using System.Linq;
using Aaron.WP7.Models;
using UpdateControls.XAML;

namespace Aaron.WP7.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        private Board _board;
        private Selection _selection;

        public ViewModelLocator()
        {
            _board = new Board();
            _selection = new Selection();
        }

        public object Main
        {
            get { return ViewModel(() => MakeBoardViewModel()); }
        }

        public BoardViewModel DesignTimeMain
        {
            get
            {
                Group group = _board.Groups.First();
                _selection.SelectedGroup = group;
                _selection.SelectedCard = group.Cards.First();
                return MakeBoardViewModel();
            }
        }

        public GroupViewModel DesignTimeGroup
        {
            get { return MakeGroupViewModel(_board.Groups.First()); }
        }

        public CardViewModel DesignTimeCard
        {
            get
            {
                Group group = _board.Groups.First();
                return MakeCardViewModel(group.Cards.First(), group);
            }
        }

        private BoardViewModel MakeBoardViewModel()
        {
            return new BoardViewModel(_board, _selection, MakeGroupViewModel);
        }

        private GroupViewModel MakeGroupViewModel(Group group)
        {
            return new GroupViewModel(group, card => MakeCardViewModel(card, group));
        }

        private CardViewModel MakeCardViewModel(Card card, Group group)
        {
            return new CardViewModel(card, group, _selection);
        }
    }
}
