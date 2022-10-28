using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace localDatabaseANDlistview_CRUD
{
    public partial class Form2 : Form
    {
        public static string s;
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
        public static string SetValueForText6 = "";
        Form1 f1 = new Form1();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            s=textBox2.Text;
            listView1.View = View.Details;
            // Add a column with width 20 and left alignment.
            listView1.FullRowSelect = true;

            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in Form1.it.Items)
            {
                listView1.Items.Add((ListViewItem)item.Clone());
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (ListViewItem item in Form1.it.Items)
            {
                string[] str = item.SubItems[0].Text.Split(' ');
                if(str.Length >= 2)
                {
                    if (str[1].ToUpper()==textBox1.Text.ToUpper())
                    {
                        listView1.Items.Add((ListViewItem)item.Clone());

                    }
                }
            }
        }
        
private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            

            }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            foreach (ListViewItem item in Form1.it.Items)
            {
                if (item.SubItems[1].Text == s )
                {
        SetValueForText1 = item.SubItems[0].Text;
        SetValueForText2 = item.SubItems[1].Text;
        SetValueForText3 = item.SubItems[2].Text;
        SetValueForText4 = item.SubItems[3].Text;
        SetValueForText5 = item.SubItems[4].Text;
        SetValueForText6 = item.SubItems[5].Text;


                    Form1 fm = new Form1();
                    fm.Show();
                    this.Hide();

                }
        }
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
