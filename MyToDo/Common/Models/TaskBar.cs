using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Common.Models
{
    /// <summary>
    /// 任务栏
    /// </summary>
    public class TaskBar : BindableBase
    {
        private string icon;

        public string Icon
        {
            get { return icon; }
            set
            {
                icon = value; RaisePropertyChanged();
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                content = value; RaisePropertyChanged();
            }
        }


        private string color;

        public string Color
        {
            get { return color; }
            set
            {
                color = value; RaisePropertyChanged();
            }
        }


        private string target;

        public string Target
        {
            get { return target; }
            set
            {
                target = value; RaisePropertyChanged();
            }
        }
    }
}
