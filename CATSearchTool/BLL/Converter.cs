using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CATSearchTool.BLL
{
    class Converter
    {
    }
    public class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string n = (string)value;
            bool returnValue = false;
            switch (n)
            {
                case "文件夹":
                    returnValue = false;
                    break;
                case "目录":
                    returnValue = false;
                    break;
                case "章节":
                    returnValue = false;
                    break;
                default:
                    returnValue = true;
                    break;
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
