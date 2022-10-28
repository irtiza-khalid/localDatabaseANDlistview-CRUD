using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace localDatabaseANDlistview_CRUD
{


    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
        SqlDataAdapter adapter;
        public static ListView it=new ListView();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\SWishHy\source\repos\localDatabaseANDlistview CRUD\localDatabaseANDlistview CRUD\entry.mdf"";Integrated Security=True");
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm=new Form2();
            fm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String r = "";
            if(radioButton1.Checked)
            {
                r = "male";
            }
            else
            {
                r = "female";
            }
            
            ListViewItem item = new ListViewItem(textBox1.Text +" "+ textBox2.Text);
            item.SubItems.Add(textBox4.Text);
            item.SubItems.Add(r);
            item.SubItems.Add(textBox3.Text);
            item.SubItems.Add(textBox5.Text);
            item.SubItems.Add(textBox6.Text);
          
            it.Items.Add(item);
            MessageBox.Show("record save");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();




        }

        private void button3_Click(object sender, EventArgs e)
        {
            String s = textBox7.Text;
           
            foreach (ListViewItem item in it.Items)
            {
                if (item.SubItems[1].Text == s)
                {
                    String r = "";
                    if (radioButton1.Checked)
                    {
                        r = "male";
                    }
                    else
                    {
                        r = "female";
                    }
                    item.SubItems[0].Text =textBox1.Text+" "+textBox2.Text;
                    item.SubItems[1].Text = textBox4.Text;
                    item.SubItems[2].Text = r;
                    item.SubItems[3].Text = textBox3.Text;
                    item.SubItems[4].Text = textBox5.Text;
                    item.SubItems[5].Text = textBox6.Text;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String s = textBox7.Text;
            foreach (ListViewItem item in it.Items)
            {
                if (item.SubItems[1].Text == s)
                {
                    textBox1.Text = item.SubItems[0].Text;
                    textBox2.Text = item.SubItems[0].Text;
                    textBox3.Text = item.SubItems[3].Text;
                    textBox4.Text = item.SubItems[1].Text;

                    textBox5.Text = item.SubItems[4].Text;
                    textBox6.Text = item.SubItems[5].Text;



               }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String r = "";
            if (radioButton1.Checked)
            {
                r = "male";
            }
            else
            {
                r = "female";
            }
            String QUERY = "Insert into info"+"(Fullname, Contact, Gender,Address,Warehouse,Warehousename)"+ " values(@Fullname, @Contact, @Gender,@Address,@Warehouse,@Warehousename)";
SqlCommand cmd = new SqlCommand(QUERY, conn);

            cmd.Parameters.AddWithValue("@Fullname", textBox1.Text + textBox2.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Gender", r);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Warehouse", textBox5.Text);
            cmd.Parameters.AddWithValue("@Warehousename", textBox4.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Successfully Saved");

        }
    }
}
