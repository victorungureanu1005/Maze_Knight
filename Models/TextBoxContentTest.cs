using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Maze_Knight.ViewModels;

namespace Maze_Knight.Models
{
    public class TextBoxContentTest : BaseModel
    {
        public string Name { get; set; }

        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            
            }
        }
        public string Occupation { get; set; }


    }

}
