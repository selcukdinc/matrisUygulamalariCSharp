using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrisUygulamalari
{
    internal class Baslangic
    {
        public static void matrisDondur(RichTextBox Ekran, Panel dondur, RadioButton anaMatris, CheckBox rastgele)
        {
            Ekran.SelectionAlignment = HorizontalAlignment.Center;
            dondur.Enabled = false;
            anaMatris.Checked = true;
            rastgele.Checked = true;
            rastgele.Checked = false;
        }
    }
}
