using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string ClassICRAW = readAllLine[i];
                    string[] ClassICSplited = ClassICRAW.Split(',');
                    ClassIC classIC = new ClassIC(ClassICSplited[0], ClassICSplited[1], ClassICSplited[2], ClassICSplited[3]);
                    addDataToGridView("name", "sum", "income");
                }
            }
            void addDataToGridView(string name, string sum, string income)
            {
                this.dataGridView1.Rows.Add(new string[] { name, sum, income });
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(*.csv)|*.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += columnNames;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                            }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxName.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBoxSum.Text;
            dataGridView1.Rows[n].Cells[2].Value = comboBoxincome.Text;

            textBoxName.Text = " ";
            textBoxSum.Text = " ";
            comboBoxincome.Text = " ";
        }
    }
}
