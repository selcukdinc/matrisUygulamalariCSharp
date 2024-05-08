using MatrisDondurme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrisUygulamalari
{
    internal class SeviyeliMatris
    {

        public int[,] mainMatris; // = new int[3,3] gibi bir tanımlama yapılmadı çünkü 2 boyutlu dizilerde yeniden boyutlandırma yapmak mümkün değil, metot içinde boyutlandırılmalı
        int[,] tempDizi; // döndürüebilmesi için 2. bir diziye ihtiyacımız var
        public int[,] ornekMatris = new int[3, 3]{ // koddun içinde gömülü bir matris olsun diye eklenmiş, döndürmeye katkısı olmayan bir matristir
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

        public bool mOrnek; // Örnek matris yazdırma durumunda olup olmadığı bilgisi bu değişkende tutulur
        Random R = new Random(); // Rastgele sayılar oluşturulmak istendiği zaman kullanmak için tanımlanması burda yapılmalıdır

        // Formda bulunan kontrollerin başka bir sınıf içinde kullanılabilmesi için yeniden tanımlanması gerekiyor
        RichTextBox rtbEkran = Application.OpenForms["Form1"].Controls.Find("rtbEkran", true)[0] as RichTextBox; // formun içinde "xyz" ismindeki kontrolü ve altındaki bütün kontrolleri bul ve bulduğun ilk kontrolü (alt kontrol olmayan) RichTextBox şeklinde ver
        ComboBox cbSeviye = Application.OpenForms["Form1"].Controls.Find("cbSeviye", true)[0] as ComboBox;
        MaskedTextBox mtbSatir = Application.OpenForms["Form1"].Controls.Find("mtbSatir", true)[0] as MaskedTextBox;
        MaskedTextBox mtbSutun = Application.OpenForms["Form1"].Controls.Find("mtbSutun", true)[0] as MaskedTextBox;
        MaskedTextBox mtbRMin = Application.OpenForms["Form1"].Controls.Find("mtbRMin", true)[0] as MaskedTextBox;
        MaskedTextBox mtbRMax = Application.OpenForms["Form1"].Controls.Find("mtbRMax", true)[0] as MaskedTextBox;
        MaskedTextBox mtbBaslangic = Application.OpenForms["Form1"].Controls.Find("mtbBaslangic", true)[0] as MaskedTextBox;
        CheckBox cbRastgele = Application.OpenForms["Form1"].Controls.Find("cbRastgele", true)[0] as CheckBox;
        Panel pR = Application.OpenForms["Form1"].Controls.Find("pR", true)[0] as Panel;
        Panel pNotR = Application.OpenForms["Form1"].Controls.Find("pNotR", true)[0] as Panel;
        Panel pBoyutlanabilir = Application.OpenForms["Form1"].Controls.Find("pBoyutlanabilir", true)[0] as Panel;
        Panel pDondur = Application.OpenForms["Form1"].Controls.Find("pDondur", true)[0] as Panel;
        RadioButton rbMainMatris = Application.OpenForms["Form1"].Controls.Find("rbMainMatris", true)[0] as RadioButton;
        

        public void cbRastgele_CheckChanged()
        {// kullanıcı matrisin içini rastgele sayılar ile doldurmak istiyor mu?
            if (cbRastgele.Checked){ // evet kullanıcı rastgele sayılar atamak istiyor
                pNotR.Enabled = false; // 'pNotR' paneli başlangıç değerini belirlemede kullanılan alanı pasif hale getirir
                pR.Enabled = true; // 'pR' paneli rastgele özellikleri içeren özellikleri aktif hale getirir
            }else{//Hayır kullanıcı başlangıç değeri belli ollan ve birer birer artan bir matris oluşturmak istiyor
                pNotR.Enabled = true; // Başlangıç değerinin verilebildiği paneli aktif hale getir
                pR.Enabled = false; // Rastgele matrisin ilgilendiği özelliklere sahip paneli pasif hale getir
            }
        }

        public void matrisSec(object sender)// bu tanımlı olduğu metotta 2 radiobutton checkstatechanged eventine bağlı,
        {// Kullanıcı örnek matris mi yoksa döndürülebilir matris mi yazdırmak istiyor?
            string main = $"{rbMainMatris.Name}"; // bu atamamzın sebebi gelecek nesnenin ismiyle karşılaştırma yapmak içindir.
            RadioButton rbSecim = (RadioButton)sender; // gönderen objeyi RadioButton'a çevir
            if (rbSecim.Name == main) // çevrilen nesnenin ismi döndürülecek matris seçeneğinin ismiyle aynı mı? 
            {// evet kullanıcı döndürülecek matris seçeneğini seçti
                pBoyutlanabilir.Enabled = true; // döndürülecek matrisini ilgilendiren Boyutlanabilir panelini aktif et
                mOrnek = false; // örnek matris ile işimiz yok, değişkenin içine atamayı yap
            }
            else
            {// hayır kullanıcı örnek matris yazdırmak istedi
                pBoyutlanabilir.Enabled = false; // döndürülecek matrisi ilgilendiren paneli pasif konuma getir
                mOrnek = true; // örnek matris ile işim var, durumu güncelle
                pDondur.Enabled = false; // döndürmede asıl matris ile bağlantılı bu panelide pasif yap
                // programın dizayn tarafına bakılacak olursa 'pDondur', 'pBoyutlanabilir'in içinde olmadığı için pasif hale getirmemiz için ayrıca deklare etmemiz gerekiyor
            }
        }

        public void baslatClick(){// 'btnBaslat' adındaki butonun click eventi direkt bu metotu çağırmaktadır
            rtbEkran.Text = ""; // ekranı temizle
            if (mOrnek){ // Örnek mi seçildi?
                // evet örnek seçildi
                Yazdir.Matris(ornekMatris, rtbEkran); // 'Yazdir' sınıfı içindeki 'Matris' adındaki statik fonsiyonu çalıştır, girdi olarak örnek matrisi seç ve yazdırılacak alanı tanımla
            }else{
                // hayır, döndürülebilir matris yazdırılmak isteniyor
                matrisOlustur(); // matris oluşturma metotunu çağır
                pDondur.Enabled = true;
                cbSeviye.Items.Clear();
                for (int i = 0; i < Convert.ToInt32(mtbSatir.Text) / 2; i++)
                    cbSeviye.Items.Add($"{i + 1}");
                cbSeviye.Text = cbSeviye.Items[0].ToString();
            }
        }
        // matrisOlustur metoduna overload yapılarak aynı metodu iki farklı şekilde çağrılabilir yapılmıştır
        public void matrisOlustur(int satir, int sutun, bool randomStatus, int Rmin, int Rmax, int startValue)// bu metot ana form dışında tekrar kullanılmak istendiğinde yapılacaktır 
        {
            mainMatris = new int[satir, sutun];// matrisin sınırları burada belirlenir ve bir sonraki başlat tuşuna basılana kadar matrisin boyutunda değişikliğie gidilmez
            if (randomStatus)// kullanıcı matrisin içinde rastgele sayılarla doldurulsun istiyor mu?
                for (int i = 0; i < satir; i++)// matrisin satır döngüsü
                    for (int j = 0; j < sutun; j++) // heri bir satırda sütunlar için alt döngü
                        mainMatris[i, j] = R.Next(Rmin, Rmax + 1); // rastgele değerlerin matrisin minimum değeri ve maksimum değeri arlığın sınırlarını belirlerler, Rmax + 1 olamsının sebebi '.Next' fonsiyonun bir özelliği olan maks. değerin -1'i dahil şekilde çalışır.
            else// hayır bir başlangıç değerine sahip olmasını ve birer birer arttırılmasını istiyor
                for (int i = 0; i < satir; i++) 
                    for (int j = 0; j < sutun; j++) 
                        mainMatris[i, j] = startValue++;// başlangıç değerini matrisin i. satır j. sütun elemanına ata ve başlangıç değerini bir arttır.
        }

        public void matrisOlustur(){// metodun kendi içinde kullanılan versiyonudur, 
        
            int satir = Convert.ToInt32(mtbSatir.Text),// form komponentleri sınıfın içinde tanımlandığı için metodun içinde dönüşüm gerçekleştirilebilir.
                sutun = Convert.ToInt32(mtbSutun.Text), 
                Rmin = Convert.ToInt32(mtbRMin.Text), 
                Rmax = Convert.ToInt32(mtbRMax.Text), 
                startValue = Convert.ToInt32(mtbBaslangic.Text);
            mainMatris = new int[satir, sutun]; // matrisin sınırları oluşturma anında seçilen satır sütun sayılarına göre belirlenir
            if (cbRastgele.Checked) // kullanıcı rastgele sayılar atansın istiyor mu
            {// evet kullanıcı rastgele sayılar atansın istiyor
                for (int i = 0; i < satir; i++)
                    for (int j = 0; j < sutun; j++) 
                        mainMatris[i, j] = R.Next(Rmin, Rmax + 1); // rastgele atama yapmak için R random sınıfından .Next metodu çağrılır, içine rastgele sayıların alabileceği max. ve mn. değerler yazılır
            }else
                for (int i = 0; i < satir; i++)
                    for (int j = 0; j < sutun; j++)
                        mainMatris[i, j] = startValue++;
            Yazdir.Matris(mainMatris, rtbEkran); // yazdırma işlemi eklenerek zincirleme bir bağlantı eklenmiş olup , başka bir yerde kullanılması istenmez, yalnızca ana form içinde click eventi içinde kullanılmalıdır
        }

        public void matrisDondur( int[,] m, int seviye, Yon secilenYon){
            rtbEkran.Text = "";
            int mSeviye = m.GetLength(0) / 2;
            int ortaNokta = m[mSeviye, mSeviye];
            int[] seviyeler = new int[mSeviye]; // 0, 1, 2, 3 indexlerine sahip
            int counter = 0;
            int mSeviyeBelirle = seviye * 2 + 1;
            int[,] seviyeX = new int[mSeviyeBelirle, mSeviyeBelirle];
            int seviyeSatir = mSeviye - seviye;
            for (int i = mSeviye; i > 0; i--) // 4, 3, 2, 1
                seviyeler[i - 1] = counter++; // seviyeler[3] = 0   ,   sevyeler[2] = 1,    seviyeler[1] = 2,   seviyeler[0] = 3
            for (int i = 0; i < mSeviyeBelirle; i++)
                for (int j = 0; j < mSeviyeBelirle; j++)
                    seviyeX[i, j] = m[seviyeSatir + i, seviyeSatir + j];
            switch (secilenYon)
            {
                case Yon.sag:
                    mIlerlet(seviyeX, ref mainMatris, ortaNokta, seviyeler[seviye - 1], seviyeler[seviye - 1], Yon.sag, seviye);
                    break;
                case Yon.sol:
                    mIlerlet(seviyeX, ref mainMatris, ortaNokta, seviyeler[seviye - 1], seviyeler[seviye - 1], Yon.sol, seviye);
                    break;

            }
            Yazdir.Matris(mainMatris, rtbEkran);
        }

        private void mIlerlet(int[,] source, ref int[,] target, int ortaNokta, int baslangicSatir, int baslangicSutun, Yon secilenYon, int seviyeV0)
        {
            tempDizi = new int[source.GetLength(0), source.GetLength(1)];
            int seviyeBelirle = seviyeV0 * 2 + 1;
            int donguSeviye = seviyeV0 * 2;
            for (int i = 0; i < seviyeBelirle; i++)
                for (int j = 0; j < seviyeBelirle; j++)
                    tempDizi[i, j] = target[baslangicSatir + i, baslangicSutun + j];
            switch (secilenYon)
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
                for (int j = 0; j < seviyeBelirle; j++)
                    target[baslangicSatir + i, baslangicSutun + j] = tempDizi[i, j];
        }

    }
}
