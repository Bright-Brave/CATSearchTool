using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CATSearchTool.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        // ViewModel
        public Model.SearchKey SearchKeyForBinding { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            // 可供选择的类型
            cmb_type.ItemsSource = new List<string>() {
                "物理产品",
                "图纸",
                "3D形状",
                "工程模板",
                "场地",
                "桥塔",
                "桥塔节段",
                "文件夹",
                "目录",
                "章节",
                "VPM文档"
                };
            // 默认值
            SearchKeyForBinding = new Model.SearchKey("物理产品","", "A.1", "");
            DataContext = SearchKeyForBinding;
            ShowInTaskbar = true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_name.Focus();
        }
        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            SearchKeyForBinding.Id = "";
            SearchKeyForBinding.Name = "";
            SearchKeyForBinding.Revision = "";
        }
        
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            BLL.CATMethods.Search(this);
        }


        private void txt_name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                TextBox tbx = sender as TextBox;
                tbx.SelectAll();
                tbx.PreviewMouseDown -= new MouseButtonEventHandler(textBox1_PreviewMouseDown);

            }

        }

        private void textBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.Focus();
                e.Handled = true;
            }
        }

        private void textBox1_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.PreviewMouseDown += new MouseButtonEventHandler(textBox1_PreviewMouseDown);
            }
        }

        private void txt_Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BLL.CATMethods.Search(this);
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmb_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SearchKeyForBinding.Type)
            {
                case "文件夹":
                    SearchKeyForBinding.Revision = "";
                    SearchKeyForBinding.Name = "";
                    break;
                case "目录":
                    SearchKeyForBinding.Revision = "";
                    SearchKeyForBinding.Name = "";
                    break;
                case "章节":
                    SearchKeyForBinding.Revision = "";
                    SearchKeyForBinding.Name = "";
                    break;
                default:
                    SearchKeyForBinding.Revision = "A.1";
                    break;
            }
        }

        private void MinApp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
