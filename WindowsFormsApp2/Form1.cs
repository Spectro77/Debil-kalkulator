using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="" || textBox2.Text =="" || textBox3.Text == "")
            {
                MessageBox.Show("Wszystkie pola muszą być uzupełnione");
            }
            else
            {
                try
                {
                    double A = Convert.ToDouble(textBox1.Text);
                    double B = Convert.ToDouble(textBox2.Text);
                    double C = Convert.ToDouble(textBox3.Text);
                    if (A == 0)
                    {
                        MessageBox.Show("Wartość A nie może być równa 0");
                    }
                    else
                    {
                        richTextBox1.Text = "";
                        double DELTA = (B * B) - (4 * A * C);
                        double P = Math.Round((-B) / (2 * A),2);
                        double Q = Math.Round((-DELTA) / (4 * A),2);
                        double X1 = Math.Round(((-B) - Math.Sqrt(DELTA)) / (2 * A), 2);
                        double X2 = Math.Round(((-B) + Math.Sqrt(DELTA)) / (2 * A), 2);
                        double przedl_X1 = (((X1 - (P - X1)) * (X1 - (P - X1))) * A) + ((X1 - (P - X1)) * B) + C;
                        double przedl_X2 = (((X2 + (X2 - P)) * (X2 + (X2 - P))) * A) + ((X2 + (X2 - P)) * B) + C;
                        double iloczyn_pierw = C / A;
                        double suma_pierw = (-B) / A;
                        double suma_odwrot_pierw = (-B) / C;
                        double suma_odwrot_kwadrat_pierw = (((B * B) / A) - (2 * C)) / ((C * C) / A);
                        if (DELTA > 0)
                        {
                            richTextBox1.AppendText($"Delta = {DELTA}\n");
                            richTextBox1.AppendText($"W = [{P}, {Q}]\n");
                            richTextBox1.AppendText( $"X₁ = {X1}, X₂ = {X2}\n");
                            foreach (string opcje in checkedListBox1.CheckedItems)
                            {
                                switch (opcje)
                                {
                                    case "Kierunek ramion":
                                        if(A > 0)
                                        {
                                            richTextBox1.AppendText($"Ramiona są skierowane w górę\n");
                                        }
                                        if (A < 0)
                                        {
                                            richTextBox1.AppendText($"Ramiona są skierowane w dół\n");
                                        }
                                        break;
                                    case "Punkt przecięcia osi oY":
                                        richTextBox1.AppendText($"Punkt przecięcia osi oY: {C}\n");
                                        break;
                                    case "Iloczyn pierwiastków":
                                        richTextBox1.AppendText($"Iloczyn pierwiastków: {iloczyn_pierw}\n");
                                        break;
                                    case "Suma pierwiastków":
                                        richTextBox1.AppendText($"Suma pierwiastków: {suma_pierw}\n");
                                        break;
                                    case "Suma odwrotności pierwiastków":
                                        richTextBox1.AppendText($"Suma odwrotności pierwiastków: {suma_odwrot_pierw}\n");
                                        break;
                                    case "Suma odwrotności kwadratów pierwiastków":
                                        richTextBox1.AppendText($"Suma odwrotności kwadratów pierwiastków: {suma_odwrot_kwadrat_pierw}\n");
                                        break;
                                }
                            }
                            this.chart1.Series["Miejsca zerowe"].Points.Clear();
                            this.chart1.Series["Miejsca zerowe"].Points.AddXY(X1, 0);
                            this.chart1.Series["Miejsca zerowe"].Points.AddXY(X2, 0);
                            this.chart1.Series["Funkcja"].Points.Clear();
                            this.chart1.Series["Funkcja"].Points.AddXY(X1-(P-X1), przedl_X1);
                            this.chart1.Series["Funkcja"].Points.AddXY(X1, 0);
                            this.chart1.Series["Funkcja"].Points.AddXY(P, Q);
                            this.chart1.Series["Funkcja"].Points.AddXY(X2, 0);
                            this.chart1.Series["Funkcja"].Points.AddXY(X2+(X2-P), przedl_X1);
                            this.chart1.Series["Wierzchołek"].Points.Clear();
                            this.chart1.Series["Wierzchołek"].Points.AddXY(P, Q);


                        }
                        if(DELTA == 0)
                        {
                            richTextBox1.AppendText($"Delta = {DELTA}\n");
                            richTextBox1.AppendText($"W = [{P}, {Q}]\n");
                            richTextBox1.AppendText($"X₀ = {X1}\n");
                            foreach (string opcje in checkedListBox1.CheckedItems)
                            {
                                switch (opcje)
                                {
                                    case "Kierunek ramion":
                                        if (A > 0)
                                        {
                                            richTextBox1.AppendText($"Ramiona są skierowane w górę\n");
                                        }
                                        if (A < 0)
                                        {
                                            richTextBox1.AppendText($"Ramiona są skierowane w dół\n");
                                        }
                                        break;
                                    case "Punkt przecięcia osi oY":
                                        richTextBox1.AppendText($"Punkt przecięcia osi oY: {C}\n");
                                        break;
                                }
                            }
                            this.chart1.Series["Funkcja"].Points.Clear();
                            this.chart1.Series["Miejsca zerowe"].Points.Clear();
                            this.chart1.Series["Wierzchołek"].Points.Clear();
                            this.chart1.Series["Funkcja"].Points.AddXY(X1, 0);
                            this.chart1.Series["Funkcja"].Points.AddXY(P, Q);
                        }
                        if (DELTA < 0)
                        {
                            richTextBox1.AppendText($"Delta = {DELTA}\n");
                            richTextBox1.AppendText($"W = [{P}, {Q}]\n");
                            richTextBox1.AppendText("Funkcja nie ma miejsc zerowych\n");
                            foreach (string opcje in checkedListBox1.CheckedItems)
                            {
                                switch (opcje)
                                {
                                    case "Kierunek ramion":
                                        if (A > 0)
                                        {
                                            richTextBox1.AppendText($"Ramiona są skierowane w górę\n");
                                        }
                                        if (A < 0)
                                        {
                                            richTextBox1.AppendText($"Ramiona są skierowane w dół\n");
                                        }
                                        break;
                                    case "Punkt przecięcia osi oY":
                                        richTextBox1.AppendText($"Punkt przecięcia osi oY: {C}\n");
                                        break;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Wartość jest zbyt duża lub nieprawidłowa");
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
