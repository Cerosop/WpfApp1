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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


//test
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class Node
    {
        public int v;
        public char c;
        public bool is_v = true;
        public Node l = null, r = null, p = null;
        public string Pre(Node root)
        {
            if (root == null)
                return "";
            if (root.is_v)
                return "" + root.v.ToString() + Pre(root.l) + Pre(root.r);
            else
                return "" + root.c + Pre(root.l) + Pre(root.r);
        }
        public string Post(Node root)
        {
            if (root == null)
                return "";
            if (root.is_v)
                return "" + Post(root.l) + Post(root.r) + root.v.ToString();
            else
                return "" + Post(root.l) + Post(root.r) + root.c;
        }

        public int Prec(Node root)
        {
            if (root.is_v)
                return root.v;
            else
            {
                if(root.c == '+')
                    return Prec(root.l) + Prec(root.r);
                if (root.c == '-')
                    return Prec(root.l) - Prec(root.r);
                if (root.c == '*')
                    return Prec(root.l) * Prec(root.r);
                if (root.c == '/')
                    return Prec(root.l) / Prec(root.r);
            }
            return 0;
        }
    }

    public partial class MainWindow : Window
    {
        bool res;
        public MainWindow()
        {
            res = true;
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "1";
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "2";
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "3";
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "4";
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "5";
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "6";
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "7";
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "8";
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "9";
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = testblock1;
            if (res)
            {
                textBlock.Text = "";
                res = false;
            }
            textBlock.Text += "0";
        }
        private void Button_Click_p(object sender, RoutedEventArgs e)
        {
            res = false;
            TextBlock textBlock = testblock1;
            textBlock.Text += "+";
        }
        private void Button_Click_m(object sender, RoutedEventArgs e)
        {
            res = false;
            TextBlock textBlock = testblock1;
            textBlock.Text += "-";
        }
        private void Button_Click_t(object sender, RoutedEventArgs e)
        {
            res = false;
            TextBlock textBlock = testblock1;
            textBlock.Text += "*";
        }
        private void Button_Click_d(object sender, RoutedEventArgs e)
        {
            res = false;
            TextBlock textBlock = testblock1;
            textBlock.Text += "/";
        }
        private void Button_Click_e(object sender, RoutedEventArgs e)
        {
            res = true;
            TextBlock textBlock = testblock1;
            String s = textBlock.Text;
            int tmp = 0;
            Node root = new Node();
            Node cur = root;
            
            foreach (char c in s)
            {
                if(c < '0' || c > '9')
                {
                    Node p = new Node();
                    p.is_v = false;
                    p.c = c;
                    
                    if (cur.l == null)
                    {
                        Node n = new Node();
                        n.v = tmp;
                        n.p = p;
                        p.l = n;
                        tmp = 0;
                        root = p;
                        cur = root;
                    }
                    else if((cur.c == '+' || cur.c == '-') && (c == '*' || c == '/'))
                    {
                        Node n = new Node();
                        n.v = tmp;
                        n.p = p;
                        p.l = n;
                        tmp = 0;
                        cur.r = p;
                        p.p = cur;
                        cur = p;
                    }
                    else
                    {
                        Node n = new Node();
                        n.v = tmp;
                        n.p = cur;
                        cur.r = n;
                        tmp = 0;
                        if(c == '+' || c == '-')
                        {
                            p.l = root;
                            root.p = p;
                            root = p;
                            cur = p;
                        }
                        else
                        {
                            while(cur != null && (cur.c == '*' || cur.c == '/'))
                            {
                                cur = cur.p;
                            }
                            if(cur == null)
                            {
                                p.l = root;
                                root.p = p;
                                root = p;
                                cur = p;
                            }
                            else
                            {
                                p.l = cur.r;
                                cur.r.p = p;
                                p.p = cur;
                                cur.r = p;
                                cur = p;
                            }
                        }

                    }
                }
                else
                {
                    tmp *= 10;
                    tmp += c - '0';
                }
            }
            Node nu = new Node();
            nu.v = tmp;
            nu.p = cur;
            cur.r = nu;
            tmp = 0;
            TextBlock pret = pre;
            pret.Text = root.Pre(root);

            TextBlock postt = post;
            postt.Text = root.Post(root);

            int ans = root.Prec(root);
            TextBlock dect = dec;
            dect.Text = ans.ToString();

            TextBlock bint = bin;
            bint.Text = Convert.ToString(ans, 2);
        }
        private void Button_Click_c(object sender, RoutedEventArgs e)
        {
            res = false;
            TextBlock textBlock = testblock1;
            textBlock.Text = "";
        }
        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            bool b = true;
            string connectionString = "server=127.0.0.1;user=root;password=;database=calculatordata;";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    TextBlock textBlock = pre;
                    string s = textBlock.Text;
                    string sqlQuery = "SELECT * FROM table1 WHERE prefix = @S;";
                    
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@S", s);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("算式已存在");
                    }
                    else
                    {
                        MessageBox.Show("insert 成功");
                        b = false;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                testblock1.Text = ex.Message;
            }
            if (!b)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string insertQuery = "INSERT INTO table1 (infix, prefix, postfix, deci, bin) VALUES (@NewIn, @NewPre, @NewPost, @NewDec, @NewBin);";
                        MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                        cmd.Parameters.AddWithValue("@NewBin", bin.Text);
                        cmd.Parameters.AddWithValue("@NewDec", dec.Text);
                        cmd.Parameters.AddWithValue("@NewIn", testblock1.Text);
                        cmd.Parameters.AddWithValue("@NewPre", pre.Text);
                        cmd.Parameters.AddWithValue("@NewPost", post.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    testblock1.Text = ex.Message;
                }
            }
            
        }
        private void btn_query_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }
    }
}
