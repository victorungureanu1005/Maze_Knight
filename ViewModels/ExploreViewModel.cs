using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Maze_Knight.ViewModels
{
    public class ExploreViewModel : BaseViewModel
    {
        private string _text = "hey";

        public string Texty
        {
            get { return _text; }
            set { _text = value; }
        }

        public ExploreViewModel()
        {
            Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    await Task.Delay(300);
                    _text = i.ToString();
                    i++;
                    OnPropertyChanged(nameof(Texty));

                }
            });

        }
    }
}
