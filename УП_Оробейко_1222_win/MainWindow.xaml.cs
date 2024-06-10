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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        SqlDataAdapter adapter;
        DataTable DeliveryTable;
        SqlConnection connection = null;
        string connectionString;
        private void Continue_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Check.IsChecked == true)
            {
                if (ServerName.Text != "" && ServerLI.Text != "" && ServerPSWD.Text != "")
                {
                    connectionString = $"Data source={ServerName.Text};Initial Catalog=УП_Оробейко_1222;Integrated Security=false;User ID={ServerLI.Text}; Password={ServerPSWD.Text}";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.OpenAsync();
                        Console.WriteLine("Подключение открыто");
                    }
                    Text1.Visibility = Visibility.Visible;
                    Con_btn.Visibility = Visibility.Visible;
                    Add_btn.Visibility = Visibility.Visible;
                    Del_btn.Visibility = Visibility.Visible;
                    Upd_btn.Visibility = Visibility.Visible;
                    Select_of_table.Visibility = Visibility.Visible;
                    MainDG.Visibility = Visibility.Visible;

                    Text2.Visibility = Visibility.Hidden;
                    Text3.Visibility = Visibility.Hidden;
                    Text4.Visibility = Visibility.Hidden;
                    ServerName.Visibility = Visibility.Hidden;
                    ServerPSWD.Visibility = Visibility.Hidden;
                    ServerLI.Visibility = Visibility.Hidden;
                    Continue_btn.Visibility = Visibility.Hidden;
                    Check.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Введите данные");
                }
            }
            else
            {
                if (ServerName.Text != "")
                {
                    //DESKTOP-L1AAI25
                    connectionString = $"Data source={ServerName.Text};Initial Catalog=УП_Оробейко_1222;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.OpenAsync();
                        Console.WriteLine("Подключение открыто");
                    }
                    Text1.Visibility = Visibility.Visible;
                    Con_btn.Visibility = Visibility.Visible;
                    Add_btn.Visibility = Visibility.Visible;
                    Del_btn.Visibility = Visibility.Visible;
                    Upd_btn.Visibility = Visibility.Visible;
                    Select_of_table.Visibility = Visibility.Visible;
                    MainDG.Visibility = Visibility.Visible;

                    Text2.Visibility = Visibility.Hidden;
                    Text3.Visibility = Visibility.Hidden;
                    Text4.Visibility = Visibility.Hidden;
                    ServerName.Visibility = Visibility.Hidden;
                    ServerPSWD.Visibility = Visibility.Hidden;
                    ServerLI.Visibility = Visibility.Hidden;
                    Continue_btn.Visibility = Visibility.Hidden;
                    Check.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Введите данные");
                }
            }
        }

        int select = -1;
        string sql;
        private void Con_btn_Click(object sender, RoutedEventArgs e)
        {
            DeliveryTable = new DataTable();
            select = Select_of_table.SelectedIndex;
            MainDG.Columns.Clear();

            switch (select)
            {
                case 0:
                    sql = "SELECT * FROM Customers";

                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Customer id",
                        Binding = new Binding("CustomerId")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Customer name",
                        Binding = new Binding("CustomerName")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Customer surname",
                        Binding = new Binding("CustomerSurName")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Customer sex",
                        Binding = new Binding("CustomerSex")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Customer age",
                        Binding = new Binding("CustomersAge")
                    });
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(sql, connection);
                        adapter = new SqlDataAdapter(command);

                        // установка команды на добавление для вызова хранимой процедуры
                        adapter.InsertCommand = new SqlCommand("sp_InsertPhone", connection);
                        adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.Int, 0, "CustomerId"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 30, "CustomerName"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@CustomerSurName", SqlDbType.NVarChar, 30, "CustomerSurName"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@CustomerSex", SqlDbType.NVarChar, 10, "CustomerSex"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@CustomersAge", SqlDbType.Int, 0, "CustomersAge"));

                        connection.Open();
                        adapter.Fill(DeliveryTable);
                        MainDG.ItemsSource = DeliveryTable.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (connection != null)
                            connection.Close();
                    }
                    break;
                case 1:
                    sql = "SELECT * FROM Products";

                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Product id",
                        Binding = new Binding("ProductId")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Product category",
                        Binding = new Binding("ProductCategory")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Product name",
                        Binding = new Binding("ProductName")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Product price",
                        Binding = new Binding("ProductPrice")
                    });
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(sql, connection);
                        adapter = new SqlDataAdapter(command);

                        // установка команды на добавление для вызова хранимой процедуры
                        adapter.InsertCommand = new SqlCommand("sp_InsertPhone", connection);
                        adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int, 0, "ProductId"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductCategory", SqlDbType.NVarChar, 30, "ProductCategory"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar, 30, "ProductName"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductPrice", SqlDbType.NVarChar, 30, "ProductPrice"));

                        connection.Open();
                        adapter.Fill(DeliveryTable);
                        MainDG.ItemsSource = DeliveryTable.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (connection != null)
                            connection.Close();
                    }
                    break;
                case 2:
                    sql = "SELECT * FROM Delivery";

                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Delivery id",
                        Binding = new Binding("DeliveryID")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Delivery name",
                        Binding = new Binding("DeliveryName")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Delivery surname",
                        Binding = new Binding("DeliverySurName")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Delivery sex",
                        Binding = new Binding("DeliverySex")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Delivery age",
                        Binding = new Binding("DeliveryAge")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Delivery salary",
                        Binding = new Binding("DeliverySalary")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Delivery beginning of work",
                        Binding = new Binding("Delivery_beginning_of_work")
                    });
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(sql, connection);
                        adapter = new SqlDataAdapter(command);

                        // установка команды на добавление для вызова хранимой процедуры
                        adapter.InsertCommand = new SqlCommand("sp_InsertPhone", connection);
                        adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@DeliveryID", SqlDbType.Int, 0, "DeliveryID"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@DeliveryName", SqlDbType.NVarChar, 30, "DeliveryName"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@DeliverySurName", SqlDbType.NVarChar, 30, "DeliverySurName"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@DeliverySex", SqlDbType.NVarChar, 10, "DeliverySex"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@DeliveryAge", SqlDbType.Int, 0, "DeliveryAge"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@DeliverySalary", SqlDbType.Float, 0, "DeliverySalary"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@Delivery_beginning_of_work", SqlDbType.Date, 0, "Delivery_beginning_of_work"));

                        connection.Open();
                        adapter.Fill(DeliveryTable);
                        MainDG.ItemsSource = DeliveryTable.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (connection != null)
                            connection.Close();
                    }
                    break;
                case 3:
                    sql = "SELECT * FROM Order_details";

                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Orderdetails id",
                        Binding = new Binding("Order_detailsID")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Customer id",
                        Binding = new Binding("CustomerId")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Product id",
                        Binding = new Binding("ProductId")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Products count",
                        Binding = new Binding("Products_count")
                    });
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(sql, connection);
                        adapter = new SqlDataAdapter(command);

                        // установка команды на добавление для вызова хранимой процедуры
                        adapter.InsertCommand = new SqlCommand("sp_InsertPhone", connection);
                        adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int, 0, "Order_detailsID"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductCategory", SqlDbType.Int, 0, "CustomerId"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.Int, 0, "ProductId"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.Int, 0, "Products_count"));

                        connection.Open();
                        adapter.Fill(DeliveryTable);
                        MainDG.ItemsSource = DeliveryTable.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (connection != null)
                            connection.Close();
                    }
                    break;
                case 4:
                    sql = "SELECT * FROM Orders";

                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Order id",
                        Binding = new Binding("OrderId")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Orderdetails id",
                        Binding = new Binding("Order_detailsID")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Delivery id",
                        Binding = new Binding("DeliveryID")
                    });
                    MainDG.Columns.Add(new DataGridTextColumn
                    {
                        Header = "Products count",
                        Binding = new Binding("DeliveryStatus")
                    });
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(sql, connection);
                        adapter = new SqlDataAdapter(command);

                        // установка команды на добавление для вызова хранимой процедуры
                        adapter.InsertCommand = new SqlCommand("sp_InsertPhone", connection);
                        adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int, 0, "OrderId"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductCategory", SqlDbType.Int, 0, "Order_detailsID"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.Int, 0, "DeliveryID"));
                        adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar, 30, "DeliveryStatus"));

                        connection.Open();
                        adapter.Fill(DeliveryTable);
                        MainDG.ItemsSource = DeliveryTable.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (connection != null)
                            connection.Close();
                    }
                    break;
                case -1:
                    MessageBox.Show("Вы не выбрали таблицу");
                    break;
            }
        }
        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (select != -1)
            {
                Window window = new GRUD(1, select, connectionString);
                window.Show();
            }
            else
            {
                MessageBox.Show("Вы не выбрали таблицу");
            }
        }
        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (select != -1)
            {
                Window window = new GRUD(2, select, connectionString);
                window.Show();
            }
            else
            {
                MessageBox.Show("Вы не выбрали таблицу");
            }
        }
        private void Upd_btn_Click(object sender, RoutedEventArgs e)
        {
            if (select != -1)
            {
                Window window = new GRUD(3, select, connectionString);
                window.Show();
            }
            else
            {
                MessageBox.Show("Вы не выбрали таблицу");
            }
        }

        private void Check_Checked(object sender, RoutedEventArgs e)
        {
            Text3.Visibility = Visibility.Visible;
            Text4.Visibility = Visibility.Visible;
            ServerPSWD.Visibility = Visibility.Visible;
            ServerLI.Visibility = Visibility.Visible;
        }
        private void Check_Unchecked(object sender, RoutedEventArgs e)
        {
            Text3.Visibility = Visibility.Hidden;
            Text4.Visibility = Visibility.Hidden;
            ServerPSWD.Visibility = Visibility.Hidden;
            ServerLI.Visibility = Visibility.Hidden;
        }
    }
}