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
            btnSag.Enabled = false;
            btnSol.Enabled = false;
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
                btnSag.Enabled = false;
                btnSol.Enabled = false;

            }
            else
            {
                matrisOlustur(Convert.ToInt32(mtbSatir.Text), Convert.ToInt32(mtbSutun.Text), cbRandom.Checked, Convert.ToInt32(mtbRMin.Text), Convert.ToInt32(mtbRMax.Text), Convert.ToInt32(mtbBaslangic.Text));
                matrisYazdir(Satir.yazdir, mainMatris);
                btnSag.Enabled = true;
                btnSol.Enabled = true;
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
            }
            else
            {
                pBoyutlanabilir.Enabled = false;
                mOrnek = true;
            }
        }

        /*  
            0. seviye ortada, hareketsiz kýsým, 
            1. seviye => 0. seviyenin etrafýný çevreleyenler
            2. seviye => 1. seviyenin etrafýný çevreleyenler
            n. seviye => n-1 seviyenin etrafýný çevreleyenler
         */
        private void mIlerlet( ref int[,] m, int seviye, Yon y)
        {
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

            // gelen matrisin 0. seviyesi nedir
            int mSeviye = m.GetLength(0) / 2;
            int ortaNokta = m[mSeviye, mSeviye];
            //MessageBox.Show($"Bu matrisin {mSeviye} seviyesi var, \niþlem yapýlmak istenen seviye : {seviye}\nOrta noktasý : {ortaNokta}");

            // gelen matrisin 1. seviyesinin ilk elemanýnýn yazdýrýlmasý, matris halinde kaydedilmesi [1. seviyede daima 3x3 matristen oluþmaktadir]
            int seviyeTemp = 1;
            //int seviyeSatir = mSeviye - seviyeTemp;
            //int seviyeSutun = seviyeSatir;


            //int[,] seviye1 = new int[3, 3];

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        seviye1[i, j] = m[seviyeSatir + i, seviyeSatir + j];
            //    }
            //}

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
                    //switch (seviye)
                    //{
                    //    case 1:
                    //        matrisDondur(seviye1, ref mainMatris, ortaNokta, seviyeTemp, seviyeTemp, Yon.sag);
                    //        break;
                    //    default:
                    //        break;
                    //}
                    matrisDondur(seviyeX, ref mainMatris, ortaNokta, seviyeler[seviye - 1], seviyeler[seviye - 1], Yon.sag);
                    break;
                case Yon.sol:
                    //switch (seviye)
                    //{
                    //    case 1:
                    //        matrisDondur(seviye1, ref mainMatris, ortaNokta, seviyeTemp, seviyeTemp, Yon.sol);
                    //        break;
                    //    default:
                    //        break;
                    //}
                    matrisDondur(seviyeX, ref mainMatris, ortaNokta, seviyeler[seviye - 1], seviyeler[seviye - 1], Yon.sol);
                    break;
                
            }
            /*
            seviyelerin matris büyüklükleri
                1.s  =>  3
                2.s  =>  5
                3.s  =>  7
                4.s  =>  9
             */
        }

        private void btnSag_Click(object sender, EventArgs e)
        {
            rtbEkran.Text = "";
            mIlerlet(ref mainMatris, 1, Yon.sag);
            matrisYazdir(Satir.yazdir, mainMatris);
        }

        private void btnSol_Click(object sender, EventArgs e)
        {
            rtbEkran.Text = "";
            mIlerlet(ref mainMatris, 1, Yon.sol);
            matrisYazdir(Satir.yazdir, mainMatris);
        }

        //        Random RastgeleSayi = new Random();
        //        for (int i = 0; i< 3; i++)
        //            for (int j = 0;j< 3;j++)
        //                AsilDizi[i, j] = RastgeleSayi.Next(10,50);
        //        Array.Copy(AsilDizi, tempDizi,9);
        //        AsilDizi[0, 0] = 0;
        //        do
        //        {   
        //            for (int i = 0; i< 3; i++)
        //            {
        //                for (int j = 0;j< 3;j++)
        //                    Console.Write("{0}\t",AsilDizi[i, j]);
        //                Console.WriteLine("");
        //            }
        //    Console.Write("Sað Sol? :");
        //            R_L = Console.ReadKey();
        //            Console.Clear();
        //            switch (R_L.Key)
        //            {
        //                case ConsoleKey.R:
        //                    for (int i = 0; i< 2; i++) // 0,0 --> 0,1 , 0,1 --> 0,2
        //                        tempDizi[0, i + 1] = AsilDizi[0, i];
        //                     for (int i = 0; i< 2; i++) // 0,2 --> 1,2 , 1,2 --> 2,2
        //                        tempDizi[i + 1, 2] = AsilDizi[i, 2];
        //                     for (int i = 2; i > 0; i--) // 2,2 --> 2,1 , 2,1 --> 2,0
        //                        tempDizi[2, i - 1] = AsilDizi[2, i];
        //                    for (int i = 2; i > 0; i--) // 2,0 --> 1,0 , 1,0 --> 0,0
        //                        tempDizi[i - 1, 0] = AsilDizi[i, 0]; break;
        //                case ConsoleKey.L:
        //                    for (int i = 2; i > 0; i--) // 0,2 --> 0,1 , 0,1 --> 0,0
        //                        tempDizi[0, i - 1] = AsilDizi[0, i];
        //                    for (int i = 2; i > 0; i--) // 2,2 --> 1,2 , 0,2 --> 1,2
        //                        tempDizi[i - 1, 2] = AsilDizi[i, 2];
        //                    for (int i = 0; i< 2; i++) // 2,0 --> 2,1 , 2,1 --> 2,2
        //                        tempDizi[2, i + 1] = AsilDizi[2, i];
        //                    for (int i = 0; i< 2; i++) // 0,0 --> 1,0 , 1,0 --> 2,0
        //                        tempDizi[i + 1, 0] = AsilDizi[i, 0]; break;
        //            }
        //Array.Copy(tempDizi, AsilDizi, 9);
        int[,] AsilDizi;
        int[,] tempDizi;
        private void matrisDondur(int[,] source, ref int[,] target, int ortaNokta, int baslangicSatir, int baslangicSutun, Yon yV1)
        {

            tempDizi = new int[source.GetLength(0), source.GetLength(1)];
            AsilDizi = new int[target.GetLength(0), target.GetLength(1)];

            // asilDizinin kopyalanmasý, tempDiziye orta noktanýn aktarýmý
            for (int i = 0; i < AsilDizi.GetLength(0); i++)
            {
                for (int j = 0; j < AsilDizi.GetLength(1); j++)
                {
                    AsilDizi[i, j] = target[i, j];
                }
            }

            int mSeviye = source.GetLength(0) / 2;
            tempDizi[mSeviye, mSeviye] = ortaNokta;

            switch (yV1)
            {
                case Yon.sag:
                    for (int i = 0; i < 2; i++) // 0,0 --> 0,1 , 0,1 --> 0,2
                        tempDizi[0, i + 1] = source[0, i];
                    for (int i = 0; i < 2; i++) // 0,2 --> 1,2 , 1,2 --> 2,2
                        tempDizi[i + 1, 2] = source[i, 2];
                    for (int i = 2; i > 0; i--) // 2,2 --> 2,1 , 2,1 --> 2,0
                        tempDizi[2, i - 1] = source[2, i];
                    for (int i = 2; i > 0; i--) // 2,0 --> 1,0 , 1,0 --> 0,0
                        tempDizi[i - 1, 0] = source[i, 0];
                    break;
                case Yon.sol:
                    for (int i = 2; i > 0; i--) // 0,2 --> 0,1 , 0,1 --> 0,0
                        tempDizi[0, i - 1] = source[0, i];
                    for (int i = 2; i > 0; i--) // 2,2 --> 1,2 , 0,2 --> 1,2
                        tempDizi[i - 1, 2] = source[i, 2];
                    for (int i = 0; i < 2; i++) // 2,0 --> 2,1 , 2,1 --> 2,2
                        tempDizi[2, i + 1] = source[2, i];
                    for (int i = 0; i < 2; i++) // 0,0 --> 1,0 , 1,0 --> 2,0
                        tempDizi[i + 1, 0] = source[i, 0];
                    break;
            }

            //Array.ConstrainedCopy(tempDizi, tempDizi[0, 0], AsilDizi, AsilDizi[2, 2], 1);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //seviye1[i, j] = m[seviyeSatir + i, seviyeSatir + j];
                    target[baslangicSatir + i, baslangicSutun + j] = tempDizi[i, j];
                }
            }
        }


    }
}
