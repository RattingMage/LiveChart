using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LiveChat1
{
    /// <summary>
    /// Логика взаимодействия для Add_Employee.xaml
    /// </summary>
    public partial class Add_Employee : Window
    {
        public Add_Employee()
        {
            InitializeComponent();
        }
        private bool Count_of_Month()
        {
            if (ComboBox2.SelectedIndex < ComboBox1.SelectedIndex)
            {
                MessageBox.Show("Не правильно указана дата");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Count_of_Month())
            {


                switch (Company.SelectedIndex)
                {
                    case 0:
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.Names1.Add(TextBox_Name.Text);
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.Salary1.Add(Convert.ToDouble(TextBox_Salary.Text));
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.StartDate1.Add(ComboBox1.SelectedIndex);
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.EndDate1.Add(ComboBox2.SelectedIndex);
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.Year_Salary();
                        Close();
                        break;
                    case 1:
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.Names2.Add(TextBox_Name.Text);
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.Salary2.Add(Convert.ToDouble(TextBox_Salary.Text));
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.StartDate2.Add(ComboBox1.SelectedIndex);
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.EndDate2.Add(ComboBox2.SelectedIndex);
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.Year_Salary();
                        Close();
                        break;
                    case 2:
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.Names3.Add(TextBox_Name.Text);
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.Salary3.Add(Convert.ToDouble(TextBox_Salary.Text));
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.StartDate3.Add(ComboBox1.SelectedIndex);
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.EndDate3.Add(ComboBox2.SelectedIndex);
                        Wpf.CartesianChart.PointShapeLine.PointShapeLineExample.Year_Salary();
                        Close();
                        break;
                }
            }
        }
    }
}
