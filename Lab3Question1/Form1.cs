using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

//a form that taes in the time in hours and minutes and outputs the time
//in 12 hour format
namespace Lab3Question1
{
    public partial class Form1 : Form
    {
        //set to 0
        int inputHour = 0;
        int inputMinute = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            inputMinute = Convert.ToInt32(txtInputMinute.Text);
            inputHour = Convert.ToInt32(txtInputHour.Text);

            //call function to check the input
            checkInput();

            //calll function to convert to 12 hour format
            output12HourFormat();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //exit form when button clicked
            this.Close();
        }

        //declaration of functon to output 12 hour format
        public void output12HourFormat()
        {
            //variables take in strings from textboxes and convert to int
            

            //check hour and carry out process if condidtion met
            if (inputHour == 00 && inputMinute == 00)
            {
                txt12hour.Text = "Midnight";
            }
            else if (inputHour == 12 && inputMinute == 00)
            {
                txt12hour.Text = "Noon";
            }
            else if (inputHour >= 12 && inputHour <= 23)
            {
                if (inputHour == 12)
                {
                    if (inputMinute >= 0 && inputMinute <= 9)//add leading 0 to single digit numbers
                    {
                        txt12hour.Text = inputHour.ToString() + ":" + '0' + inputMinute.ToString() + "pm";
                    }
                }
                else
                    inputHour -= 12;//convert 24 hour format to 12
                if (inputMinute >= 0 && inputMinute <= 9)
                {
                    txt12hour.Text = inputHour.ToString() + ":" + '0' + inputMinute.ToString() + "pm";
                }
                else
                    txt12hour.Text = inputHour.ToString() + ":" + inputMinute.ToString() + "pm";
            }
            else txt12hour.Text = inputHour.ToString() + ":" + inputMinute.ToString() + "am";
        }

        //declaration of funcion to check input was correct
        public void checkInput()
        {
            if (inputHour < 0 || inputHour > 23)
            {
                MessageBox.Show(
                "Hour entered must be hour on 24 hour clock",
                "Entry Error");
                txtInputHour.Focus();
                this.Close();
            }
            else if (inputMinute < 0 || inputMinute > 59)
            {
                MessageBox.Show(
                "Minutes entered must be between 0 and 59",
                "Entry Error");
                txtInputMinute.Focus();
                this.Close();
            }
        }
    }
}
