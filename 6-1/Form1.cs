using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace extra_6_1_calculator
{


    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //function that checks if all inputs have a value
        public Boolean IsPresent(string op1, string op2, string operand)
        {
            //if any strings are empty it will return false and throw and exception
            if (op1 == "" || op2 == "" || operand == "")
            {
                string message = "Improper format. Please enter a number in operator 1 and 2, and either +, -, /, or * for operand";
                MessageBox.Show(message);
                return false;
            }
            else
            {
                return true;
            }
        }

        //checks if inputed numbers are valid decimals
        public Boolean IsDecimal(string op)
        {
            decimal dec = 0.0M;
            if (Decimal.TryParse(op, out dec))
            {
                return true;
            }
            else
            {
                string message = "Please enter a number for operand 1 and 2";
                MessageBox.Show(message);
                return false;
            }
        }

        //checks if inputted numbers are in range in case of a stack overflow
        public Boolean IsWithinRange(decimal op1, decimal op2)
        {
            if(op1< 0 || op1> 1000000 || op2< 0 || op2> 1000000)
            {
                string message = "Out of range. Please enter value between 0 and 1,000,000";
                MessageBox.Show(message);
                return false;
            }
            else return true;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal op1 = Convert.ToDecimal(txtOperand1.Text);
                decimal op2 = Convert.ToDecimal(txtOperand2.Text);
                string op = Convert.ToString(txtOperator.Text);
            }

            catch
            {
                string message = "Error";
                MessageBox.Show(message);
            }

            /*
            catch(OverflowException)
            {
                string message = "Stack Overflow. Please enter value between 0 and 1,000,000";
                MessageBox.Show(message);
            }
            catch (DivideByZeroException)
            {
                string message = "Divide by 0 error. Please enter a non-zero value for operand2 when dividing";
                MessageBox.Show(message);
            }
            catch (FormatException)
            {
                string message = "Improper format. Please enter a number in operator 1 and 2, and either +, -, /, or * for operand";
                MessageBox.Show(message);
            }
            */

            //if all in puts are valid, calls function
            if (IsPresent(txtOperand1.Text, txtOperand2.Text, txtOperator.Text) && IsDecimal(txtOperand1.Text) && IsDecimal(txtOperand2.Text) && IsWithinRange(Convert.ToDecimal(txtOperand1.Text), Convert.ToDecimal(txtOperand2.Text)))
            {
            decimal op1 = Convert.ToDecimal(txtOperand1.Text);
            decimal op2 = Convert.ToDecimal(txtOperand2.Text);
            string op = Convert.ToString(txtOperator.Text);
            txtResult.Text = Calc(op1, op2, op).ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //function that does the math
        private static decimal Calc(decimal operator1, decimal operator2, string operand)
        {
            decimal funcResult = 0;
            decimal funcOp1 = operator1;
            decimal funcOp2 = operator2;
            string funcOperand = operand;
            //addition
            if (operand == "+")
            {
                funcResult = funcOp1 + funcOp2;
            }
            //subtraction
            else if (operand == "-")
            {
                funcResult = funcOp1 - funcOp2;
            }
            //division
            else if (operand == "/")
            {
                funcResult = funcOp1 / funcOp2;
            }
            //multiplication
            else
            {
                funcResult = funcOp1 * funcOp2;
            }

            return funcResult;
        }


    }
}
