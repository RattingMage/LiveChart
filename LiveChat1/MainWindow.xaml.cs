using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using Microsoft.Office.Interop.Word;
using LiveChat1;

namespace Wpf.CartesianChart.PointShapeLine
{
    public partial class PointShapeLineExample : UserControl
    {

        public static List<string> Allnames = new List<string> { };
        public static List<string> Allcompanyes = new List<string> { };
        public static List<double> Allsalaryes = new List<double> { };
        public static List<double> Allstartdates = new List<double> { };
        public static List<double> Allenddates = new List<double> { };

        public static List<double> StartDate1 = new List<double> { 1, 6, 2 };
        public static List<double> StartDate2 = new List<double> { 1, 6, 2 };
        public static List<double> StartDate3 = new List<double> { 1, 6, 2 };
        
        public static List<double> EndDate1 = new List<double> { 6, 8, 12 };
        public static List<double> EndDate2 = new List<double> { 6, 8, 12 };
        public static List<double> EndDate3 = new List<double> { 6, 8, 12 };

        public static List<double> Salary1 = new List<double> { 100, 150, 200 };
        public static List<double> Salary2 = new List<double> { 200, 250, 300 };
        public static List<double> Salary3 = new List<double> { 300, 350, 400 };

        public static List<string> Names1 = new List<string> { "Ivan Ivanov", "Andrew Andreew", "Mark Zuckerberg" };
        public static List<string> Names2 = new List<string> { "Ivan Ivanov", "Andrew Andreew", "Mark Zuckerberg" };
        public static List<string> Names3 = new List<string> { "Ivan Ivanov", "Andrew Andreew", "Mark Zuckerberg" };

        static ChartValues<double> Company1 = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static ChartValues<double> Company2 = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static ChartValues<double> Company3 = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public static void Year_Salary()
        {
            for(int i = 0;i < 12; ++i)
            {
                for(int j = 0; j < Salary1.Count; ++j)
                {
                    if(i >= StartDate1[j] && i <= EndDate1[j])
                        Company1[i] += Salary1[j];
                    
                }
                for(int j = 0; j < Salary2.Count; ++j)
                {
                    if(i >= StartDate2[j] && i <= EndDate2[j])
                        Company2[i] += Salary2[j];
                }
                for (int j = 0; j < Salary3.Count; ++j)
                {
                    if(i >= StartDate3[j] && i <= EndDate3[j])
                        Company3[i] += Salary3[j];
                }
            }
        }
       
        public PointShapeLineExample()
        {
            InitializeComponent();
            Year_Salary();

            SeriesCollection = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Title = "Company 1",
                    Values = Company1
                },
                new LineSeries
                {
                    Title = "Company 2",
                    Values = Company2
                },
                new LineSeries
                {
                    Title = "Company 3",
                    Values = Company3
                }
            };
 
            Labels = new[] {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
            YFormatter = value => value.ToString("C");
 
            DataContext = this;
        }
 
        public LiveCharts.SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public void SaveToPng(FrameworkElement Visual)
        {
            var encoder = new PngBitmapEncoder();
            EncodeVisual(Visual, encoder);
        }

        private static void EncodeVisual(FrameworkElement Visual, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)Visual.ActualWidth, (int)Visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(Visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG File (*.png)|*.png";
            saveFileDialog.ShowDialog();
            FileStream fs = File.Create(saveFileDialog.FileName);
            encoder.Save(fs);
            fs.Close();
            //using (var stream = File.Create(filename)) encoder.Save(stream);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            SaveToPng(Chart);
        }

        public void Combination()
        {
            for (int i = 0; i < Names1.Count; ++i)
            {
                Allnames.Add(Names1[i]);
                Allsalaryes.Add(Salary1[i] * (EndDate1[i] - StartDate1[i]));
                Allstartdates.Add(StartDate1[i]);
                Allenddates.Add(EndDate1[i]);
                Allcompanyes.Add("Company 1");
            }
            for (int i = 0; i < Names2.Count; ++i)
            {
                Allnames.Add(Names2[i]);
                Allsalaryes.Add(Salary2[i] * (EndDate2[i] - StartDate2[i]));
                Allstartdates.Add(StartDate2[i]);
                Allenddates.Add(EndDate2[i]);
                Allcompanyes.Add("Company 2");
            }
            for (int i = 0; i < Names3.Count; ++i)
            {
                Allnames.Add(Names3[i]);
                Allsalaryes.Add(Salary3[i] * (EndDate3[i] - StartDate3[i]));
                Allstartdates.Add(StartDate3[i]);
                Allenddates.Add(EndDate3[i]);
                Allcompanyes.Add("Company 3");
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Combination();
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Document doc = app.Documents.Add(Visible: true);
                Range r = doc.Range();

                r.Text = "Таблица";
                r.Bold = 20;
                doc.Sections.Add(r);

                Microsoft.Office.Interop.Word.Table t = doc.Tables.Add(r, Names1.Count + Names2.Count + Names3.Count + 1, 4);
                t.Borders.Enable = 1;
                foreach (Row row in t.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.RowIndex == 1 && cell.ColumnIndex == 1)
                        {
                            cell.Range.Text = "ФИО";
                            cell.Range.Bold = 1;
                        }
                        if (cell.RowIndex == 1 && cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = "Компания";
                            cell.Range.Bold = 1;
                        }
                        if (cell.RowIndex == 1 && cell.ColumnIndex == 3)
                        {
                            cell.Range.Text = "Общий доход";
                            cell.Range.Bold = 1;
                        }
                        if (cell.RowIndex == 1 && cell.ColumnIndex == 4)
                        {
                            cell.Range.Text = "Период работы";
                            cell.Range.Bold = 1;
                        }
                        if (cell.RowIndex > 1 && cell.ColumnIndex == 1)
                        {
                            cell.Range.Text = Allnames[cell.RowIndex - 2];
                        }
                        if (cell.RowIndex > 1 && cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = Allcompanyes[cell.RowIndex - 2];
                        }
                        if (cell.RowIndex > 1 && cell.ColumnIndex == 3)
                        {
                            cell.Range.Text = Allsalaryes[cell.RowIndex - 2].ToString();
                        }
                        if (cell.RowIndex > 1 && cell.ColumnIndex == 4)
                        {
                            cell.Range.Text = (Allenddates[cell.RowIndex - 2] - Allstartdates[cell.RowIndex - 2]).ToString();
                        }
                    }
                }

                doc.Sections.Add(r);
                doc.InlineShapes.AddPicture(openFileDialog.FileName);

                doc.SaveAs2(@"C:\Users\andre\Desktop\Doc.docx");
                doc.Close();
                app.Quit();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Add_Employee add_Employee = new Add_Employee();
            add_Employee.Show();
        }
    }
}  