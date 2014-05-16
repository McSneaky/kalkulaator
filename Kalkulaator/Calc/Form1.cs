using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
// ||
namespace Calc
{
    public partial class Form1 : Form
    {

#region Funktsioonid 
        //F = Function; t = tehte textBox_Tehe; v = vastuse textBox_Vastus
        // tehte stringi pikkus
        public int FtPikkus()
        {
            int pikkus = textBox_Tehe.Text.Length;
            return pikkus;
        }
         
        // Leiab viimase char tehte textBoxis 
        public string FtViimane()
        {
            // Leiab viimase tähe textBox_tehe inputis
            string tViimane = Convert.ToString(textBox_Tehe.Text).Substring(Convert.ToString(textBox_Tehe.Text).Length - 1);
            return tViimane;
        }

        // Kustutab viimase char tehte textBoxis
        public void FtRemLast()
        {
            string temp = textBox_Tehe.Text.Substring(0, textBox_Tehe.Text.Length - 1); // Kustutab viimase tähe textBox_tehe sees
            textBox_Tehe.Text = temp; // Muudab teksti ära tektBox_Tehe sees eemaldab viimase
        } 
        
        // Viimase operaatori kontroll (tehtemärgi)
        public string op = "Test_Fop";
        public void Fop_check()
        {   // Kontrollib et viimane viimane asi ei oleks tehtemärk, et ei tekiks ++ olukorda
            if (FtViimane() != "+" && FtViimane() != "-" && FtViimane() != "*" && FtViimane() != "/" && FtViimane() != "." && FtViimane() != "(")
            {
                textBox_Tehe.AppendText(op); // Kui ei ole topelt, lisab tehtemärgi
            }
            else { textBox_Vastus.Text = ("2 märki järjest!"); }
        }

        // Arvutamise osa
        public string FArvutamine()
        {
            try
            {
                var result = new DataTable().Compute(textBox_Tehe.Text, null); // Arvutab stringi
                textBox_Vastus.Text = Convert.ToString(result); // Paneb vastuse teisse kasti
                return Convert.ToString(result);
            }
            catch (SyntaxErrorException) // Viskab errori, kui tehte kastis on midagi valesti
            {
                MessageBox.Show("Viga arvutamisel", "Error!");
                return "Test_Farvutamine";
            }
            catch (OverflowException)
            {
                textBox_Vastus.Text = ("Arv liiga suur");
                return "Test_Farvutamine";
            }
        }

        // Gray out box
        public void FtvGray()
        {
            if (checkBox_Gray.Checked == true) // Kui on linnuke
            {
                textBox_Tehe.Enabled = false; // Teeb halliks mõlemad kastid
                textBox_Vastus.Enabled = false;
            }
            else // Kui ei ole linnukest
            {
                textBox_Tehe.Enabled = true; // Laseb kirjutada mõlemasse kasi
                textBox_Vastus.Enabled = true;
            }
        }

        // Süsteemide muutmine 2, 8, 10
        public void Fbase_2()
        {
            try
            {
                FArvutamine();
                int temp = Convert.ToInt32(textBox_Vastus.Text);
                textBox_Vastus.Text = (Convert.ToString(temp, 2));
            }
            catch (OverflowException)
            { textBox_Vastus.Text = ("Arv liiga suur"); }
            catch (SyntaxErrorException)
            { textBox_Vastus.Text = ("Sisestus viga"); }
            catch (FormatException)
            { textBox_Vastus.Text = ("Ei teisenda koma arve"); }
        }

        public void Fbase_8()
        {
            try
            {
                FArvutamine();
                int temp = Convert.ToInt32(textBox_Vastus.Text);
                textBox_Vastus.Text = (Convert.ToString(temp, 8));
            }
            catch (OverflowException)
            { textBox_Vastus.Text = ("Arv liiga suur"); }
            catch (SyntaxErrorException)
            { textBox_Vastus.Text = ("Sisestus viga"); }
            catch (FormatException)
            { textBox_Vastus.Text = ("Ei teisenda koma arve"); }
        }

        public void Fbase_10()
        {
            try
            {
                FArvutamine();
                int temp = Convert.ToInt32(textBox_Vastus.Text);
                textBox_Vastus.Text = (Convert.ToString(temp, 10));
            }
            catch (OverflowException)
            { textBox_Vastus.Text = ("Arv liiga suur"); }
            catch (SyntaxErrorException)
            { textBox_Vastus.Text = ("Sisestus viga"); }
            catch (FormatException)
            { textBox_Vastus.Text = ("Ei teisenda koma arve"); }
        }

        // 0 jagamise poolik kontroll
        /*public bool Ft0Divide()
        {
            /*
            var pos_temp = textBox_Tehe.Text.IndexOf("/");
            List<int> pos_list = new List<int>();
            pos_list.Add(pos_temp);*/
            /*return true;
        }*/

#endregion
        // Programm alguses
        public Form1()
        {
            InitializeComponent();
            FtvGray();
        }

#region Nupud
        // Buttons
        private void button_Equal_Click(object sender, EventArgs e)
        {
            FArvutamine();
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("0");
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("1");
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("2");
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("3");
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("4");
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("5");
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("6");
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("7");
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("8");
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("9");
        }

        // Operator
        private void button_Add_Click(object sender, EventArgs e)
        {
            if (FtPikkus() != 0) // Kontroll, et + ei oleks esimene märk
            { op = "+"; Fop_check(); } // Lisab + märgi
            else { Debug.WriteLine("+ märk alguses"); }
        }
        private void button_Minus_Click(object sender, EventArgs e)
        {
            if (FtPikkus() == 0) // Saab alustada - märgiga
            {
                textBox_Tehe.Text = "-"; // Lisab - märgi
            }
            else if (FtPikkus() != 0) // Et ei saaks panna 2 - märki järjest
            {
                op = "-"; // Lisab - märgi ja teeb veakontrolli järgmisel real
                Fop_check();
            }
            else { textBox_Vastus.Text = ("2x -"); }
        }
        private void button_Multiply_Click(object sender, EventArgs e)
        {
            if (FtPikkus() != 0) // Et ei saaks alustada * märgiga
            { op = "*"; Fop_check(); } // Lisab *
            else { textBox_Vastus.Text = ("* tehte alguses"); }
        }
        private void button_Divide_Click(object sender, EventArgs e)
        {
            if (FtPikkus() != 0) // Et ei saaks alustada / märgiga
            { op = "/"; Fop_check(); } // Lisab /
            else { textBox_Vastus.Text = ("/ tehte alguses"); }
        }
        // Clean
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Tehe.Clear(); // tühjendab tehte kasti
            textBox_Vastus.Clear(); // tühjendab vastuse kasti
        }
        private void button_Back_Click(object sender, EventArgs e)
        {
            if (FtPikkus() != 0) // Kontrollib kas on märke
            {
                FtRemLast(); // Kustutab viimase märgi
            }
            else { textBox_Vastus.Text = ("Pole rohkem kustutada"); }
        }
        // Lisa
        private void button_Coma_Click(object sender, EventArgs e)
        {
            if (FtPikkus() != 0) // Et ei saaks alustada . märgiga
            { op = "."; Fop_check(); } // Lisab .
            else { textBox_Vastus.Text = (". alguses"); }
        }

        private void button_SulA_Click(object sender, EventArgs e)
        {
            textBox_Tehe.AppendText("(");
        }

        private void button_SulV_Click(object sender, EventArgs e)
        {
            if (FtPikkus() != 0) // Et ei saaks alustada ) märgiga
            { op = ")"; Fop_check(); } // Lisab )
            else { textBox_Vastus.Text = (") alguses"); }
        }


#endregion

#region Lisad(checkBox, textBox jne..)
        private void checkBox_Gray_CheckedChanged(object sender, EventArgs e)
        {
            FtvGray();
        }

        // Base
        private void button_teisenda_Click(object sender, EventArgs e)
        {
            if (radioButton_2.Checked == true)
            {
                Fbase_2();
            }
            else if (radioButton_8.Checked == true)
            {
                Fbase_8();
            }
            else if (radioButton_10.Checked == true)
            {
                Fbase_10();
            }
        }
#endregion
    }
}