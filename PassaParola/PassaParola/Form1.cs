using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace PassaParola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += new EventHandler(Form1_Load);
        }

        int soruNo = 0, dogru = 0, yanlis = 0;

        private readonly Dictionary<int, (string soru, string cevap)> sorular = new Dictionary<int, (string, string)>
        {
            { 1, ("Ülkemizin güney kısmındaki kıyı bölgesi ?", "akdeniz") },
            { 2, ("Yeşili ile ünlü marmaradaki ilimiz ?", "bursa") },
            { 3, ("Müslümanların kutsal günü ?", "cuma") },
            { 4, ("Karpuzuyla ünlü ilimiz ?", "diyarbakır") },
            { 5, ("Yeni kelimesinin zıt anlamı ?", "eski") },
            { 6, ("Padişahın emirlerinin yazılı hali ?", "ferman") },
            { 7, ("Dünyanın ısı kaynağı ?", "güneş") },
            { 8, ("Öğrencilerin kötü karne getirince bakıştığı nesne ?", "halı") },
            { 9, ("Gülüyle ünlü ilimiz ?", "ısparta") },
            { 10, ("Mersinin diğer ismi ?", "akdeniz") },
            { 11, ("Askeri bir topluluk ?", "jandarma") },
            { 12, ("Malatyanın meşhur meyvesi ?", "kayısı") },
            { 13, ("Yılın 3. ayı ?", "mart") },
            { 14, ("Üflemeli bir müzik aleti ?", "ney") },
            { 15, ("Halk Şairi ?", "ozan") },
            { 16, ("Çocukların pek sevmediği pirinç, havuç gibi sebzeler ile yapılan yemek ?", "pırasa") },
            { 17, ("11 Ayın Sultanı ?", "ramazan") },
            { 18, ("İngilizce'de yılan ?", "snake") },
            { 19, ("Türkiye'nin megastarı ?", "tarkan") },
            { 20, ("ümit kelimesinin eş anlamlısı ?", "umut") },
            { 21, ("Kahvaltısı ile ünlü ilimiz ?", "van") },
            { 22, ("Şimşek kelimesinin eş anlamlısı ?", "yıldırım") },
            { 23, ("Ege bölgesinin en çok ağacı bulunan, yağı da yapılan bir kahvaltı besini ?", "zeytin") }
        };

        private readonly Dictionary<int, Button> butonlar = new Dictionary<int, Button>();

        private void Form1_Load(object sender, EventArgs e)
        {
            butonlar.Add(1, button1);
            butonlar.Add(2, button2);
            butonlar.Add(3, button3);
            butonlar.Add(4, button4);
            butonlar.Add(5, button5);
            butonlar.Add(6, button6);
            butonlar.Add(7, button7);
            butonlar.Add(8, button8);
            butonlar.Add(9, button9);
            butonlar.Add(10, button24);
            butonlar.Add(11, button10);
            butonlar.Add(12, button11);
            butonlar.Add(13, button12);
            butonlar.Add(14, button13);
            butonlar.Add(15, button14);
            butonlar.Add(16, button15);
            butonlar.Add(17, button16);
            butonlar.Add(18, button17);
            butonlar.Add(19, button18);
            butonlar.Add(20, button19);
            butonlar.Add(21, button20);
            butonlar.Add(22, button21);
            butonlar.Add(23, button22);
            butonlar.Add(24, button23);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sorular.TryGetValue(soruNo, out var soruCevap) && butonlar.TryGetValue(soruNo, out var button))
                {
                    string verilenCevap = textBox1.Text.ToLower();
                    string dogruCevap = soruCevap.cevap.ToLower();

                    if (verilenCevap == dogruCevap)
                    {
                        button.BackColor = Color.Green;
                        dogru++;
                        label2.Text = dogru.ToString();
                    }
                    else
                    {
                        button.BackColor = Color.Red;
                        yanlis++;
                        label3.Text = yanlis.ToString();
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Text = "Sonraki";
            soruNo++;
            this.Text = soruNo.ToString();

            if (sorular.TryGetValue(soruNo, out var soruCevap) && butonlar.TryGetValue(soruNo, out var button))
            {
                richTextBox1.Text = soruCevap.soru;
                button.BackColor = Color.Yellow;
            }
        }
    }
}
