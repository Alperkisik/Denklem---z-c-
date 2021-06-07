using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denklem_Çözücü
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList leftSide = new ArrayList();
            ArrayList RightSide = new ArrayList();
            string terim = "",AnaTerim = "";
            double Rtopla=0, Rçıkar=0,Ltopla = 0, Lçıkar = 0;
            AnaTerim = textBox1.Text.ToString();

            int count = 0;
            do
            {
                terim += AnaTerim[count];
                count++;
                if (AnaTerim[count].ToString() == "+" || AnaTerim[count].ToString() == "-")
                {
                    leftSide.Add(terim);
                    terim = "";
                }
                else if(AnaTerim[count].ToString() == "=")
                {
                    leftSide.Add(terim);
                    terim = "";
                    count++;
                    break;
                }
                
            } while (count < AnaTerim.Length);

            do
            {
                terim += AnaTerim[count];
                count++;
                try
                {
                    if (AnaTerim[count].ToString() == "+" || AnaTerim[count].ToString() == "-")
                    {                    
                        RightSide.Add(terim);
                        terim = "";
                    }
                }
                catch
                {
                    RightSide.Add(terim);
                    terim = "";
                    break;
                }
            } while (count < AnaTerim.Length);

            terim = "";
            bool xYok = true;
            for (int i = 0; i < leftSide.Count; i++)
            {
                terim = leftSide[i].ToString();
                for (int y = 0; y < terim.Length; y++)
                {
                    if (terim[y] != 'x')
                        xYok = true;
                    else
                    {
                        xYok = false;
                        break;
                    }
                        
                }
                if(xYok)
                {
                    leftSide.RemoveAt(i);
                    if (terim[0] == '+')
                        terim = terim.Replace('+','-');
                    else if (terim[0] == '-')
                        terim = terim.Replace('-', '+');
                    RightSide.Add(terim);
                }
            }

            terim = "";
            bool xVar = true;
            for (int t = 0; t < RightSide.Count; t++)
            {
                terim = RightSide[t].ToString();
                for (int y = 0; y < terim.Length; y++)
                {
                    if (terim[y] == 'x')
                    {
                        xVar = true;
                        break;
                    } 
                    else
                        xVar = false;
                       
                }
                if(xVar)
                {
                    RightSide.RemoveAt(t);
                    if (terim[0] == '+')
                        terim = terim.Replace('+', '-');
                    else if (terim[0] == '-')
                        terim = terim.Replace('-', '+');
                    leftSide.Add(terim);
                }
            }

            terim = "";
            string yeni_terim = "";
            bool Have_Divide = false;
            bool reach_divide = false;
            bool üst=false, alt=false;
            string pay = "", payda = "";
            int a = 1;
            for (int i = 0; i < leftSide.Count; i++)
            {
                a = 1;
                terim = leftSide[i].ToString();
                for (int j = 1; j < (terim.Length)-a; j++)
                {
                    yeni_terim += terim[j];
                    if (terim[j] == '/')
                    {
                        Have_Divide = true;
                        a = 0;
                    }
                }

                if (terim[0] == '+')
                {
                    if (!Have_Divide)
                        Ltopla += Convert.ToDouble(yeni_terim);
                    else
                    {
                        pay = "";payda = ""; üst = false; alt = false; reach_divide = false;
                        for (int z = 0; z < yeni_terim.Length; z++)
                        {
                            if (yeni_terim[z] == '/')
                                reach_divide = true;
                            if(!reach_divide)
                            {
                                pay += yeni_terim[z];
                                if (yeni_terim[z] == 'x')
                                    üst = true;
                                else
                                    üst = false;
                            }
                            else
                            {
                                try
                                {
                                    payda += yeni_terim[z + 1];
                                    if (yeni_terim[z + 1] == 'x')
                                        alt = true;
                                    else
                                        alt = false;
                                }
                                catch { break; }
                            }
                        }

                        if(alt && !üst)
                        {
                            
                        }
                        else if(üst && !alt)
                        {
                            string newPay = "";
                            for (int g = 0; g < pay.Length-1; g++)
                            {
                                newPay += pay[g];
                            }
                            Ltopla += (Convert.ToDouble(newPay) / Convert.ToDouble(payda)); 
                        }
                    }
                }
                else if (terim[0] == '-')
                {
                    if (!Have_Divide)
                        Lçıkar += Convert.ToDouble(yeni_terim);
                    else
                    {
                        pay = ""; payda = ""; üst = false; alt = false;
                        reach_divide = false;
                        for (int z = 0; z < yeni_terim.Length; z++)
                        {
                            if (yeni_terim[z] == '/')
                                reach_divide = true;
                            if(!reach_divide)
                            {
                                pay += yeni_terim[z];
                                if (yeni_terim[z] == 'x')
                                    üst = true;
                                else
                                    üst = false;
                            }
                            else
                            {
                                try
                                {
                                    payda += yeni_terim[z + 1];
                                    if (yeni_terim[z + 1] == 'x')
                                        alt = true;
                                    else
                                        alt = false;
                                }
                                catch { break; }
                            }
                        }
                        if (alt && !üst)
                        {

                        }
                        else if (üst && !alt)
                        {
                            string newPay = "";
                            for (int g = 0; g < pay.Length - 1; g++)
                            {
                                newPay += pay[g];
                            }
                            Lçıkar += (Convert.ToDouble(newPay) / Convert.ToDouble(payda));
                        }
                    }
                }
                yeni_terim = "";
                Have_Divide = false;
                reach_divide = false;
            }

            yeni_terim = "";
            terim = "";
            Have_Divide = false;
            reach_divide = false;
            for (int i = 0; i < RightSide.Count; i++)
            {
                terim = RightSide[i].ToString();
                for (int j = 1; j < terim.Length; j++)
                {
                    yeni_terim += terim[j];
                    if (terim[j] == '/')
                        Have_Divide = true;
                }

                if (terim[0] == '+')
                {
                    if(Have_Divide == false)
                        Rtopla += Convert.ToDouble(yeni_terim);
                    else
                    {
                        pay = ""; payda = "";
                        for (int z = 0; z < yeni_terim.Length; z++)
                        {
                            if (yeni_terim[z] == '/')
                                reach_divide = true;

                            if (!reach_divide)
                                pay += yeni_terim[z];
                            else
                            {
                                try { payda += yeni_terim[z + 1]; }
                                catch { break; }
                            }
                        }
                        Rtopla += (Convert.ToDouble(pay) / Convert.ToDouble(payda));
                    }
                }
                else if(terim[0] == '-')
                {
                    if(Have_Divide == false)
                        Rçıkar += Convert.ToDouble(yeni_terim);
                    else
                    {
                        pay = ""; payda = ""; reach_divide = false;
                        for (int z = 0; z < yeni_terim.Length; z++)
                        {
                            if (yeni_terim[z] == '/')
                                reach_divide = true;

                            if(!reach_divide)
                                pay += yeni_terim[z];
                            else
                            {
                                try { payda += yeni_terim[z + 1]; }
                                catch { break; }
                            }  
                        }
                        Rçıkar += (Convert.ToDouble(pay) / Convert.ToDouble(payda));
                    }
                }
                yeni_terim = "";
                Have_Divide = false;
            }

            double rightSide_Result = Rtopla - Rçıkar;
            double leftSİde_Result = Ltopla - Lçıkar;
            double xDegeri = rightSide_Result/leftSİde_Result;
            string qwe = "",asd="";
            for (int j = 0; j < RightSide.Count; j++)
            {
                qwe += RightSide[j];
            }
            for (int z = 0; z < leftSide.Count; z++)
            {
                asd += leftSide[z];
            }
            MessageBox.Show("denklem : " + asd + " toplam = " + leftSİde_Result + "x","Left Side");
            MessageBox.Show("denklem : " + qwe + " toplam = " + rightSide_Result,"Right Side");
            MessageBox.Show("Denklem : " + AnaTerim + " Denklemin sonucu : " + rightSide_Result + "/" + leftSİde_Result + " = " + xDegeri);
            //-7x=+49 çalıştı
            //+6x=+10-5x çalıştı
            //+5x+15=+4x-5; çalıştı

            //double ert = (5.0 / 2.7) + 3.0;
            //MessageBox.Show(ert.ToString());
            
            //+5x+4/5=+20  çalıştı
            //+5x/6+7=-4x/5-8 çalıştı
            //+1/2+4x=+10 çalıştı

            //+2x/5+5=+4x+10 çalıştı
        }
    }
}
