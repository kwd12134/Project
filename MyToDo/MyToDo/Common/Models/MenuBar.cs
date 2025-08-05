namespace MyToDo.Common.Models
{
    /// <summary>
    /// 系统导航菜单栏
    /// </summary>
    public class MenuBar : BindableBase
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
        private string nameSpace;

        public string NameSpace
        {
            get { return nameSpace; }
            set
            {
                nameSpace = value; RaisePropertyChanged();
            }
        }

    }
}
