using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Зав3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заповниит всі поля", "Помилка");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = comboBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[4].Value = comboBox1.Text;
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = comboBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[4].Value = comboBox1.Text;
            }
            else
            {
                MessageBox.Show("Виберіть строку для редагування.", "Помилка.");
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Виберіть строку для видалення.", "Помилка.");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            numericUpDown1.Value = n;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Name");
                dt.Columns.Add("Last");
                dt.Columns.Add("Gender");
                dt.Columns.Add("Age");
                dt.Columns.Add("Programmer");
                ds.Tables.Add(dt);

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = ds.Tables["Employee"].NewRow();

                    row["Name"] = r.Cells[0].Value;
                    row["Last"] = r.Cells[0].Value;
                    row["Gender"] = r.Cells[0].Value;
                    row["Age"] = r.Cells[1].Value;
                    row["Programmer"] = r.Cells[2].Value;
                    ds.Tables["Employee"].Rows.Add(row);
                }
                ds.WriteXml(System.IO.Path.Combine(Environment.CurrentDirectory, "Data2.xml"));
                MessageBox.Show("XML файл успішно збережений.", "Виповнено.");
            }
            catch
            {
                MessageBox.Show("Неможливо зберегти XML файл.", "Помилка.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Очистити поле перед зугрузкою нового файла", "Помилка");
            }
            else
            {
                if (File.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "Data2.xml")))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(System.IO.Path.Combine(Environment.CurrentDirectory, "Data2.xml"));
                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                        dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                        dataGridView1.Rows[n].Cells[2].Value = comboBox2.Text;
                        dataGridView1.Rows[n].Cells[3].Value = numericUpDown1.Value;
                        dataGridView1.Rows[n].Cells[4].Value = comboBox1.Text;
                    }
                }
                else
                    MessageBox.Show("XML файн не найден", "Помилка.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Таблиця пуста.", "Помилка.");
            }
        }
    }
}
