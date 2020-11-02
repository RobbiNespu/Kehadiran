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
            dateTimePicker1.CustomFormat = "dd/MM/yyyy - dddd";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }
    }

}
