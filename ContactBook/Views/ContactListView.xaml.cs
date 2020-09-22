using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactBook.Views
{
    /// <summary>
    /// Interaction logic for ContactListView.xaml
    /// </summary>
    public partial class ContactListView : UserControl
    {
        public ContactListView()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(this.DetailStackPanel); i++)
        //    {
        //        Grid grid = VisualTreeHelper.GetChild(this.DetailStackPanel, i) as Grid;
        //        if (grid != null)
        //        {
        //            for (int j = 0; j < VisualTreeHelper.GetChildrenCount(this.DetailsGrid); j++)
        //            {
        //                TextBox txtBox = VisualTreeHelper.GetChild(this.DetailsGrid, j) as TextBox;
        //                if (txtBox != null)
        //                {
        //                    txtBox.Text = string.Empty;
        //                }
        //            }
        //            //txt.Text = string.Empty;
        //        }
        //    }
        //}
    }
}
