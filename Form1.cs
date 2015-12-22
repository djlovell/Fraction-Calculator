using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project10_Part2
{
    public partial class Form1 : Form
    {
        private Fraction[] fractionArray = new Fraction[3];
        private Button[] buttons;
        private string expression;

        public Form1()
        {
            InitializeComponent();
            buttons = new Button[16];
            buttons[0] = Button_0;
            buttons[1] = Button_1;
            buttons[2] = Button_2;
            buttons[3] = Button_3;
            buttons[4] = Button_4;
            buttons[5] = Button_5;
            buttons[6] = Button_6;
            buttons[7] = Button_7;
            buttons[8] = Button_8;
            buttons[9] = Button_9;
            buttons[10] = Button_Slash;
            buttons[11] = Button_Add;
            buttons[12] = Button_Subtract;
            buttons[13] = Button_Multiply;
            buttons[14] = Button_Divide;
            buttons[15] = Button_Equals;
            
            for (int i = 0; i < 16; i++)
            {
                buttons[i].Click += new EventHandler(buttonClick);
            }//end for

            Button_Clear.Click += new EventHandler(clearClick);
        }

        private void buttonClick(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
             //expression = b.Text;

            if (b.Text.Equals("+") || b.Text.Equals("-") || b.Text.Equals("*") || b.Text.Equals("DIV"))
            {
                Window.Text = "";
              

                expression += " " + b.Text[0] + " "; 
                
            }
            else if (b.Text.Equals("="))
            {
                Window.Text = "";
                for(int k=0; k<11; k++)
                {
                    buttons[k].Enabled = false;
                }//end for
                buttons[15].Enabled = false;

                string[] parts = expression.Split(' ');
                string first = parts[0];
                string tempop = parts[1];
                char op = tempop[0];
                string second = parts[2];

                // Determine if first value is a whole number or fraction
                string[] pieces = first.Split('/');
                if (pieces.Length == 1) // whole number, call one-arg constructor
                    fractionArray[0] = new Fraction(Convert.ToInt32(pieces[0]));
                else                    // fraction, call two-arg constructor
                                        // Split into numeration and denominator and create fraction object
                    fractionArray[0] = new Fraction(Convert.ToInt32(pieces[0]),
                                                        Convert.ToInt32(pieces[1]));

                // Determine if second value is a whole number or fraction
                pieces = second.Split('/');
                if (pieces.Length == 1) // whole number, call one-arg constructor
                    fractionArray[1] = new Fraction(Convert.ToInt32(pieces[0]));
                else                    // fraction, call two-arg constructor
                                        // Split into numeration and denominator and create fraction object
                    fractionArray[1] = new Fraction(Convert.ToInt32(pieces[0]),
                                                        Convert.ToInt32(pieces[1]));

                //bool flag = true;   // error if operator is not +, -, *, /
                switch (op)
                {
                    case '+':
                        // 'plus' returns a reduced fraction object
                        fractionArray[2] = fractionArray[0].Plus(fractionArray[1]);
                        break;
                    case '-':
                        // 'minus' returns a reduced fraction object
                        fractionArray[2] = fractionArray[0].Minus(fractionArray[1]);
                        break;
                    case '*':
                        // 'times' returns a reduced fraction object
                        fractionArray[2] = fractionArray[0].Times(fractionArray[1]);
                        break;
                    case 'D':
                        // 'divide' returns a reduced fraction object
                        fractionArray[2] = fractionArray[0].Divide(fractionArray[1]);
                        break;
                    default:
                        break;
                        
                } // end switch-case
                string answer;
                if (op == 'D')
                {
                    answer = fractionArray[0] + " " + "/" + " " + fractionArray[1] + " = " + fractionArray[2];
                }
                else
                {
                    answer = fractionArray[0] + " " + op + " " + fractionArray[1] + " = " + fractionArray[2];
                }
                Window.Text = answer;
                
            }//end else if
            else
            {
                Window.Text += b.Text;
                expression += b.Text;
            }//end else
        }   

        private void clearClick(object sender, EventArgs e)
        {
            expression = "";
            Button b = (Button)sender;
            Window.Text = "";
            for(int l = 0; l<16; l++)
            {
                buttons[l].Enabled = true;
            }//end for
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
