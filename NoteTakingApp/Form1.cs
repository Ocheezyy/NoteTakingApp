using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApp
{
    public partial class Form1 : Form
    {
        private DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Notes", typeof(string));

            dataGridView1.DataSource = table;
            dataGridView1.Columns["Notes"].Visible = false;
            dataGridView1.Columns["Title"].Width = 235;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            TextTitle.Clear();
            TextNotes.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(TextTitle.Text, TextNotes.Text);

            TextTitle.Clear();
            TextNotes.Clear();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.CurrentCell.RowIndex;

            if (index <= 1) return;
            TextTitle.Text = table.Rows[index].ItemArray[0].ToString();
            TextNotes.Text = table.Rows[index].ItemArray[1].ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.CurrentCell.RowIndex;

            table.Rows[index].Delete();
        }
    }
}
