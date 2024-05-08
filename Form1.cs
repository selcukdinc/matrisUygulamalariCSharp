using MatrisUygulamalari;

enum Yon { sag, sol }

namespace MatrisDondurme{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        SeviyeliMatris sm;
        private void Form1_Load(object sender, EventArgs e){
            sm = new SeviyeliMatris();
            Baslangic.matrisDondur(rtbEkran, pDondur, rbMainMatris, cbRastgele);
        }

        #region MatrisDondurme

        private void cbRastgele_CheckStateChanged(object sender, EventArgs e){
            sm.cbRastgele_CheckChanged();
        }

        private void matrisSecim(object sender, EventArgs e){
            sm.matrisSec(sender);
        }

        private void btnBaslat_Click(object sender, EventArgs e){
            sm.baslatClick();
        }

        private void btnSag_Click(object sender, EventArgs e){
            sm.matrisDondur(sm.mainMatris, Convert.ToInt32(cbSeviye.Text), Yon.sag);
        }

        private void btnSol_Click(object sender, EventArgs e){
            sm.matrisDondur(sm.mainMatris, Convert.ToInt32(cbSeviye.Text), Yon.sol);
        }
        #endregion

    }
}
