﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
namespace Sınav_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=a.accdb");
        void cek()
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand("Select * From Ogrenciler order by rnd(-ID*Time())", bag);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                listBox1.Items.Add(oku["Ad"] + " " + oku["Soyad"]);
               

            }
            bag.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            cek();
            label3.Text = listBox1.Items.Count.ToString();
           
           
            
            
	
		 
	
            
            


        }


        ArrayList sıralar = new ArrayList();
        int sayı = 0;
        int kalanlar = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Button item in groupBox1.Controls)
            {
                sayı++;
                for (int i = 0; i < sayı; i++)
                {
                    item.Text = listBox1.Items[i].ToString();
                }
                label1.Text = sayı.ToString();
            }
            kalanlar = listBox1.Items.Count - sayı;
            label2.Text = kalanlar.ToString();
            for (int i = listBox1.Items.Count - 1; i >= sayı; i--)
            {
                listBox2.Items.Add(listBox1.Items[i]);
            }
           Form yenisınıf = new Form();
            yenisınıf.Size = new Size(924, 605);
            int butonSayisi = 30;
            int sol = 1; //formun sol tarafından atanan değer
            int alt = 50; // formun üst tarafından atanan değer
            int bol; // bolme işlemindeki amaç formun boyutuna göre butonları sıralı bir şekilde görebilmek için
            bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonSayisi)));
            for (int i = 0; i < butonSayisi; i++)  // girilen buton sayısına göre döngü şartı sağlanana kadar oluşturmakta
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.AutoSize = false;
                btn.Size = new Size(yenisınıf.Width / bol, yenisınıf.Height / (bol * 2));
                btn.Text = this.listBox2.Items[i].ToString();            
                btn.Font = new Font(btn.Font.FontFamily.Name, 10 );
                btn.Location = new Point(sol, alt);
                btn.FlatStyle = FlatStyle.Flat;
                yenisınıf.Controls.Add(btn);
                sol += btn.Width + 5;
                if (sol + this.Width / bol > this.Width) // bunu yapmasaydık butonlar yan yana dizilir alt satıra geçmedi
                {
                    sol = 1;
                    alt += this.Height / (bol * 2) + 5;
                }             
            }
            yenisınıf.Show();
           
        }
    }
}
