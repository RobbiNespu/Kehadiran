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
            dateTimePicker1.CustomFormat = "dd/MM/yyyy - dddd";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            int totalColums = dataGridView1.ColumnCount;

            dateTimePicker1.Enabled = false;
            btnGenerate.Enabled = false;

            dataGridView1.ColumnHeadersVisible = true;
            /*dataGridView1.Columns[0].Name = "Test";*/

            //dataGridView1.Rows.Add("aa");

            /*DataGridViewRow dr = new DataGridViewRow();
            dr.CreateCells(dataGridView1);
            //dr.Cells[0].Value = dateTimePicker1.Value.GetDateTimeFormats()[3];
            dr.Cells[0].Value = dateTimePicker1.Value.ToString("dd/MM/yyyy - dddd");
            dr.Cells[1].Value = "xx";
            dataGridView1.Rows.Insert(0, dr);*/

            DateTime dayFirst = dateTimePicker1.Value;
            var dayLastDate = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            DateTime dayLast = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dayLastDate);
            //MessageBox.Show($"hello world {dayLast}");

            
            for (DateTime date = dayFirst; dayLast.CompareTo(date) >= 1; date = date.AddDays(1.0))
            {
                dataGridView1.Rows.Add(date.ToString("dd/MM/yyyy - dddd"));
            }
            dataGridView1.Rows.Add(dayLast);



            //(dateTimePicker1.Value.Date - StartDate.Date).Days

            // Populate the rows.
            /*string[] row1 = new string[] { "Meatloaf", "Main Dish", "ground beef",        "**" };
            string[] row2 = new string[] { "Key Lime Pie", "Dessert",        "lime juice, evaporated milk", "****" };
            string[] row3 = new string[] { "Orange-Salsa Pork Chops", "Main Dish",        "pork chops, salsa, orange juice", "****" };
            string[] row4 = new string[] { "Black Bean and Rice Salad", "Salad",        "black beans, brown rice", "****" };
            string[] row5 = new string[] { "Chocolate Cheesecake", "Dessert",        "cream cheese", "***" };
            string[] row6 = new string[] { "Black Bean Dip", "Appetizer",        "black beans, sour cream", "***" };
            object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };

            foreach (string[] rowArray in rows)
            {
                dataGridView1.Rows.Add(rowArray);
            }*/


        }
    }

}
