using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kript3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRota_Click(object sender, EventArgs e)
        {
            string metin = txtRota.Text.Trim();
            metin = metin.Replace(" ", string.Empty);
            char[] dizi = metin.ToCharArray();
            int eskiboyut = dizi.Length;
            int sutun = Convert.ToInt32(txtAnahtar.Text);
            int satir = (Int32)Math.Ceiling((float)dizi.Length / sutun);
            Array.Resize(ref dizi, satir * sutun);
            for (int i = eskiboyut; i < satir * sutun; i++)
            {
                dizi[i] = 'X';
            }
            char[,] rotamatrisi = new char[satir, sutun];

            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    rotamatrisi[i, j] = dizi[i * sutun + j];
                }
            }
            string sifrelimetin = "";
            for (int i = sutun - 1, j = 0; i >= 0; i--, j++)
            {
                for (int k = i - 1; k >= j; k--)
                    sifrelimetin += rotamatrisi[k, j];
                for (int k = j + 1; k < i; k++)
                    sifrelimetin += rotamatrisi[j, k];
                for (int k = j; k < i; k++)
                    sifrelimetin += rotamatrisi[k, i];
                for (int k = i - 1; k > j; k--)
                    sifrelimetin += rotamatrisi[i - 1, k];
            }
            label1.Text = sifrelimetin;


            /////cozumleme
            dizi = new char[sifrelimetin.Length];
            dizi = sifrelimetin.ToCharArray();
            string cozulenmetin = "";
            rotamatrisi = new char[sifrelimetin.Length / sutun, sutun];
            int a = 0;
            for (int i = sutun - 1, j = 0; i >= 0; i--, j++)
            {
                for (int k = i - 1; k >= j; k--)
                { rotamatrisi[k, j] = dizi[a]; a++; }
                for (int k = j + 1; k < i; k++)
                { rotamatrisi[j, k] = dizi[a]; a++; }
                for (int k = j; k < i; k++)
                { rotamatrisi[k, i] = dizi[a]; a++; }
                for (int k = i - 1; k > j; k--)
                { rotamatrisi[i - 1, k] = dizi[a]; a++; }
            }
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    cozulenmetin += rotamatrisi[i, j];
                }
            }
            label6.Text = cozulenmetin;
        }

        private void btnZigzag_Click(object sender, EventArgs e)
        {
            string metin = txtZigzag.Text.Trim();
            metin = metin.Replace(" ", string.Empty);
            int boyut = Convert.ToInt32(txtZigAnhtr.Text);
            char[] dizi = metin.ToCharArray();
            char[,] zigzagMatrisi = new char[boyut, dizi.Length];
            int x = 0; int y = 0;
            int sayac = 0;
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < dizi.Length; j++)
                {
                    zigzagMatrisi[i, j] = 'X';
                }
            }
            for (int i = 0; i < dizi.Length; i++)
            {

                if (y % (boyut - 1) == 0 && x != 0)
                {
                    sayac = 1;


                }

                if (sayac == 1)
                {

                    zigzagMatrisi[x, y] = dizi[i];
                    x--;
                    y++;
                    if (y % (boyut - 1) == 0 && x == 0)
                    {
                        sayac = 0;
                    }
                }
                else
                {

                    zigzagMatrisi[x, y] = dizi[i]; x++; y++;
                }



            }
            string yenimetin = "";
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < dizi.Length; j++)
                {
                    if (zigzagMatrisi[i, j] != 'X')
                    {
                        yenimetin += zigzagMatrisi[i, j];
                    }
                }
            }

            label2.Text = yenimetin;
            dizi = new char[yenimetin.Length];
            dizi = yenimetin.ToCharArray();
            zigzagMatrisi = new char[boyut, dizi.Length];
            x = 0; y = 0;
            sayac = 0;
            //    ////////////ÇÖZÜMLEME

            for (int i = 0; i < dizi.Length; i++)
            {

                if (y % (boyut - 1) == 0 && x != 0)
                {
                    sayac = 1;


                }

                if (sayac == 1)
                {

                    zigzagMatrisi[x, y] = 'X';
                    x--;
                    y++;
                    if (y % (boyut - 1) == 0 && x == 0)
                    {
                        sayac = 0;
                    }
                }
                else
                {

                    zigzagMatrisi[x, y] = 'X'; x++; y++;
                }



            }
            int a = 0;
            for (int j = 0; j < boyut; j++)
            {


                for (int i = 0; i < dizi.Length; i++)
                {
                    if (zigzagMatrisi[j, i] == 'X')
                    {
                        zigzagMatrisi[j, i] = dizi[a];
                        a++;
                    }
                }
            }

            ///okutma 
            x = 0;
            y = 0; sayac = 0;
            string cozulenmetin = "";
            for (int i = 0; i < dizi.Length; i++)
            {

                if (y % (boyut - 1) == 0 && x != 0)
                {
                    sayac = 1;


                }

                if (sayac == 1)
                {

                    cozulenmetin += zigzagMatrisi[x, y];
                    x--;
                    y++;
                    if (y % (boyut - 1) == 0 && x == 0)
                    {
                        sayac = 0;
                    }
                }
                else
                {

                    cozulenmetin += zigzagMatrisi[x, y]; x++; y++;
                }



            }


            label3.Text = cozulenmetin;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnhill_Click(object sender, EventArgs e)
        {
            char[] alfabe = { 'q','a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g',
                                          'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n', 
                                          'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü',
                                          'v', 'y', 'z' };
            string metin = txtHil.Text;
            // int anahtar = Convert.ToInt32(txtHillanahtar.Text);
            int[,] matris = { { 3, 2, 4 }, { 1, 3, 5 }, { 0, 2, 1 } };
      
            char[] chmetin = metin.ToCharArray(); string sonuc = "";
            int sayı = (int)Math.Ceiling((double)(chmetin.Length / 3));
            int sayac = 0;
            int[,] ntmetin = new int[sayı, 3];
            int[,] sifrelimatris = new int[sayı, 3];
            for (int i = 0; i < sayı; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ntmetin[i, j] = Array.IndexOf(alfabe, chmetin[sayac]);
                    sayac++;
                }

            }


            for (int i = 0; i < sayı; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {

                        sifrelimatris[i, j] += ntmetin[i, k] * matris[k, j];

                    }
                    sonuc += alfabe[sifrelimatris[i, j] % 29].ToString();
                }
            }
            lblHill.Text = sonuc;
        //////ÇÖZME
          int detA= Determinant(matris);
            int[,] cofMat=new int[matris.GetLength(0),matris.GetLength(1)];
            

            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    cofMat[i,j] = (int)Math.Pow(-1, (double)i + j) * Determinant(MinorMatrisi(matris, i, j));
                }
            }

            int deger=1;
            while(Math.Abs(detA)*deger%29!=1)
            {
                deger++;
            }
            if(detA<0)
            { deger = deger * (-1); }

            int[,] cofTranspoz = new int[matris.GetLength(0), matris.GetLength(1)];
            for (int j = 0; j < matris.GetLength(0); j++)
            {
                for (int i = 0; i < matris.GetLength(1); i++)
                {
                    cofTranspoz[i, j] = cofMat[j, i]; 
                }
            }
         
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    if(cofTranspoz[i, j] * deger<0)
                    {

                        cofTranspoz[i, j] = (cofTranspoz[i, j] * deger) + 29;
                    }
                    else cofTranspoz[i, j] = cofTranspoz[i, j] * deger;
                }
            }
            sonuc ="";
            chmetin = lblHill.Text.ToCharArray();
            int[,] sifrelimetinindex = new int[sayı, 3]; sayac = 0;
            for (int i = 0; i < sayı; i++)
            {
                for (int j = 0; j <matris.GetLength(0); j++)
                {
                    sifrelimetinindex[i, j] = Array.IndexOf(alfabe, chmetin[sayac]);
                    sayac++;
                }

            }
            sifrelimatris = new int[sayı, 3];
            for (int i = 0; i < sayı; i++)
            {
                for (int j = 0; j < matris.GetLength(0); j++)
                {
                    for (int k = 0; k <matris.GetLength(1); k++)
                    {

                        sifrelimatris[i,j] += (sifrelimetinindex[i, k]) * cofTranspoz[k,j];

                    }
                    sonuc += alfabe[sifrelimatris[i, j]% 29].ToString();
                }
            }
            label13.Text = sonuc;

        }
        
        
        public static int[,] MinorMatrisi(int[,] matris, int x, int y)
        {
            int satir = matris.GetLength(0); int sutun = matris.GetLength(1);
            int[,] yenimatris = new int[satir - 1, sutun - 1];
            int sayx = 0, sayy = 0;
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {

                    if (i == x || j == y) { continue; } // satir=0, sutun=0 kapalı durumu için
                    else
                    {
                        yenimatris[sayx, sayy] = matris[i, j];
                        sayy++;
                        if (sayy == satir - 1) { sayy = 0; sayx++; }

                    }

                }

            }
            //    int cofaktor=Math.Pow(-1,(double)x+y)*
            return yenimatris;
        }
        public static int Determinant(int[,] Matris)
        {
            int sonuc = 0;
            int boyut = int.Parse(Math.Sqrt(Matris.Length).ToString());
            if (boyut == 1)
            {
                return Matris[0, 0];
            }
            else if (boyut == 2)
            {
                return Matris[0, 0] * Matris[1, 1] - Matris[0, 1] * Matris[1, 0];
            }
            for (int i = 0; i < boyut; i++)
            {
                int[,] gecicimatris = new int[boyut - 1, boyut - 1];

                gecicimatris = MinorMatrisi(Matris, 0, i);

                sonuc += Matris[0, i] * (int)Math.Pow(-1, (double)i) * Determinant(gecicimatris);

            }
            return sonuc;
        }
        private void btnRSA_Click(object sender, EventArgs e)
        {

        }
    }
}
         
           

        
        

    