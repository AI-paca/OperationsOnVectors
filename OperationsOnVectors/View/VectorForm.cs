using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OperationsOnVectors.Controller;

namespace OperationsOnVectors.View
{    
    public partial class VectorForm : Form
    {   
        public VectorForm()
        {
            InitializeComponent();
        }
        private VectorController controller = new VectorController();
        //chash
        int d;
        double x;
        string temp = "";
        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = controller.OnNewVector(textBox1.Text);            
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            label1.Text = controller.OnListVectorPrint();
            label2.Text = controller.OnArrayVectorPrint();
            //label3.Text = controller.OnArrIVectorPrint();           
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateInfo();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label4.Text = controller.OnListVectorPrint();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            label4.Text = controller.OnArrayVectorPrint();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            controller.OnListVector();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            controller.OnArrayVector();
        }

        void ReadInt()
        {
            System.Windows.Forms.Form dialog = new System.Windows.Forms.Form();
            dialog.Text = "Введите номер измерения и закройте окно";
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            dialog.Controls.Add(textBox);

            dialog.ShowDialog();
            d = Convert.ToInt32(textBox.Text);
            MessageBox.Show("Вы ввели " + d);
        }
        void ReadDouble()
        {
            System.Windows.Forms.Form dialog = new System.Windows.Forms.Form();
            dialog.Text = "Введите значение измерения и закройте окно";
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            dialog.Controls.Add(textBox);

            dialog.ShowDialog();
            x = Convert.ToInt32(textBox.Text);
            MessageBox.Show("Вы ввели " + x);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadDouble();
            label4.Text = controller.OnAppendEndListVector(x, label4.Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ReadDouble();
            label4.Text =  controller.OnAppendStartListVector(x, label4.Text);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ReadInt();
            ReadDouble();
            label4.Text = controller.OnAppendPointListVector(d, x, label4.Text);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ReadInt();
            label4.Text = controller.OnDelPointListVector(d, label4.Text);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            label4.Text = controller.OnDelEndListVector(label4.Text);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            label4.Text = controller.OnDelStartListVector(label4.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label4.Text = controller.OnGetNorm(label4.Text);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            label4.Text = controller.OnGetLenght(label4.Text);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            ReadInt();
            label4.Text = controller.OnGetByIndex(d, label4.Text);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            ReadInt();
            ReadDouble();
            label4.Text = controller.OnChangeByIndex(d, x, label4.Text);
        }


        private void button12_Click(object sender, EventArgs e)
        {
            if (temp.Length == 0)
            {
                temp = label4.Text;
                label4.Text = "Первый вектар выбран, пожалуйста выберете второй вектор и поддтвердите действие";
            }    
            else if (temp.Length > 0){
                label4.Text = controller.OnVectorSum(temp, label4.Text); temp = "";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {            
            if (temp.Length == 0)
            {
                temp = label4.Text;
                label4.Text = "Первый вектар выбран, пожалуйста выберете второй вектор и поддтвердите действие";
            }    
            else if (temp.Length > 0){
                label4.Text = controller.OnVectorScalar(temp, label4.Text);
                temp = "";            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (temp.Length == 0)
            {
                temp = label4.Text;
                label4.Text = "Первый вектар выбран, пожалуйста выберете второй вектор и поддтвердите действие";
            }    
            else if (temp.Length > 0){
            label4.Text = controller.OnVectorEquals(temp, label4.Text);temp = "";            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
             if (temp.Length == 0)
            {
                temp = label4.Text;
                label4.Text = "Первый вектар выбран, пожалуйста выберете второй вектор и поддтвердите действие";
            }    
            else if (temp.Length > 0){
            label4.Text = controller.OnLenEquals(temp, label4.Text);temp = "";            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (temp.Length == 0)
            {
                temp = label4.Text;
                label4.Text = "Первый вектар выбран, пожалуйста выберете второй вектор и поддтвердите действие";
            }
            else if (temp.Length > 0)
            {
            label4.Text = controller.OnNornEquals(temp, label4.Text);temp = "";            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (label4.Text.Length!=0)
                controller.OnAddVectorInList(label4.Text);
            else
                controller.OnAddVectorInList(textBox1.Text);
            listBox1.Items.Clear();
            listBox1.Items.AddRange(controller.OnArrIVectorPrint());
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string selectedItem = listBox1.SelectedItem.ToString();
            label4.Text = selectedItem;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            controller.OnSort();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(controller.OnArrIVectorPrint());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label4.Text=controller.OnFind();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            controller.OnMinFlag();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            controller.OnMinFlagFalse();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            controller.OnFindFlag();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            controller.OnFindFlagFalse();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            controller.OnSortFlag();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            controller.OnSortFlagFalse();
        }


    }
}
