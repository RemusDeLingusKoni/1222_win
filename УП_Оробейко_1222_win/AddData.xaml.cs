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
using System.Runtime.Remoting.Contexts;

namespace УП_Оробейко_1222_win
{
    /// <summary>
    /// Логика взаимодействия для AddData.xaml
    /// </summary>
    public partial class AddData : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable DeliveryTable;
        SqlConnection connection = null;
        readonly int select_special_for_add;
        string sql;
        public AddData(int select, string connstr)
        {
            InitializeComponent();
            select_special_for_add = select;
            connectionString = connstr;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
            }
            switch (select)
            {
                case 0:
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
                    TextColum1.Text = "Delivery name";
                    TextColum2.Text = "Delivery surname";
                    TextColum3.Text = "Delivery sex";
                    TextColum4.Text = "Delivery age";
                    TextColum5.Text = "Delivery salary";
                    TextColum6.Text = "Delivery beginning of work";
                    break;
                case 3:
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

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            switch (select_special_for_add)
            {
                case 0:
                    if (Colum1.Text != "" && Colum2.Text != "" && Colum3.Text != ""
                && Colum4.Text != "")
                    {
                        sql = $"INSERT INTO Customers VALUES ('{Colum1.Text}','{Colum2.Text}','{Colum3.Text}','{Colum4.Text}')";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные добавлены");
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
                    if (Colum1.Text != "" && Colum2.Text != "" && Colum3.Text != "")
                    {
                        sql = $"INSERT INTO Products VALUES ('{Colum1.Text}','{Colum2.Text}',{Colum3.Text})";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные добавлены");
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
                && Colum4.Text != "" && Colum5.Text != "" && Colum6.Text != "")
                    {
                        sql = $"INSERT INTO Delivery VALUES ('{Colum1.Text}','{Colum2.Text}','{Colum3.Text}',{Colum4.Text},{Colum5.Text},'{Colum6.Text}')";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные добавлены");
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
                    if (Colum1.Text != "" && Colum2.Text != "" && Colum3.Text != "")
                    {
                        sql = $"INSERT INTO Order_details VALUES ({Colum1.Text},{Colum2.Text},{Colum3.Text})";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные добавлены");
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
                    if (Colum1.Text != "" && Colum2.Text != "" && Colum3.Text != "")
                    {
                        sql = $"INSERT INTO Orders VALUES ({Colum1.Text},{Colum2.Text},'{Colum3.Text}')";
                        DeliveryTable = new DataTable();

                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            SqlCommand command = new SqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            adapter = new SqlDataAdapter(command);
                            MessageBox.Show("Данные добавлены");
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
