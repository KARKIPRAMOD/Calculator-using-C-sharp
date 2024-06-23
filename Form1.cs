using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SudeepCalculator
{
    public partial class Sudeep : Form
    {
        private bool isScientificMode = false;
        private bool isStandardMode = true;
        private Size oldSize;


        public Sudeep()
        {
            InitializeComponent();
            oldSize = this.Size;
            standardMode.Checked = true;


            // Load the image to pictureBox2 from the Resources folder
            pictureBox2.Image = sudeepCalculator.Properties.Resources.DSC08565; // Change the namespace if needed

            // Rotate the image 90 degrees counterclockwise when the form loads
            RotateImage90DegreesCounterClockwise();
            pictureBox2.Size = new Size(500, 500);
            pictureBox2.Location = new Point(230, -250);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Text box for displaying. No additional code needed here.
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Clear button: Clear the text in richTextBox1
            displayBox.Clear();
        }

        // Number button click event handlers
        private void button1_Click(object sender, EventArgs e) { displayBox.AppendText("7"); }
        private void button2_Click(object sender, EventArgs e) { displayBox.AppendText("8"); }
        private void button3_Click(object sender, EventArgs e) { displayBox.AppendText("9"); }
        private void button4_Click(object sender, EventArgs e) { displayBox.AppendText("4"); }
        private void button5_Click(object sender, EventArgs e) { displayBox.AppendText("5"); }
        private void button6_Click(object sender, EventArgs e) { displayBox.AppendText("6"); }
        private void button7_Click(object sender, EventArgs e) { displayBox.AppendText("1"); }
        private void button8_Click(object sender, EventArgs e) { displayBox.AppendText("2"); }
        private void button9_Click(object sender, EventArgs e) { displayBox.AppendText("3"); }
        private void button10_Click(object sender, EventArgs e) { displayBox.AppendText("0"); }
        private void button11_Click(object sender, EventArgs e) { displayBox.AppendText("."); }
        private void button12_Click(object sender, EventArgs e) { displayBox.AppendText("+"); }

        private void button14_Click(object sender, EventArgs e)
        {
            // Addition (+) button
            displayBox.AppendText("+");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Subtraction (-) button
            displayBox.AppendText("-");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Multiplication (*) button
            displayBox.AppendText("*");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Division (/) button
            displayBox.AppendText("/");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // 1/x button: Calculate the reciprocal of the number in richTextBox1 and display the result
            if (double.TryParse(displayBox.Text, out double num))
            {
                double result = 1.0 / num;
                displayBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // Square root (√) button: Calculate the square root of the number in richTextBox1 and display the result
            if (double.TryParse(displayBox.Text, out double num))
            {
                double result = Math.Sqrt(num);
                displayBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button20_Click(object sender, EventArgs e)
        {
            // Equals (=) button: Calculate the result of the expression in richTextBox1 and display the result
            try
            {
                string expression = displayBox.Text;
                DataTable table = new DataTable();
                object result = table.Compute(expression, "");
                if (double.IsInfinity(Convert.ToDouble(result)))
                {
                    MessageBox.Show("Cannot divide by zero. Please enter a non-zero denominator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    displayBox.Clear(); // Clear the result in case of division by zero
                }
                else
                {
                    displayBox.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input or expression. Please enter a valid expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Standard mode radio button: Hide additional scientific mode buttons if needed
            isScientificMode = false;
            //
            //
            //true
            //
            //
            clearStd.Visible = true;
            equalStd.Visible = true;
            isStandardMode = true;
            oneByX.Visible = true; // 1/x button
            SquareRoot.Visible = true; // ^ button

            //
            //
            //False
            //
            //
            sineFunction.Visible = false;
            cosineFunction.Visible = false;
            tanFunction.Visible = false;
            Pie.Visible = false;
            factorial.Visible = false;
            Logn.Visible = false;
            Square.Visible = false;
            power.Visible = false;
            clearScientific.Visible = false;
            equalsScientific.Visible = false;

            if (isStandardMode)
            {
                this.Size = oldSize;
                tabControl.Size = new Size(643, 597);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Scientific mode radio button: Show additional scientific mode buttons if needed
            isScientificMode = true;
            isStandardMode = false;

            //
            //
            //true
            //
            //
            sineFunction.Visible = true;
            cosineFunction.Visible = true;
            tanFunction.Visible = true;
            Pie.Visible = true;
            factorial.Visible = true;
            Logn.Visible = true;
            Square.Visible = true;
            power.Visible = true;
            clearScientific.Visible = true;
            equalsScientific.Visible = true;

            //
            //
            //False
            //
            //
            clearStd.Visible = false;
            equalStd.Visible = false;
            oneByX.Visible = false; // 1/x button
            SquareRoot.Visible = false; // ^ button



            if (isScientificMode)
            {
                this.Size = new Size(685, 760);
                tabControl.Size = new Size(643, 689);
            }
            else
            {
                this.Size = oldSize;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Dark mode checkbox: Change the form and control colors for dark mode
            if (darkMode.Checked)
            {
                this.BackColor = Color.DarkGray;
                tabPage1.BackColor = Color.Black;
                tabPage2.BackColor = Color.Black;
                displayBox.BackColor = Color.Black;
                displayBox.ForeColor = Color.White;

                // Set the colors for other controls in dark mode
                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;
                button2.BackColor = Color.Black;
                button2.ForeColor = Color.White;
                button3.BackColor = Color.Black;
                button3.ForeColor = Color.White;
                button4.BackColor = Color.Black;
                button4.ForeColor = Color.White;
                button5.BackColor = Color.Black;
                button5.ForeColor = Color.White;
                button6.BackColor = Color.Black;
                button6.ForeColor = Color.White;
                button7.BackColor = Color.Black;
                button7.ForeColor = Color.White;
                button8.BackColor = Color.Black;
                button8.ForeColor = Color.White;
                button9.BackColor = Color.Black;
                button9.ForeColor = Color.White;
                button10.BackColor = Color.Black;
                button10.ForeColor = Color.White;
                button11.BackColor = Color.Black;
                button11.ForeColor = Color.White;
                button12.BackColor = Color.Black;
                button12.ForeColor = Color.White;


                // Continue setting the colors for other controls as needed...

                // Set the radio button colors in dark mode
                standardMode.ForeColor = Color.White;
                scientificMode.ForeColor = Color.White;
                darkMode.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                tabPage1.BackColor = SystemColors.Control;
                tabPage2.BackColor = SystemColors.Control;
                displayBox.BackColor = SystemColors.Window;
                displayBox.ForeColor = SystemColors.WindowText;

                // Set the colors for other controls in normal mode
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = SystemColors.ControlText;
                button2.BackColor = SystemColors.Control;
                button2.ForeColor = SystemColors.ControlText;
                button3.BackColor = SystemColors.Control;
                button3.ForeColor = SystemColors.ControlText;
                button4.BackColor = SystemColors.Control;
                button4.ForeColor = SystemColors.ControlText;
                button5.BackColor = SystemColors.Control;
                button5.ForeColor = SystemColors.ControlText;
                button6.BackColor = SystemColors.Control;
                button6.ForeColor = SystemColors.ControlText;
                button7.BackColor = SystemColors.Control;
                button7.ForeColor = SystemColors.ControlText;
                button8.BackColor = SystemColors.Control;
                button8.ForeColor = SystemColors.ControlText;
                button9.BackColor = SystemColors.Control;
                button9.ForeColor = SystemColors.ControlText;
                button10.BackColor = SystemColors.Control;
                button10.ForeColor = SystemColors.ControlText;
                button11.BackColor = SystemColors.Control;
                button11.ForeColor = SystemColors.ControlText;
                button12.BackColor = SystemColors.Control;
                button12.ForeColor = SystemColors.ControlText;




                // Set the radio button colors in normal mode
                standardMode.ForeColor = SystemColors.ControlText;
                scientificMode.ForeColor = SystemColors.ControlText;
                darkMode.ForeColor = SystemColors.ControlText;
            }
        }

        private void Pie_Click(object sender, EventArgs e)
        {
            // Pi (π) button: Display the value of Pi (π) in the displayBox
            displayBox.Text = Math.PI.ToString();
        }

        private void sineFunction_Click(object sender, EventArgs e)
        {
            // Sine (sin) button: Calculate the sine of the number in displayBox and display the result
            if (double.TryParse(displayBox.Text, out double num))
            {
                double result = Math.Sin(num);
                displayBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cosineFunction_Click(object sender, EventArgs e)
        {
            // Cosine (cos) button: Calculate the cosine of the number in displayBox and display the result
            if (double.TryParse(displayBox.Text, out double num))
            {
                double result = Math.Cos(num);
                displayBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tanFunction_Click(object sender, EventArgs e)
        {
            // Tangent (tan) button: Calculate the tangent of the number in displayBox and display the result
            if (double.TryParse(displayBox.Text, out double num))
            {
                double result = Math.Tan(num);
                displayBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Logn_Click(object sender, EventArgs e)
        {
            // Natural logarithm (ln) button: Calculate the natural logarithm of the number in displayBox and display the result
            if (double.TryParse(displayBox.Text, out double num))
            {
                double result = Math.Log(num);
                displayBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void power_Click(object sender, EventArgs e)
        {
            // Power (x^y) button: Calculate the result of the base raised to the power of the exponent in displayBox and display the result
            if (double.TryParse(displayBox.Text, out double baseNum) && double.TryParse(displayBox.Text, out double exponent))
            {
                double result = Math.Pow(baseNum, exponent);
                displayBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid numbers for base and exponent.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void factorial_Click(object sender, EventArgs e)
        {
            // Factorial button (!) button: Calculate the factorial of the number in displayBox and display the result
            if (int.TryParse(displayBox.Text, out int num))
            {
                int result = CalculateFactorial(num);
                displayBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CalculateFactorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * CalculateFactorial(n - 1);
        }

        private void Square_Click_1(object sender, EventArgs e)
        {
            // Square (x^2) button: Calculate the square of the number in displayBox and display the result
            if (double.TryParse(displayBox.Text, out double num))
            {
                double result = Math.Pow(num, 2);
                displayBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearScientific_Click_1(object sender, EventArgs e)
        {
            displayBox.Clear();
        }

        private void equalsScientific_Click(object sender, EventArgs e)
        {
            // Equals button for scientific calculations: Calculate the result of the expression in richTextBox1 and display the result
            try
            {
                string expression = displayBox.Text;
                DataTable table = new DataTable();
                object result = table.Compute(expression, "");
                if (double.IsInfinity(Convert.ToDouble(result)))
                {
                    MessageBox.Show("Cannot divide by zero. Please enter a non-zero denominator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    displayBox.Clear(); // Clear the result in case of division by zero
                }
                else
                {
                    displayBox.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input or expression. Please enter a valid expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e) { }


        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void RotateImage90DegreesCounterClockwise()
        {
            // Check if the pictureBox2 contains an image
            if (pictureBox2.Image != null)
            {
                // Rotate the image 90 degrees counterclockwise
                Image originalImage = pictureBox2.Image;
                Bitmap rotatedImage = new Bitmap(originalImage.Height, originalImage.Width);

                using (Graphics g = Graphics.FromImage(rotatedImage))
                {
                    g.TranslateTransform(0, rotatedImage.Height);
                    g.RotateTransform(-90);
                    g.DrawImage(originalImage, new Point(0, 0));
                }

                // Update the pictureBox2 with the rotated image
                pictureBox2.Image = rotatedImage;
            }
        }



        private void pictureBox2_Click(object sender, EventArgs e) { }
    }
}