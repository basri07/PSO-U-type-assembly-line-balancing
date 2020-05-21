using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSO_UTYPE
{
    
    public partial class Form3: MetroFramework.Forms.MetroForm
    {
        public Form3()
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
            da = new SqlDataAdapter("Select *From OncelikMatrisi", baglanti);
            ds = new DataSet();
            DataTable dt = new DataTable();
            baglanti.Open();
            da.Fill(dt);
            metroGrid1.DataSource = dt;
            baglanti.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_PSO_UTYPEDataSet3.OncelikMatrisi' table. You can move, or remove it, as needed.
            this.oncelikMatrisiTableAdapter.Fill(this._PSO_UTYPEDataSet3.OncelikMatrisi);
            // TODO: This line of code loads data into the '_PSO_UTYPEDataSet2.OncelikMatrisi' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the '_PSO_UTYPEDataSet1.OncelikMatrisi' table. You can move, or remove it, as needed.
            baglanti = new SqlConnection("Data Source=BASRI\\BASRI;Initial Catalog=PSO-UTYPE;Integrated Security=True");
            Griddoldur();
        }

        private void OncelikEkle_Button_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO OncelikMatrisi (ID,GorevID,Bir_Onceki_is_ID,Baslangıc_Bitis_Mi) VALUES (@ID,@GorevID,@Bir_Onceki_is_ID,@Baslangıc_Bitis_Mi)", baglanti);
            baglanti.Open();
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(metroTextBox1.Text));
            cmd.Parameters.AddWithValue("@GorevID", Convert.ToInt32(ID_Textbox.Text));
            cmd.Parameters.AddWithValue("@Bir_Onceki_is_ID", Convert.ToInt32(OncekiID.Text));
            cmd.Parameters.AddWithValue("@Baslangıc_Bitis_Mi", Convert.ToBoolean(BoleanTextbox.Text));
            cmd.ExecuteNonQuery();
            metroGrid1.Update();
            baglanti.Close();
            Griddoldur();
        }
        private void Sil(int id)
        {
            string sql = "DELETE FROM OncelikMatrisi WHERE ID=@id";
            komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@id", id);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void Sil_Button_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in metroGrid1.SelectedRows)  //Seçili Satırları Silme
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                Sil(id);
            }
            Griddoldur();
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            int GorevSayisi, GorevID;
            int Oncekiis = 0;
            GorevSayisi = Convert.ToInt32(TGS_Textbox.Text);
            Random rastgele = new Random();
            for (int i = 1; i < GorevSayisi + 1; i++)
            {
                int ID = i;
                int GoreviD;
                metroTextBox1.Text = ID.ToString();
                for (int a = 1; a<GorevSayisi+1; a++)
                {
                    if(a==1)
                    {
                        GoreviD = a;
                        Oncekiis = 0;
                        ID_Textbox.Text = ID.ToString();
                        OncekiID.Text = Oncekiis.ToString();
                    }
                    if(a==2)
                    {
                        GoreviD = a;
                        Oncekiis = 1;
                        ID_Textbox.Text = ID.ToString();
                        OncekiID.Text = Oncekiis.ToString();
                    }
                        GorevID= rastgele.Next(1, Oncekiis);
                }
               
            }
            Griddoldur();
        }
    }
}
