using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATSearchTool.Model
{
    public class SearchKey : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // 类型
        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        // 标题
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        // 版本号
        private string revision;
        public string Revision
        {
            get { return revision; }
            set
            {
                revision = value;
                OnPropertyChanged("Revision");
            }
        }

        // 全称
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public SearchKey(string type,string name,string revision,string id)
        {
            Type = type;
            Name = name;
            Revision = revision;
            Id = id;
        }



    }
}
