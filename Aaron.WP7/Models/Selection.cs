using System;
using UpdateControls.Fields;

namespace Aaron.WP7.Models
{
    public class Selection
    {
        private Independent<Card> _selectedCard = new Independent<Card>();
        private Independent<Group> _selectedGroup = new Independent<Group>();

        public event EventHandler FlipForward;
        public event EventHandler FlipBackward;

        public Card SelectedCard
        {
            get { return _selectedCard; }
            set { _selectedCard.Value = value; }
        }

        public Group SelectedGroup
        {
            get { return _selectedGroup; }
            set { _selectedGroup.Value = value; }
        }

        public void RaiseFlipForward()
        {
            if (FlipForward != null)
                FlipForward(this, new EventArgs());
        }

        public void RaiseFlipBackward()
        {
            if (FlipBackward != null)
                FlipBackward(this, new EventArgs());
        }
    }
}
