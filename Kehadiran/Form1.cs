using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kehadiran
{
    public partial class Form1 : Form
    {
        // Create a new DateTimePicker control and initialize it.
        DateTimePicker dtPicker = new DateTimePicker();
        Rectangle _Rectangle;
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
            //dataGridView1.DefaultCellStyle.Format = "hh:mm:ss tt";
            //dataGridView1.ColumnHeadersDefaultCellStyle.Format = "hh:mm:ss tt";

            DateTime dayFirst = dateTimePicker1.Value;
            var dayLastDate = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            DateTime dayLast = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dayLastDate);
            //MessageBox.Show($"hello world {dayLast}");


            for (DateTime date = dayFirst; dayLast.CompareTo(date) >= 1; date = date.AddDays(1.0))
            {
                dataGridView1.Rows.Add(date.ToString("dd/MM/yyyy - dddd"));
            }
            dataGridView1.Rows.Add(dayLast);
            dataGridView1.AllowUserToAddRows = false;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show($"hello world {e.ColumnIndex} {e.RowIndex}");
            //MessageBox.Show($"You must be logged in as an Administrator in order to change the facility configuration no {e.ColumnIndex}.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show($"{dataGridView1.Columns[e.ColumnIndex].Name}  = {e.ColumnIndex} {e.RowIndex}");
            //MessageBox.Show($"You must be logged in as an Administrator in order to change the facility configuration no {e.ColumnIndex}.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column2" || dataGridView1.Columns[e.ColumnIndex].Name == "Column3" || dataGridView1.Columns[e.ColumnIndex].Name == "Column5" || dataGridView1.Columns[e.ColumnIndex].Name == "Column6"|| dataGridView1.Columns[e.ColumnIndex].Name == "Column8" || dataGridView1.Columns[e.ColumnIndex].Name == "Column9")
            {
                //MessageBox.Show($"{dataGridView1.Columns[e.ColumnIndex].Name}  = {e.ColumnIndex} {e.RowIndex}");
                setNewCellDate(e);
            }
        }

        private void setNewCellDate(DataGridViewCellEventArgs e)
        {
            //throw new NotImplementedException();
            dataGridView1.Controls.Add(dtPicker);


            _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
            dtPicker.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
            dtPicker.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
            
            dtPicker.Format = DateTimePickerFormat.Time;
            dtPicker.ShowUpDown = true;

            dtPicker.CustomFormat = "HH:mm tt";
            //dtPicker.CustomFormat = "HH:mm";
            //dtPicker.ShowUpDown = true;
            //dtPicker.Size = dataGridView1.CurrentCell.Size;
            //dtPicker.Top = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Top + dataGridView1.Top;
            //dtPicker.Left = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Left + dataGridView1.Left;
            if (!(object.Equals(Convert.ToString(dataGridView1.CurrentCell.Value), "")))
                dtPicker.Value = Convert.ToDateTime(dataGridView1.CurrentCell.Value);
            dtPicker.Visible = true;
            dtPicker.TextChanged += new EventHandler(dtPicker_TextChange);
        }

        private void dtPicker_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtPicker.Text.ToString();
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtPicker.Visible = false;
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //dtPicker.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string startTime = "7:00 AM";
            string endTime = "2:00 PM";

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            MessageBox.Show($"hello world {duration} h");
            */

           

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                try
                {
                    if (dataGridView1.Rows[i + 1].Cells["Column2"].Value != null)
                    {
                        MessageBox.Show($" ok {dataGridView1.Rows[i + 1].Cells["Column2"].Value.ToString()}");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($" nok = {ex.StackTrace}");
                }
                
                

                /*var timeIN_beforeLunch = dataGridView1.Rows[i + 1].Cells["Column2"].Value.ToString();
                var timeOUT_beforeLunch = dataGridView1.Rows[i + 1].Cells["Column3"].Value.ToString();

                if(timeIN_beforeLunch!=null && timeOUT_beforeLunch != null)
                {
                   var totalHourBeforeLunch = DateTime.Parse(timeOUT_beforeLunch).Subtract(DateTime.Parse(timeIN_beforeLunch));
                    MessageBox.Show($" work h {totalHourBeforeLunch}");
                }*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }
    }
}
