using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSO_UTYPE
{
    public partial class ARDILFORM : MetroFramework.Forms.MetroForm
    {
        public ARDILFORM()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand komut;
        private void Griddoldur()
        {
            baglanti = new SqlConnection("Data Source=BASRI\\BASRI;Initial Catalog=PSO-UTYPE;Integrated Security=True");
            da = new SqlDataAdapter("Select *From ArdilMatrisi", baglanti);
            ds = new DataSet();
            DataTable dt = new DataTable();
            baglanti.Open();
            da.Fill(dt);
            metroGrid1.DataSource = dt;
            baglanti.Close();
        }
        private void ARDILFORM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_PSO_UTYPEDataSet5.ArdilMatrisi' table. You can move, or remove it, as needed.
            this.ardilMatrisiTableAdapter.Fill(this._PSO_UTYPEDataSet5.ArdilMatrisi);
            baglanti = new SqlConnection("Data Source=BASRI\\BASRI;Initial Catalog=PSO-UTYPE;Integrated Security=True");
            Griddoldur();

        }

        private void Ekle_Button_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO ArdilMatrisi (SIRA,GorevID,BirSonrakiGorevID,BaslangicBitis) VALUES (@SIRA,@GorevID,@BirSonrakiGorevID,@BaslangicBitis)", baglanti);
            baglanti.Open();
            cmd.Parameters.AddWithValue("@SIRA", Convert.ToInt32(Sira_Textbox.Text));
            cmd.Parameters.AddWithValue("@GorevID", Convert.ToInt32(GorevID_TextBox.Text));
            cmd.Parameters.AddWithValue("@BirSonrakiGorevID", Convert.ToInt32(BirSonrakiGorev_Textbox.Text));
            cmd.Parameters.AddWithValue("@BaslangicBitis", Convert.ToBoolean(BaslangicBitis_Textbox.Text));
            cmd.ExecuteNonQuery();
            metroGrid1.Update();
            baglanti.Close();
            Griddoldur();
        }
        private void Sil(int SIRA)
        {
            string sql = "DELETE FROM ArdilMatrisi WHERE SIRA=@SIRA";
            komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@SIRA", SIRA);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void Sil_Button_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in metroGrid1.SelectedRows)  //Seçili Satırları Silme
            {
                int SIRA = Convert.ToInt32(drow.Cells[0].Value);
                Sil(SIRA);
            }
            Griddoldur();
        }
    }
}
