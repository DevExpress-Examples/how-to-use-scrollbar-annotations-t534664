using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication25
{
    public class ViewModel
    {
        public ObservableCollection<TestData> List
        {
            get;
            set;
        }

        public ViewModel()
        {
            List = new ObservableCollection<TestData>();
            PopulateData();
        }

        private void PopulateData()
        {
            for (int i = 0; i < 30; i++)
            {
                var t = new TestData(i, "Element" + i.ToString());
                List.Add(t);
            }
        }
    }

    public class TestData : INotifyPropertyChanged, IDataErrorInfo
    {
        int number;
        string text;

        public TestData(int number, string text)
        {
            this.number = number;
            this.text = text;
        }

        public int Number
        {
            get { return number; }
            set
            {
                if (number == value)
                    return;
                number = value;
                NotifyChanged("Number");
            }
        }
        public string Text
        {
            get { return text; }
            set
            {
                if (text == value)
                    return;
                text = value;
                NotifyChanged("Text");
            }
        }

        public string Error
        {
            get
            {
                string result = String.Empty;
                if (Number >= 10 && Number < 20)
                    result = "Incorrect value!";
                return result;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = String.Empty;
                switch (columnName)
                {
                    case "Number":
                        if (Number > 20 && Number <= 40)
                            result = String.Format("The current number is less than {0} !", Number.ToString());
                        break;
                }
                return result;
            }
        }

        void NotifyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
