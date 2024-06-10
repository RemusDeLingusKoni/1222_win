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

namespace УП_Оробейко_1222_win
{
    /// <summary>
    /// Логика взаимодействия для GRUD.xaml
    /// </summary>
    public partial class GRUD : Window
    {
        public GRUD(int x, int select, string connstr)
        {
            InitializeComponent();
            switch (x)
            {
                case 1:
                    AddData addData = new AddData(select, connstr);
                    MainFrame.Content = addData;
                    break;
                case 2:
                    DeleteData deleteData = new DeleteData(select, connstr);
                    MainFrame.Content = deleteData;
                    break;
                case 3:
                    Update upData = new Update(select, connstr);
                    MainFrame.Content = upData;
                    break;
            }
        }
    }
}