using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrisUygulamalari
{
    internal class Yazdir // Yazdir adında bir sınıf tanımlaması yapıldı, bu sayede yazdırma işlemleri daha kolay ve tekrara girmeden, başka sınıflarda çağrılabilecek
    {
        public static void Matris(int[,] m, RichTextBox Ekran)  // Metot static ifadesiyle kullanıldı, bize faydası herhangi bir nesne oluşturmadan direkt kullanabiliyoruz.
        {// Bir çok alanda kullanılması için basit tutuldu, girdi olarak matrisi ve yazılacak yerin seçimi yeterli
            int mSatir = m.GetLength(0); // gelen matrisin satır sayısının değişkene aktarılması 
            int mSutun = m.GetLength(1); // gelen matrisin  sütun sayısının değişkene aktarılması
                for (int i = 0; i < mSatir; i++){ // matris yazdırılırken dış taraftaki döngü satır atlama işleminde kullanılır
                    for (int j = 0; j < mSutun; j++)  // iç döngü ise girilen satırda sütunların yazdırılması için kullanılır
                        Ekran.Text += $"{m[i, j]}\t"; // tab atılması için \t ifadesi kullanıldı, bu sayede matrise daha çok benzemesi sağlandı
                Ekran.Text += "\n\n"; // her satır yazdırıldıktan sonra bir sonraki satır için iki adet boşluk atıyor, bu sayede matrise benzemesi sağlanmış oluyor
            }
        }
    
    }
}
