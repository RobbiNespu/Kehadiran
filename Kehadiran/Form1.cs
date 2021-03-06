﻿using System;
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

            dataGridView1.Columns[2].DefaultCellStyle.Format = "hh:mm:ss";

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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column2" || dataGridView1.Columns[e.ColumnIndex].Name == "Column3" || dataGridView1.Columns[e.ColumnIndex].Name == "Column5" || dataGridView1.Columns[e.ColumnIndex].Name == "Column6" || dataGridView1.Columns[e.ColumnIndex].Name == "Column8" || dataGridView1.Columns[e.ColumnIndex].Name == "Column9")
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
            //MessageBox.Show($" CurrentCell  {dataGridView1.CurrentCell.Value}");

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
            TimeSpan totalEveryHour = new TimeSpan();
            /*string startTime = "7:00 AM";
            string endTime = "2:00 PM";

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
            MessageBox.Show($"hello world {duration} h");
            */

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells["Column2"].Value != null && dataGridView1.Rows[i].Cells["Column3"].Value.ToString() != null)
                {
                    //MessageBox.Show($" ok {dataGridView1.Rows[i].Cells["Column2"].Value.ToString()}");
                    var timeIN_beforeLunch = dataGridView1.Rows[i].Cells["Column2"].Value.ToString();
                    var timeOUT_beforeLunch = dataGridView1.Rows[i].Cells["Column3"].Value.ToString();
                    var totalHourBeforeLunch = DateTime.Parse(timeOUT_beforeLunch).Subtract(DateTime.Parse(timeIN_beforeLunch));
                    totalEveryHour = totalHourBeforeLunch;
                    dataGridView1.Rows[i].Cells["Column10"].Value = totalEveryHour;
                    //MessageBox.Show($" work h {totalHourBeforeLunch}");
                }

                if (dataGridView1.Rows[i].Cells["Column5"].Value != null && dataGridView1.Rows[i].Cells["Column6"].Value.ToString() != null)
                {
                    var timeIN_afterLunch = dataGridView1.Rows[i].Cells["Column5"].Value.ToString();
                    var timeOUT_afterLunch = dataGridView1.Rows[i].Cells["Column6"].Value.ToString();
                    var totalHourAfterLunch = DateTime.Parse(timeOUT_afterLunch).Subtract(DateTime.Parse(timeIN_afterLunch));
                    totalEveryHour = totalEveryHour + totalHourAfterLunch;
                    dataGridView1.Rows[i].Cells["Column10"].Value = totalEveryHour;
                }

                if (dataGridView1.Rows[i].Cells["Column8"].Value != null && dataGridView1.Rows[i].Cells["Column9"].Value.ToString() != null)
                {
                    var timeIN_dinner = dataGridView1.Rows[i].Cells["Column8"].Value.ToString();
                    var timeOUT_dinner = dataGridView1.Rows[i].Cells["Column9"].Value.ToString();
                    var totalHourDinnner = DateTime.Parse(timeOUT_dinner).Subtract(DateTime.Parse(timeIN_dinner));
                    totalEveryHour = totalEveryHour + totalHourDinnner;
                    dataGridView1.Rows[i].Cells["Column10"].Value = totalEveryHour;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (System.IO.TextWriter tw = new System.IO.StreamWriter($"{path}\\sample1.txt"))
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 1; j < dataGridView1.Columns.Count; j++)
                    {
                        var v = string.Concat("Column", j);
                        if (dataGridView1.Rows[i].Cells[v].Value != null)
                        {
                            tw.Write("\t" + dataGridView1.Rows[i].Cells[v].Value.ToString() + "\t" + "|");
                        }

                    }
                    tw.WriteLine("");
                    tw.WriteLine("-----------------------------------------------------");
                }
                tw.Close();
                MessageBox.Show("Data Exported");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yes or no", "The Title",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("RESET!!!!!!!!");
            }
        }
    }

}
