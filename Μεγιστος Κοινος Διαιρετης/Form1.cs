using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Μεγιστος_Κοινος_Διαιρετης
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            label10.Text = "Μέγιστος Κοινός Διαιρέτης: ";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label12.Text = "Συμπλήρωσε τα πεδία!";
            }
            else
            {
                a = Int32.Parse(textBox1.Text);
                b = Int32.Parse(textBox2.Text);
            }
            List<int> diairetes_a = new List<int>();
            List<int> diairetes_b = new List<int>();
            for (int i = 1; i<=a; i++)
            {
                if (a % i == 0)
                {
                    diairetes_a.Add(i);
                }
            }
            for (int i = 1; i <=b; i++)
            {
                if (b % i == 0)
                {
                    diairetes_b.Add(i);
                }
            }
            for (int i =0; i< diairetes_a.Count; i++)
            {
                richTextBox1.Text = richTextBox1.Text + diairetes_a[i].ToString() + ", ";
            }

            for (int i = 0; i < diairetes_b.Count; i++)
            {
                richTextBox2.Text = richTextBox2.Text + diairetes_b[i].ToString() + ", ";
            }
            //sort lists
            diairetes_a.Sort();
            diairetes_a.Reverse();
            diairetes_b.Sort();
            diairetes_b.Reverse();
            int max = 0;
            for (int i = 0; i < diairetes_a.Count; i++)
            {
                if (diairetes_b.Contains(diairetes_a[i]))
                {
                    max = diairetes_a[i];
                    break;
                }
            }
            if (max > 0)
            {
                label11.Text = max.ToString();
            }
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel1.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            label17.Text = "Μέγιστος Κοινός Διαιρέτης: ";
            richTextBox4.Text = "";
            richTextBox3.Text = "";
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                label19.Text = "Συμπλήρωσε τα πεδία!";
            }
            else if(textBox3.Text == "1" || textBox4.Text == "1" || textBox3.Text == "0" || textBox4.Text == "0")
            {
                label19.Text = "Δώσε τιμές μεγαλύτερες από 1!";
            }
            else
            {
                a = Int32.Parse(textBox3.Text);
                b = Int32.Parse(textBox4.Text);
                List<int> first_a = new List<int>();
                List<int> first_b = new List<int>();
                for (int i = 2; i <= a; i++)
                {
                    bool isprime = true;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isprime = false;
                        }
                    }
                    while (a % i == 0 && isprime)
                    {
                        a = a / i;
                        first_a.Add(i);
                    }
                }
                for (int i = 2; i <= b; i++)
                {
                    bool isprime = true;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isprime = false;
                        }
                    }
                    while (b % i == 0 && isprime)
                    {
                        b = b / i;
                        first_b.Add(i);
                    }
                }
                first_a.Sort();
                first_b.Sort();
                int count = 1;
                for (int i = 0; i < first_a.Count; i++)
                {
                    if (i > 0)
                    {
                        if (first_a[i] != first_a[i - 1])
                        {
                            if (count > 1)
                            {
                                richTextBox4.Text = richTextBox4.Text + first_a[i - 1].ToString() + "^" + count.ToString() + "*";
                            }
                            else
                            {
                                richTextBox4.Text = richTextBox4.Text + first_a[i - 1].ToString() + "*";
                            }
                            count = 1;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                if (count > 1)
                {
                    richTextBox4.Text = richTextBox4.Text + first_a[first_a.Count - 1].ToString() + "^" + count.ToString();
                }
                else
                {
                    richTextBox4.Text = richTextBox4.Text + first_a[first_a.Count - 1].ToString();
                }
                count = 1;
                for (int i = 0; i < first_b.Count; i++)
                {
                    if (i > 0)
                    {
                        if (first_b[i] != first_b[i - 1])
                        {
                            if (count > 1)
                            {
                                richTextBox3.Text = richTextBox3.Text + first_b[i - 1].ToString() + "^" + count.ToString() + "*";
                            }
                            else
                            {
                                richTextBox3.Text = richTextBox3.Text + first_b[i - 1].ToString() + "*";
                            }
                            count = 1;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                if (count > 1)
                {
                    richTextBox3.Text = richTextBox3.Text + first_b[first_b.Count - 1].ToString() + "^" + count.ToString();
                }
                else
                {
                    richTextBox3.Text = richTextBox3.Text + first_b[first_b.Count - 1].ToString();
                }
                List<int> common = new List<int>();
                for (int i = 0; i< first_a.Count; i++)
                {
                    if (first_b.Contains(first_a[i]))
                    {
                        common.Add(first_a[i]);
                        first_b.Remove(first_a[i]);
                    }
                }
                int prod = 1;
                for (int i = 0; i<common.Count; i++)
                {
                    prod = prod * common[i];
                }
                label17.Text = label17.Text + prod.ToString();

            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel4.Visible = false;
        }

        private List<int> Euklidis(List<int> nums,int turn)
        {
            if (nums[2] == 0)
            {
                label28.Text = label28.Text + nums[0].ToString();
                richTextBox6.Text += "Βήμα " + turn.ToString() + ":\n";
                richTextBox6.Text += "x= " + nums[0].ToString() + ":\n";
                richTextBox6.Text += "y= " + nums[1].ToString() + ":\n";
                richTextBox6.Text += "z= " + nums[2].ToString() + ":\n";
                turns = 0;
                nums.Clear();
                button8.Text = "Εκτέλεση";
            }
            else
            {
                richTextBox6.Text += "Βήμα " + turn.ToString() + ":\n";
                richTextBox6.Text += "x= " + nums[0].ToString() + ":\n";
                richTextBox6.Text += "y= " + nums[1].ToString() + ":\n";
                richTextBox6.Text += "z= " + nums[2].ToString() + ":\n";
                nums[2] = nums[0] % nums[1];
                nums[0] = nums[1];
                nums[1] = nums[2];

            }
            return nums;
        }
        int turns = 0;
        List<int> nums = new List<int>();
        private void button8_Click(object sender, EventArgs e)
        {
            if (turns == 0)
            {
                int a = 0;
                int b = 0;
                label28.Text = "Μέγιστος Κοινός Διαιρέτης: ";
                richTextBox6.Text = "";
                if (textBox5.Text == "" || textBox6.Text == "")
                {
                    label30.Text = "Συμπλήρωσε τα πεδία!";
                }
                else
                {
                    a = Int32.Parse(textBox5.Text);
                    b = Int32.Parse(textBox6.Text);
                    int z = b;
                    nums.Add(a);
                    nums.Add(b);
                    nums.Add(z);
                    turns += 1;
                    button8.Text = "Επόμενο Βήμα";
                    nums = Euklidis(nums,turns);
                }
            }
            else
            {
                turns += 1;
                nums = Euklidis(nums, turns);
            }
        }
    }
}
