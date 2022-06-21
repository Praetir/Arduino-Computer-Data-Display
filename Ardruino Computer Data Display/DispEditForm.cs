﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ardruino_Computer_Data_Display
{
    public partial class DispEditForm : Form
    {
        public DataTable dispTable;

        public DispEditForm()
        {
            InitializeComponent();
        }
        
        private void DispEditForm_Load(object sender, EventArgs e)
        {
            dispTable = new DataTable();
            dispTable.Columns.Add(new DataColumn("Checklist Name"));
            dispTable.Columns.Add(new DataColumn("Checklist Index"));
            dispTable.Columns.Add(new DataColumn("Label Name"));
        }

        private void DispCPU_CheckedChanged(object sender, EventArgs e)
        {
            if (dispCPU.Checked)
            {
                tempCPUCL.Enabled = true;
                coreCPUText.Enabled = true;
            }
            else
            {
                tempCPUCL.Enabled = false;
                coreCPUText.Enabled = false;
            }
            
        }

        private void CoreCPUText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits into text box
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Check if enter key has been pressed
            else if (e.KeyChar == (char)Keys.Enter)
            {
                UpdateChecklist(tempCPUCL, "CPU Core");
            }
        }

        private void TempCPUCL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());

            // Get checklist information
            int index = tempCPUCL.SelectedIndex;
            bool checkedItem = tempCPUCL.GetItemChecked(index);
            string checkName = (string)tempCPUCL.Items[index];
            
            Console.WriteLine(checkName);

            // Determine the text of the label (to match what will be on the Arduino display)


            if (checkedItem)
            {
                // Add label to form/data table, and add checklist/index to data table
                //dispTable.Rows.Add(tempCPUCL, index, DispAdd(checkName + "Label", "Label", ""));
            }
            
        }

        // Remove and add checklist items to desired box
        private void UpdateChecklist(CheckedListBox list, string part)
        {
            // Remove CPU core temperature options from check list
            int listNum = list.Items.Count;
            if (listNum > 2)
            {
                for (int i = 2; i < listNum; i++)
                {
                    list.Items.RemoveAt(2);
                }
            }

            // Add updated number of CPU core temperature options to check list
            for (int i = 1; i <= int.Parse(coreCPUText.Text); i++)
            {
                list.Items.Add(String.Format("{0} {1}", part, i), false);
            }

            return;
        }

        // Add text label to menu to represent display items
        private Label DispAdd(string labelName, string labelText, string dataType)
        {
            Label labelDisp = new Label
            {
                Name = labelName,
                Text = labelText,
                Location = new Point(300, 280),
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 8.25f)
            };
            return labelDisp;
        }

        private void tempCPUCL_SelectedValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());

            // Get checklist information
            int index = tempCPUCL.SelectedIndex;
            bool checkedItem = tempCPUCL.GetItemChecked(index);
            string checkName = (string)tempCPUCL.Items[index];

            Console.WriteLine(checkName);

            // Determine the text of the label (to match what will be on the Arduino display)


            if (checkedItem)
            {
                // Add label to form/data table, and add checklist/index to data table
                //dispTable.Rows.Add(tempCPUCL, index, DispAdd(checkName + "Label", "Label", ""));
            }

        }
    }
}
