using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aaron.WP7.Models;

namespace Aaron.WP7.ViewModels
{
    public class BoardViewModel
    {
        private readonly Board _board;

        public BoardViewModel(Board board)
        {
            _board = board;
        }

        public IEnumerable<GroupViewModel> Groups
        {
            get
            {
                return
                    from g in _board.Groups
                    select new GroupViewModel(g);
            }
        }
    }
}
