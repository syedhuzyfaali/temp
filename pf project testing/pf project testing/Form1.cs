using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;

namespace pf_project_testing
{
    public partial class Form1 : Form
    {
        List<List<String>> data = new List<List<String>>();
        List<List<String>> read= new List<List<String>>();
        int readCounter = 0;
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("ID", 80);
            listView1.Columns.Add("Name", 120);
            listView1.Columns.Add("Class", 120);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<List<String>> data = new List<List<String>>();
           




            //FileStream istream = new FileStream("reading.txt", FileMode.Create, FileAccess.Write);
            //using (StreamWriter writer = new StreamWriter(istream))
            //{
            //    //foreach (string item in data[0])
            //    //{
            //    //    writer.Write(item);
            //    //}

            //    for (int j = 0; j < counter; j++)
            //    {
            //        foreach (var item in read[j])
            //        {
            //            writer.Write(item + ",");
            //        }


            //        writer.WriteLine("\n");
            //    }
            //}
            //istream.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            data.Add(new List<String>());
            data[counter].Add(textBox1.Text);
            data[counter].Add(textBox2.Text);
            data[counter].Add(textBox3.Text);

            //ListViewItem items = new ListViewItem(data[counter][0]);
            //items.SubItems.Add(data[counter][1]);
            //items.SubItems.Add(data[counter][2]);
            counter++;
            //listView1.Items.Add(items);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();



            FileStream stream = new FileStream("testing.txt", FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(stream))
            {


                for (int j = 0; j < counter; j++)
                {
                    foreach (var item in data[j])
                    {
                        writer.Write(item + ",");
                    }


                    writer.WriteLine("\n");
                }
            }
            stream.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            TextReader stream = new StreamReader("testing.txt");
            string line = "";


            using (TextReader reader = new StringReader(stream)) 
            { 
                while ((line = reader.ReadLine()) != null)
                {
                    string[] temp = line.Split(',');
                    for (int i = 0; i < temp.Length; i++)
                    {
                        read[readCounter][i] = temp[i];
                    }
                    readCounter++;
                }
            }





        }
    }
}
