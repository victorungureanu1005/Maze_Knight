using Maze_Knight.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Texty));
            }
        }

        private BindingList<TextBoxContentTest> _textBoxContentTestCollection = new BindingList<TextBoxContentTest>();

        public BindingList<TextBoxContentTest> TextBoxContentTestsCollection
        {
            get { return _textBoxContentTestCollection; }
            set
            {
                _textBoxContentTestCollection = value;
                OnPropertyChanged(nameof(TextBoxContentTestsCollection));
            }
        }


        //Constructor for testing purposes only
        public ExploreViewModel()
        {

            for (int i = 0; i < 20; i++)
            {
                TextBoxContentTestsCollection.Add(new TextBoxContentTest { Age = i, Name = $"{i}+Hey", Occupation = "lala" });
            }

            Task.Run(async () =>
            {
                int j = 0;
                while (true)
                {
                    await Task.Delay(300);
                    TextBoxContentTestsCollection[0].Age = j;
                    j++;

                    TextBoxContentTestsCollection[9].Age = j*3;

                }
            }
);

        }

        private void ExploreViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }


}

