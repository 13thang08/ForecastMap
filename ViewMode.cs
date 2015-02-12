using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastMap
{
    class ViewMode : INotifyPropertyChanged
    {
        public static readonly int EDIT = 0;
        public static readonly int SELECT = 1;

        public static readonly string editText = "完了";
        public static readonly string selectText = "編集";

        private int mode = SELECT;
        private string text = selectText;

        public bool SelectMode
        {
            get
            {
                if (mode == SELECT) return true;
                else return false;
            }
        }

        public bool EditMode
        {
            get
            {
                if (mode == EDIT) return true;
                else return false;
            }
        }

        public string Text
        {
            get
            {
                if (mode == SELECT) return selectText;
                else return editText;
            }
        }

        public int Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
                NotifyPropertyChanged("Mode");
                NotifyPropertyChanged("SelectMode");
                NotifyPropertyChanged("EditMode");
                NotifyPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
