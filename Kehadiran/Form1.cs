using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace Kehadiran
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetMyCustomFormat();
        }

        private void SetMyCustomFormat()
        {
            //throw new NotImplementedException();
            // Set the Format type and the CustomFormat string.
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/mm/yyyy - dddd";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            int totalColums = dataGridView1.ColumnCount;

            dateTimePicker1.Enabled = false;

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].Name = "Test";

            dataGridView1.Rows.Add("aa");

        }
    }

}
