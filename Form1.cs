using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            var taskDescriptionColumn = new DataGridViewTextBoxColumn
            {
                Name = "TaskDescription",
                HeaderText = "Task Description",
                ReadOnly = false,
                Width = 500 // Set the width to a larger value
            };
            dataGridView1.Columns.Add(taskDescriptionColumn);

            var statusColumn = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                ReadOnly = true,
                Width = 150 // Optional: Set a specific width for the status column
            };
            dataGridView1.Columns.Add(statusColumn);

            // Customize DataGridView appearance
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Green;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string taskDescription = taskTextBox.Text;
            if (!string.IsNullOrWhiteSpace(taskDescription))
            {
                dataGridView1.Rows.Add(taskDescription, "Pending");
                taskTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a task description.");
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }
        }

        private void completeButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                row.Cells["Status"].Value = "Completed";
            }
        }

        private void taskTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
