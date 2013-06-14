using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aaron.WP7.Models;
using UpdateControls.XAML;

namespace Aaron.WP7.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        private Board _board;

        public ViewModelLocator()
        {
            _board = new Board();
        }

        public object Main
        {
            get { return ViewModel(() => new BoardViewModel(_board)); }
        }

        public BoardViewModel DesignTimeMain
        {
            get { return new BoardViewModel(_board); }
        }
    }
}
