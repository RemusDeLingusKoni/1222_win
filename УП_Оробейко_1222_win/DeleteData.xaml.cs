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
    /// Логика взаимодействия для DeleteData.xaml
    /// </summary>
    public partial class DeleteData : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable DeliveryTable;
        SqlConnection connection = null;
        readonly int select_special_for_delete;
        string sql;
        public DeleteData(int select, string connstr)
        {
            InitializeComponent();
            select_special_for_delete = select;
            connectionString = connstr;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
            }
        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Id.Text != "")
            {
                switch (select_special_for_delete)
                {
                    case 0:
                        sql = $"delete from Customers where CustomerId = ('{Id.Text}')";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные удалены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                        break;
                    case 1:
                        sql = $"delete from Products where ProductId = ('{Id.Text}')";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные удалены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                        break;
                    case 2:
                        sql = $"delete from Delivery where DeliveryID = ('{Id.Text}')";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные удалены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                        break;
                    case 3:
                        sql = $"delete from Order_details where Order_detailsID = ('{Id.Text}')";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные удалены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                        break;
                    case 4:
                        sql = $"delete from Orders where OrderId = ('{Id.Text}')";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные удалены");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            connection?.Close();
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("поля не заполнены");
            }
        }
    }
}
