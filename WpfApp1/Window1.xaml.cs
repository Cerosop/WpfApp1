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
using MySql.Data.MySqlClient;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {
            ListBox listBox1 = listbox1;
            string connectionString = "server=localhost;user=root;password=;database=calculatordata;";
            listbox1.Items.Clear();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM table1;";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String id = reader.GetString("ID");
                            string infix = reader.GetString("infix");
                            string prefix = reader.GetString("prefix");
                            string postfix = reader.GetString("postfix");
                            string dec = reader.GetString("deci");
                            string bin = reader.GetString("bin");
                            listBox1.Items.Add(id + "    " + infix + "    " + prefix
                                                + "    " + postfix + "    " + dec + "    " + bin);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                TextBlock textBlock = testblock1;
                textBlock.Text = "error";
            }
        }
        private void btn_delete_Click(object sender, object e)
        {
            string connectionString = "server=127.0.0.1;user=root;password=;database=calculatordata;";
            TextBlock textBlock = testblock1;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    int recordIdToDelete = 0;
                    ListBox listBox = listbox1;
                    if(listBox.SelectedItem == null)
                        textBlock.Text = "no selected item";
                    else
                    {
                        foreach (char c in listBox.SelectedItem.ToString())
                        {
                            if (c == ' ')
                                break;
                            recordIdToDelete *= 10;
                            recordIdToDelete += (c - '0');
                        }
                        string deleteQuery = "DELETE FROM table1 WHERE ID = @RecordIdToDelete;";

                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@RecordIdToDelete", recordIdToDelete);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                                textBlock.Text = "success";
                            else
                                textBlock.Text = "fail";
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                textBlock.Text = ex.Message;
            }

            ListBox listBox1 = listbox1;
            listbox1.Items.Clear();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM table1;";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String id = reader.GetString("ID");
                            string infix = reader.GetString("infix");
                            string prefix = reader.GetString("prefix");
                            string postfix = reader.GetString("postfix");
                            string dec = reader.GetString("deci");
                            string bin = reader.GetString("bin");
                            listBox1.Items.Add(id + "    " + infix + "    " + prefix
                                                + "    " + postfix + "    " + dec + "    " + bin);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                textBlock.Text = "error";
            }
        }
    }
}
