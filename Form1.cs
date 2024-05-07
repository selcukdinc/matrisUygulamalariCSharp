namespace MatrisDondurme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbEkran.SelectionAlignment = HorizontalAlignment.Center;
            rbMainMatris.Checked = true;
            cbRandom.Checked = true;
            cbRandom.Checked = false;
            pDondur.Enabled = false;
        }

        int[,] mainMatris;
        
        Random R = new Random();
        
        int[,] ornekMatris = new int[3, 3]{
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
        
        bool mOrnek;

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            rtbEkran.Text = "";
            if (mOrnek)
            {
                matrisYazdir(Satir.yazdir, ornekMatris);
            }
            else
            {
                matrisOlustur(Convert.ToInt32(mtbSatir.Text), Convert.ToInt32(mtbSutun.Text), cbRandom.Checked, Convert.ToInt32(mtbRMin.Text), Convert.ToInt32(mtbRMax.Text), Convert.ToInt32(mtbBaslangic.Text));
                matrisYazdir(Satir.yazdir, mainMatris);
                pDondur.Enabled = true;
                cbSeviye.Items.Clear();
                for (int i = 0; i < Convert.ToInt32(mtbSatir.Text) / 2; i++)
                {
                    cbSeviye.Items.Add($"{i + 1}");
                }
                cbSeviye.Text = cbSeviye.Items[0].ToString();
            }

        }

        enum Satir
        {
            ust, sag, alt, sol, yazdir
        }

        enum Yon
        {
            sag, sol
        }


        // boyut, rastgelelik (bool), baþlangýç deðeri
        private void matrisOlustur(int satir, int sutun, bool randomStatus, int Rmin, int Rmax, int startValue)
        {
            mainMatris = new int[satir, sutun];
            if (randomStatus)
            {
                for (int i = 0; i < satir; i++)
                {
                    for (int j = 0; j < sutun; j++)
                    {
                        mainMatris[i, j] = R.Next(Rmin, Rmax + 1);
                    }
                }
            }
            else
            {
                for (int i = 0; i < satir; i++)
                {
                    for (int j = 0; j < sutun; j++)
                    {
                        mainMatris[i, j] = startValue++;
                    }
                }
            }
        }

        private void matrisYazdir(Satir sr, int[,] m)
        {
            int mSatir = m.GetLength(0);
            int mSutun = m.GetLength(1);
            switch (sr)
            {
                case Satir.yazdir:
                    for (int i = 0; i < mSatir; i++)
                    {
                        for (int j = 0; j < mSutun; j++)
                        {
                            rtbEkran.Text += $"{m[i, j]}\t";
                        }
                        rtbEkran.Text += $"\n\n";
                    }
                    rtbEkran.Text += $"\n";
                    break;
            }
        }

        private void matrisYazdir(Satir sr, int[,] m, int seviye)
        {
            int mSatir = m.GetLength(0);
            int mSutun = m.GetLength(1);
            switch (sr)
            {
                case Satir.yazdir:
                    for (int i = 0; i < mSatir; i++)
                    {
                        for (int j = 0; j < mSutun; j++)
                        {
                                rtbEkran.Text += $"{m[i, j]}\t";
                        }
                        rtbEkran.Text += $"\n\n";
                    }
                    rtbEkran.Text += $"\n";
                    break;
            }
        }

        private void cbRandom_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbRandom.Checked)
            {
                pNotR.Enabled = false;
                pR.Enabled = true;
            }
            else
            {
                pNotR.Enabled = true;
                pR.Enabled = false;
            }
        }

        private void matrisSecim(object sender, EventArgs e)
        {
            string main = $"{rbMainMatris.Name}";
            RadioButton rbSecim = (RadioButton)sender;
            if (rbSecim.Name == main)
            {
                pBoyutlanabilir.Enabled = true;
                mOrnek = false;
                pDondur.Enabled = true;
            }
            else
            {
                pBoyutlanabilir.Enabled = false;
                mOrnek = true;
                pDondur.Enabled = false;
            }
        }

        /*  
            0. seviye ortada, hareketsiz kýsým, 
            1. seviye => 0. seviyenin etrafýný çevreleyenler
            2. seviye => 1. seviyenin etrafýný çevreleyenler
            n. seviye => n-1 seviyenin etrafýný çevreleyenler
         */

        /* 

    5 x 5 matrisin 0. seviyesi
                                m[2,2]

    5 x 5 matrisin 1. seviyesi
                                m[1,1], m[1,2], m[1,3]
                                m[2,1]          m[2,3]
                                m[3,1], m[3,2], m[3,3]

    5 x 5 matrisin 2. seviyesi
                                m[0,0]  dýþ çerçevesi

*/

        /* 

            9 x 9 matrisin 0. seviyesi
                                        m[4,4]

            9 x 9 matrisin 1. seviyesi
                                        m[3,3], m[3,4], m[3,5]
                                        m[4,3]          m[4,5]
                                        m[5,3], m[5,4], m[5,5]

            9 x 9 matrisin 2. seviyesi
                                        m[2,2]

            9 x 9 matrisin 3. seviyesi
                                        m[1,1]

            9 x 9 matrisin 4. seviyesi
                                        m[0,0]  dýþ çerçevesi
        */

        /*

            Bir matrisin dýþ çerçevesini bulabilmek için 2'ye böler, ondalklý kýsmýný atarýz, bize maksimum seviyesini verir

         */

        // Toplam seviyesini bildiðimiz bir sistemin, en dýþtan baþlayarak hangi seviyenin hangi numaralalara ait olduðunu bulabiliriz

        /*
            seviyelerin matris büyüklükleri
                1.s  =>  3
                2.s  =>  5
                3.s  =>  7
                4.s  =>  9
        */

        private void mIlerlet( ref int[,] m, int seviye, Yon y)
        {
            // gelen matrisin 0. seviyesi nedir
            int mSeviye = m.GetLength(0) / 2;
            int ortaNokta = m[mSeviye, mSeviye];
            //MessageBox.Show($"Bu matrisin {mSeviye} seviyesi var, \niþlem yapýlmak istenen seviye : {seviye}\nOrta noktasý : {ortaNokta}");

            // Toplam seviyesini bildiðimiz bir sistemin, en dýþtan baþlayarak hangi seviyenin hangi numaralalara ait olduðunu bulabiliriz

            // en dýþ seviyeden baþla, seviye düþtükçe içleri birer arttýr
            
            int[] seviyeler = new int[mSeviye]; // 0, 1, 2, 3 indexlerine sahip
            int counter = 0;
            for (int i = mSeviye; i > 0; i--) // 4, 3, 2, 1
            {
                seviyeler[i - 1] = counter++; // seviyeler[3] = 0   ,   sevyeler[2] = 1,    seviyeler[1] = 2,   seviyeler[0] = 3
                /*
                    seviyeler[0] = 1. seviye
                    seviyeler[1] = 2. seviye
                    seviyeler[2] = 3. seviye
                    seviyeler[3] = 4. seviye
                 */
            }

            // mSeviye = 4 olsun, biz birinci seviyeyi yazdýrmak istiyoruz diyelim
            // 1. seviye için => metot çaðrýlýrken seviye deðiþkeni 1 olacak, seviyeler[seviye - 1];
            // 2. seviye için =>   2 olacak, seviyeler[seviye - 1];

            int mSeviyeBelirle = seviye * 2 + 1;
            int[,] seviyeX = new int[mSeviyeBelirle, mSeviyeBelirle];
            // (seviye * 2) + 1
            /*
                1 * 2 + 1 = 3
                2 * 2 + 1 = 5
             */
            int seviyeSatir = mSeviye - seviye;
            globalSeviye = seviyeSatir;
            for (int i = 0; i < mSeviyeBelirle; i++)
            {
                for (int j = 0; j < mSeviyeBelirle; j++)
                {
                    seviyeX[i, j] = m[seviyeSatir + i, seviyeSatir + j];
                }
            }

            //MessageBox.Show($"1. seviyenin ilk eleman serisi\n{seviye1[0, 0]}\t{seviye1[0, 1]}\t{seviye1[0, 2]}\n{seviye1[1, 0]}\t{ortaNokta}\t{seviye1[1, 2]}\n{seviye1[2, 0]}\t{seviye1[2, 1]}\t{seviye1[2, 2]}");

            switch (y)
            {
                case Yon.sag:
                    matrisDondur(seviyeX, ref mainMatris, ortaNokta, seviyeler[seviye - 1], seviyeler[seviye - 1], Yon.sag, seviye);
                    break;
                case Yon.sol:
                    matrisDondur(seviyeX, ref mainMatris, ortaNokta, seviyeler[seviye - 1], seviyeler[seviye - 1], Yon.sol, seviye);
                    break;
                
            }

        }
        int globalSeviye;
        private void btnSag_Click(object sender, EventArgs e)
        {
            rtbEkran.Text = "";
            mIlerlet(ref mainMatris, Convert.ToInt32(cbSeviye.Text), Yon.sag);
            matrisYazdir(Satir.yazdir, mainMatris, globalSeviye);
        }

        private void btnSol_Click(object sender, EventArgs e)
        {
            rtbEkran.Text = "";
            mIlerlet(ref mainMatris, Convert.ToInt32(cbSeviye.Text), Yon.sol);
            matrisYazdir(Satir.yazdir, mainMatris, globalSeviye);
        }

        int[,] tempDizi;

        private void matrisDondur(int[,] source, ref int[,] target, int ortaNokta, int baslangicSatir, int baslangicSutun, Yon yV1, int seviyeV0)
        {

            tempDizi = new int[source.GetLength(0), source.GetLength(1)];
            int seviyeBelirle = seviyeV0 * 2 + 1;
            int donguSeviye = seviyeV0 * 2;
            for (int i = 0; i < seviyeBelirle; i++)
            {
                for (int j = 0; j < seviyeBelirle; j++)
                {
                    tempDizi[i, j] = target[baslangicSatir + i, baslangicSutun + j];
                }
            }
            switch (yV1)
            {
                case Yon.sag:
                    for (int i = 0; i < donguSeviye; i++) // 0,0 --> 0,1 , 0,1 --> 0,2
                        tempDizi[0, i + 1] = source[0, i];
                    for (int i = 0; i < donguSeviye; i++) // 0,2 --> 1,2 , 1,2 --> 2,2
                        tempDizi[i + 1, donguSeviye] = source[i, donguSeviye];
                    
                    for (int i = donguSeviye; i > 0; i--) // 2,2 --> 2,1 , 2,1 --> 2,0
                        tempDizi[donguSeviye, i - 1] = source[donguSeviye, i];
                    for (int i = donguSeviye; i > 0; i--) // 2,0 --> 1,0 , 1,0 --> 0,0
                        tempDizi[i - 1, 0] = source[i, 0];
                    break;
                case Yon.sol:
                    for (int i = donguSeviye; i > 0; i--) // 0,2 --> 0,1 , 0,1 --> 0,0
                        tempDizi[0, i - 1] = source[0, i];
                    for (int i = donguSeviye; i > 0; i--) // 2,2 --> 1,2 , 0,2 --> 1,2
                        tempDizi[i - 1, donguSeviye] = source[i, donguSeviye];
                    for (int i = 0; i < donguSeviye; i++) // 2,0 --> 2,1 , 2,1 --> 2,2
                        tempDizi[donguSeviye, i + 1] = source[donguSeviye, i];
                    for (int i = 0; i < donguSeviye; i++) // 0,0 --> 1,0 , 1,0 --> 2,0
                        tempDizi[i + 1, 0] = source[i, 0];
                    break;
            }
            //int seviyeBelirle = seviyeV0 * 2 + 1;// matris boyut hesaplama
            for (int i = 0; i < seviyeBelirle; i++)
            {
                for (int j = 0; j < seviyeBelirle; j++)
                {
                    target[baslangicSatir + i, baslangicSutun + j] = tempDizi[i, j];
                }
            }
        }


    }
}
