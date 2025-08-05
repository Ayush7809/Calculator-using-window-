using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CalcApp
{
    public partial class Calculator : Form
    {
        private String currentCal = "";
        public Calculator()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentCal += btn.Text;
            textBox1.Text = currentCal;
            //textBox1.Text += ((Button)sender).Text;
        }

        private void btn_Equal_Click(object sender, EventArgs e)
        {
            String formattedCal = currentCal.ToString();
            try
            {
                textBox1.Text = new DataTable().Compute(formattedCal, null).ToString();
                currentCal = textBox1.Text; // Update currentCal with the result
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in calculation: " + ex.Message);
                currentCal = "";
                textBox1.Text = "";
            }
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            currentCal = "";
            textBox1.Text = "0";
        }
        private void btn_Backspace_Click(object sender, EventArgs e)
        {
            if (currentCal.Length > 0)
            {
                currentCal = currentCal.Remove(currentCal.Length - 1, 1);
                textBox1.Text = currentCal;
            }
            textBox1.Text = currentCal;
        }
    }
}
