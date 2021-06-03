using CATSearchTool.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CATSearchTool.BLL
{
    // 验证External_ID
    public class DataValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // MainWindow为当前窗口类
            MainWindow mainwin = Application.Current.MainWindow as MainWindow;
            // mainWinVM为ViewModel
            string realValue = mainwin.SearchKeyForBinding.Id;
            ValidationResult validationResult = null;
            switch (mainwin.SearchKeyForBinding.Type)
            {
                case "文件夹":
                    validationResult = new ValidationResult(true, null);
                    break;
                case "目录":
                    validationResult = new ValidationResult(true, null);
                    break;
                case "章节":
                    validationResult = new ValidationResult(true, null);
                    break;
                default:
                    if (realValue != null)
                    {
                        if (Regex.IsMatch(value.ToString(), "^.{3}-\\d{8}-\\d{8}$"))
                        {
                            validationResult = new ValidationResult(true, null);
                        }
                        else
                        {
                            validationResult = new ValidationResult(false, "当前输入无效");
                        }
                    }
                    else
                    {
                        validationResult = new ValidationResult(true, null);
                    }
                    break;
            }
            return validationResult;
        }
    }
}
