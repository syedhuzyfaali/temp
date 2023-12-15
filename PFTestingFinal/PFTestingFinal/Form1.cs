using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PFTestingFinal
{
    public partial class Form1 : Form
    {

        static string path = @"C:\Users\Huzyfa\source\repos\PFTestingFinal\PFTestingFinal\bin\Debug\stdDatabase.txt";
        List<List<String>> data = new List<List<String>>();
        int counter = 0;
        int refreshCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("ID", 80);
            listView1.Columns.Add("Name", 120);
            
        }

        private void add_Click(object sender, EventArgs e)
        {
            refreshCounter = 0;
            data.Add(new List<String>());
            data[counter].Add(textBox1.Text);
            data[counter].Add(textBox2.Text);

            ListViewItem items = new ListViewItem(data[counter][0]);
            items.SubItems.Add(data[counter][1]);
            listView1.Items.Add(items);
            counter++;

            textBox1.Clear();
            textBox2.Clear();



            FileStream stream = new FileStream("stdDatabase.txt", FileMode.Append, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(stream))
            {


                for (int j = 0; j < counter; j++)
                {
                    foreach (var item in data[j])
                    {
                        writer.Write(item + ",");
                    }


                    writer.WriteLine("");
                }
            }
            stream.Close();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();


            if (refreshCounter == 0)
            {
                List<List<String>> read = new List<List<String>>();
                int readCounter = 0;

                int TotalRows = File.ReadAllLines(path).Length;
                //Students = new string[TotalRows, 4];
                string line = "";
                StreamReader sr = new StreamReader(path);
                int Row = 0;

                while ((line = sr.ReadLine()) != null)

                {
                    read.Add(new List<String>());

                    string[] temp = line.Split(',');
                    for (int i = 0; i < temp.Length; i++)
                    {
                        read[readCounter].Add(temp[i]);
                        //Students[Row, i] = temp[i];
                    }
                    Row++;
                    readCounter++;
                }
                
                sr.Close();


                for (int i = 0; i < readCounter; i++)
                {


                   

                    ListViewItem stud = new ListViewItem(read[i][0]);
                    stud.SubItems.Add(read[i][1]);
                    listView1.Items.Add(stud);


                }

                refreshCounter++;
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}
