using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace УП_Оробейко_1222_win
{
    /// <summary>
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable DeliveryTable;
        SqlConnection connection = null;
        readonly int select_special_for_update;
        string sql;
        public Update(int select, string connstr)
        {
            InitializeComponent();
            select_special_for_update = select;
            connectionString = connstr;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
            }
            switch (select)
            {
                case 0:
                    TextColumID.Text = "Customer id";
                    TextColum1.Text = "Customer name";
                    TextColum2.Text = "Customer surname";
                    TextColum3.Text = "Customer sex";
                    TextColum4.Text = "Customer age";
                    Colum5.Visibility = Visibility.Hidden;
                    TextColum5.Visibility = Visibility.Hidden;
                    Colum6.Visibility = Visibility.Hidden;
                    TextColum6.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    TextColumID.Text = "Product id";
                    TextColum1.Text = "Product category";
                    TextColum2.Text = "Product name";
                    TextColum3.Text = "Product price";
                    Colum4.Visibility = Visibility.Hidden;
                    TextColum4.Visibility = Visibility.Hidden;
                    Colum5.Visibility = Visibility.Hidden;
                    TextColum5.Visibility = Visibility.Hidden;
                    Colum6.Visibility = Visibility.Hidden;
                    TextColum6.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    TextColumID.Text = "Delivery id";
                    TextColum1.Text = "Delivery name";
                    TextColum2.Text = "Delivery surname";
                    TextColum3.Text = "Delivery sex";
                    TextColum4.Text = "Delivery age";
                    TextColum5.Text = "Delivery salary";
                    TextColum6.Text = "Delivery beginning of work";
                    break;
                case 3:
                    TextColumID.Text = "Orderdetails id";
                    TextColum1.Text = "Customer id";
                    TextColum2.Text = "Product id";
                    TextColum3.Text = "Products count";
                    Colum4.Visibility = Visibility.Hidden;
                    TextColum4.Visibility = Visibility.Hidden;
                    Colum5.Visibility = Visibility.Hidden;
                    TextColum5.Visibility = Visibility.Hidden;
                    Colum6.Visibility = Visibility.Hidden;
                    TextColum6.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    TextColumID.Text = "Order id";
                    TextColum1.Text = "Orderdetails id";
                    TextColum2.Text = "Delivery id";
                    TextColum3.Text = "Products count";
                    Colum4.Visibility = Visibility.Hidden;
                    TextColum4.Visibility = Visibility.Hidden;
                    Colum5.Visibility = Visibility.Hidden;
                    TextColum5.Visibility = Visibility.Hidden;
                    Colum6.Visibility = Visibility.Hidden;
                    TextColum6.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            switch (select_special_for_update)
            {
                case 0:
                    if (Colum1.Text != "" && Colum2.Text != "" && Colum3.Text != ""
                && Colum4.Text != "" && ColumID.Text != "")
                    {
                        sql = $"update Customers " +
                $"set CustomerName = ('{Colum1.Text}'), CustomerSurName = ('{Colum2.Text}'), CustomerSex = ('{Colum3.Text}'), CustomersAge = ({Colum4.Text})" +
                $"where CustomerId = ({ColumID.Text})";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные обновлены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("не все поля заполнены");
                    }
                    break;
                case 1:
                    if (Colum1.Text != "" && Colum2.Text != "" && Colum3.Text != "" && ColumID.Text != "")
                    {
                        sql = $"update Products " +
                $"set ProductCategory = ('{Colum1.Text}'), ProductName = ('{Colum2.Text}'), ProductPrice = ({Colum3.Text})" +
                $"where ProductId = ({ColumID.Text})";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные обновлены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("не все поля заполнены");
                    }
                    break;
                case 2:
                    if (Colum1.Text != "" && Colum2.Text != "" && Colum3.Text != ""
                && Colum4.Text != "" && Colum5.Text != "" && Colum6.Text != "" && ColumID.Text != "")
                    {
                        sql = $"update Delivery " +
                $"set DeliveryName = ('{Colum1.Text}'), DeliverySurName = ('{Colum2.Text}'), DeliverySex = ('{Colum3.Text}')," +
                $"DeliveryAge = ({Colum4.Text}), DeliverySalary = ({Colum5.Text}), Delivery_beginning_of_work = ('{Colum6.Text}') " +
                $"where DeliveryID = ({ColumID.Text})";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные обновлены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("не все поля заполнены");
                    }
                    break;
                case 3:
                    if (Colum1.Text != "" && Colum2.Text != "" && Colum3.Text != "" && ColumID.Text != "")
                    {
                        sql = $"update Order_details " +
                $"set CustomerId = ({Colum1.Text}), ProductId = ({Colum2.Text}), Products_count = ({Colum3.Text})" +
                $"where Order_detailsID = ({ColumID.Text})";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные обновлены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("не все поля заполнены");
                    }
                    break;
                case 4:
                    if (Colum1.Text != "" && Colum2.Text != "" && Colum3.Text != "" && ColumID.Text != "")
                    {
                        sql = $"update Orders " +
                $"set Order_detailsID = ({Colum1.Text}), DeliveryID = ({Colum2.Text}), DeliveryStatus = ('{Colum3.Text}')" +
                $"where OrderId = ({ColumID.Text})";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные обновлены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("не все поля заполнены");
                    }
                    break;
            }
        }
    }
}
