using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;

namespace Process_Manupulator
{

    public partial class Form1 : Form
    {
        ProcessManupulator pm = new ProcessManupulator();

        public Form1()
        {
            // prever ce je admin

            if(!pm.IsAdministrator())
            {
                MessageBox.Show("Please run program as an Administrator if you wish to perform anything but diagnostics as any administrative action will result in errors, PRESS `OK` TO CONTINUE.",
                    $"Hold your horses {Environment.UserName}!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            InitializeComponent();

            checkBox1.Checked = true;
            this.Text = "Windows Process Manipulator";
            comboBox1.Text = "Select a process..";

            Process[] procList = Process.GetProcesses();

            foreach (Process p in procList)
            {
                if (p.ProcessName == "svchost" | p.ProcessName == "conhost" | p.ProcessName == "dllhost")
                {
                    if (!checkBox1.Checked)
                    {
                        comboBox1.Items.Add(p.ProcessName);
                    }
                }
                else
                {
                    comboBox1.Items.Add(p.ProcessName);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

            Process[] processname = Process.GetProcessesByName(selected);

            

            for (int i = 0; i < processname.Length; i++)
            {
                processname[i].Kill();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

            Process[] processname = Process.GetProcessesByName(selected);

            for (int i = 0; i < processname.Length; i++)
            {
                pm.FreezeThreads(processname[i].Id);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

            Process[] processname = Process.GetProcessesByName(selected);

            for (int i = 0; i < processname.Length; i++)
            {
                pm.UnfreezeThreads(processname[i].Id);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] procList = Process.GetProcesses();

            comboBox1.Items.Clear();

            foreach (Process p in procList)
            {
                if (p.ProcessName == "svchost" | p.ProcessName == "conhost" | p.ProcessName == "dllhost")
                {
                    if (!checkBox1.Checked)
                    {
                        comboBox1.Items.Add(p.ProcessName);
                    }
                }
                else
                {
                    comboBox1.Items.Add(p.ProcessName);
                }
            }
            comboBox1.Text = "Refreshed, Select a process..";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

            Process[] p = Process.GetProcessesByName(selected);
            richTextBox1.Text += p[0].MainModule.FileName + "\n";
            richTextBox1.Text += p[0].MainModule.ModuleName;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("At this point i could've killed all windows processes, deleted all your files, shared your \"homework\" directory on your facebook feed or call all of those horny local milfs that are waiting for you, But i'm a nice person so this button does nothing. Or does it?", $"You've made a grave mistake, {Environment.UserName}.",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/8qBITs");
        }
    }
}
