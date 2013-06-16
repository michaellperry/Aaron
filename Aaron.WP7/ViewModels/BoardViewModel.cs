using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Media;
using System.Windows.Threading;
using Aaron.WP7.Models;
using Aaron.WP7.Services;

namespace Aaron.WP7.ViewModels
{
    public class BoardViewModel
    {
        private readonly Board _board;
        private readonly Selection _selection;
        private readonly Settings _settings;
        private readonly Func<Group, GroupViewModel> _makeGroupViewModel;

        private DispatcherTimer _cardTimer;
        
        public BoardViewModel(Board board, Selection selection, Settings settings, Func<Group, GroupViewModel> makeGroupViewModel)
        {
            _board = board;
            _selection = selection;
            _settings = settings;
            _makeGroupViewModel = makeGroupViewModel;

            _selection.FlipForward += Selection_FlipForward;
            _cardTimer = new DispatcherTimer();
            _cardTimer.Interval = TimeSpan.FromSeconds(2.0);
            _cardTimer.Tick += CardTimer_Tick;
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
            _cardTimer.Stop();
            _selection.RaiseFlipBackward();
        }

        void Selection_FlipForward(object sender, EventArgs e)
        {
            _cardTimer.Start();
        }

        void CardTimer_Tick(object sender, EventArgs e)
        {
            _cardTimer.Stop();
            if (!string.IsNullOrEmpty(_settings.CaregiverPhone) &&
                _selection.SelectedCard != null)
            {
                SmsService.SendMessage(_settings.CaregiverPhone, _selection.SelectedCard.Name);
            }
        }
    }
}
