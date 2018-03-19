using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace calc
{

    public partial class Form1 : Form
    {
        Brain brain = new Brain();
        public Form1()
        {
            InitializeComponent();
            brain.invoker = ShowInfo;
        }
        public void ShowInfo(string msg)
        {
            text.Text = msg;
        }
        public void BtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            brain.Process(btn.Text);
        }

    }
}
/*MS(Memory Save) - кнопка означает сохранить число, отображенное в данный момент на дисплее калькулятора в память.

MR(Memory Read) - кнопка означает считать число из ячейки памяти и вывести его на дисплей.

MC(Memory Clear) - кнопка означает стереть данные из ячейки памяти.

M+ - прибавить к числу из памяти число, отображенное на дисплее и результат записать в память вместо предыдущего.

M- - вычесть из числа в памяти число, отображенное на дисплее калькулятора и результат записать в память.
*/
/*private void clickshow(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if (text.Text == "0")
            {
                text.Text = bt.Text;
            }
            else
            {
                text.Text = text.Text + bt.Text;
            }
        }
        private void operationbt(object sender, EventArgs e)
        {
            Button operBt = sender as Button;
            if(operBt.Text == "+")
            {
                clc.oprstates = operstates.plus;
            }
            else if(operBt.Text == "-")
            {
                clc.oprstates = operstates.minus;
            }
            else  if(operBt.Text == "x")
            {
                clc.oprstates = operstates.multiply;
            }
            else  if (operBt.Text == "÷")
            {
                clc.oprstates = operstates.divide;
            }

            clc.clcstates = calcstates.second;
            if(clc.firstnumber != 0)
            {
                clc.firstnumber = clc.resultnumber;

            }
            else
            {
                clc.firstnumber = double.Parse(text.Text);
            }
            text.Text = "0";
        }
        private void resultbt(object sender, EventArgs e)
        {
            clc.clcstates = calcstates.first;
            clc.secondnumber = double.Parse(text.Text);

            switch (clc.oprstates)
            {
                case operstates.divide:
                    
                   clc.resultnumber = clc.firstnumber / clc.secondnumber;
                    break;
                case operstates.minus:
                    clc.resultnumber = clc.firstnumber - clc.secondnumber;
                    break;
                case operstates.multiply:
                    clc.resultnumber = clc.firstnumber * clc.secondnumber;
                    break;
                case operstates.plus:
                    clc.resultnumber = clc.firstnumber + clc.secondnumber;
                    break;
                default:
                    break;
            }

            if (clc.resultnumber.ToString() == "∞")
            {
                text.Text = "Ошибка";
            }
            else
            {
                text.Text = clc.resultnumber.ToString();
            }
        }
        private void delim(object sender, EventArgs e)
        {
            double a = (1 /double.Parse(text.Text));
            text.Text = a.ToString();
        }
        private void power2(object sender, EventArgs e)
        {
            double b = Math.Pow(double.Parse(text.Text), 2);
            text.Text = b.ToString();
            
        }
        private void sqrt(object sender, EventArgs e)
        {
            double c = Math.Sqrt(double.Parse(text.Text))+1;
            text.Text = c.ToString();
            
        }
        private void clear(object sender, EventArgs e)
        {
            clc.clcstates = calcstates.first;
            clc.firstnumber = 0;
            text.Text = "0";
            
        }
        private void clearcertainthing(object sender, EventArgs e)
        {
            text.Text = "0";
        }
        private void deletelastdigit(object sender, EventArgs e)
        {
            string s = text.Text;
            string ss = "";
            for(int i = 0; i < s.Length-1; i++)
            {
                ss += s[i];
            }
            text.Text = ss;
            if(text.Text.Length == 0)
            {
                text.Text = "0";
            }
        }
        private void converttodouble(object sender,EventArgs e)
        {
            if (!text.Text.Contains(","))
            {
                text.Text = text.Text + ",";
            }
           
            
        }
        private void percent(object sender, EventArgs e)
        {
            double doble = double.Parse(text.Text) / 100;
            text.Text = doble.ToString();
        }
        private void changesign(object sender, EventArgs e)
        {
            double dbbl = double.Parse(text.Text) * (-1);
            text.Text = dbbl.ToString();
        }
        private void save_click(object sender, EventArgs e)
        {

            clc.list.Add(text.Text);
            changecolorwhenfalse();
            clc.flag = true;
        }

        private void read_click(object sender, EventArgs e)
        {
            if (clc.flag == true)
            {

                text.Text = clc.list[clc.list.Count - 1];
                
            }
            
        }
        private void clear_click(object sender, EventArgs e)
        {
            
            for(int i = 0; i < clc.list.Count; i++)
            {
                clc.list[i] = "";
            }
            changecolorwhentrue();
            clc.flag = false;
            
        }
        private  void plussavednumber(object sender, EventArgs e)
        {
            if (clc.flag == true)
            {
                

                string b = (double.Parse(text.Text) + double.Parse(clc.list[clc.list.Count -1])).ToString();
                clc.list.Add(b);
                
            }
        }
        private void minussavednumber(object sender, EventArgs e)
        {
            if (clc.flag == true)
            {
                string b = (double.Parse(text.Text) - double.Parse(clc.list[clc.list.Count - 1])).ToString();
                clc.list.Add(b);
            }
        }
        
        
        public void changecolorwhentrue()
        {
            button13.BackColor = Color.Red;
            button4.BackColor = Color.Red;
            button2.BackColor = Color.Red;
            button21.BackColor = Color.Red;
        }
        public void changecolorwhenfalse()
        {
            button13.BackColor = Color.Silver;
            button4.BackColor = Color.Silver;
            button2.BackColor = Color.Silver;
            button21.BackColor = Color.Silver;
        }*/
