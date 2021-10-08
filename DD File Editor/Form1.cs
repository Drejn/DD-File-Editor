using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;


namespace DD_File_Editor
{
    public partial class Form1 : Form
    {
        dynamic MapContent;

        public Form1()
        {
            InitializeComponent();
        }

        private void b_load_dd_file_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Dungeondraft File (*.dungeondraft_map)|*.dungeondraft_map";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                l_dd_file_path.Text = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(l_dd_file_path.Text);
                string json = sr.ReadToEnd();
                MapContent = JsonConvert.DeserializeObject(json);
                foreach(var node in MapContent)
                {
                    Console.WriteLine(node);
                }
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
