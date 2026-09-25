using System.Windows;
using System.Windows.Controls;
using LibMas;
using Lib_2;
using MassiveDataTable;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        int[] mas;
        int Count;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            int comp = Proizv.Vozvrat(mas);
            if (comp != -1)
                Answer.Text = comp.ToString();
            else
                Answer.Text = "Ошибка при попытке расчета";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mas = Mass.Clear(mas);
                dataGrid.ItemsSource = null;
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Count = Convert.ToInt32(NumberOfNumbers.Text);
                mas = Mass.Fill(Count);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            catch
            {
                MessageBox.Show("Введите число n, но не 0");
            }
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Count = Convert.ToInt32(NumberOfNumbers.Text);
                mas = new int[Count];
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            catch
            {
                MessageBox.Show("Введите число n,но не 0)");
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = e.Column.DisplayIndex;
            int indexRow = e.Row.GetIndex();
            if (mas[indexColumn] != 0)
                mas[indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
            else
                MessageBox.Show("Введите число n, но не 0)");
        }

        private void NumberOfNumbers_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Count = Convert.ToInt32(NumberOfNumbers.Text);
            }
            catch
            {
            }
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сделал: Антипов А.А.\nВвести n целых чисел(>0 или <0). Найти произведение чисел. Результат вывести на экран.\nВариант №2");
        }
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            mas = Mass.Open(mas);
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }
        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            Mass.Save(mas);
        }
    }
}