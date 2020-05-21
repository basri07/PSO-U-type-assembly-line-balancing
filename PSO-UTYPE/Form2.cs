using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace PSO_UTYPE
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
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
            da = new SqlDataAdapter("Select *From Gorevler", baglanti);
            ds = new DataSet();
            DataTable dt = new DataTable();
            baglanti.Open();
            da.Fill(dt);
            metroGrid1.DataSource = dt;
            baglanti.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_PSO_UTYPEDataSet.Gorevler' table. You can move, or remove it, as needed.
            this.gorevlerTableAdapter.Fill(this._PSO_UTYPEDataSet.Gorevler);
            Griddoldur();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void GEkle_Button_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Gorevler (ID,GorevSuresi,GorevAdi) VALUES (@ID,@GorevSuresi,@GorevAdi)", baglanti);
            baglanti.Open();
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(id_textbox.Text));
            cmd.Parameters.AddWithValue("@GorevSuresi", Convert.ToInt32(GSuresi_TextBox.Text));
            cmd.Parameters.AddWithValue("@GorevAdi", Convert.ToString(GAdi_TextBox.Text));
            cmd.ExecuteNonQuery();
            metroGrid1.Update();
            baglanti.Close();
            Griddoldur();
        }
        private void Sil(int id)
        {
            string sql = "DELETE FROM Gorevler WHERE ID=@id";
            komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@id", id);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in metroGrid1.SelectedRows)  //Seçili Satırları Silme
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                Sil(id);
            }
            Griddoldur();
        }

        private void GOlustur_Button_Click(object sender, EventArgs e)
        {
            int GorevSayisi;
            GorevSayisi = Convert.ToInt32(GSayisi_TextBox.Text);
            Random rastgele = new Random();
            for(int i = 1; i<GorevSayisi+1; i++ )
            {
                int ID = i;
                int GorevSuresi = rastgele.Next(1, 10);
                Thread.Sleep(2000);
                id_textbox.Text = ID.ToString();
                GSuresi_TextBox.Text = GorevSuresi.ToString();
                SqlCommand cmd = new SqlCommand("INSERT INTO Gorevler (ID,GorevSuresi,GorevAdi) VALUES (@ID,@GorevSuresi,@GorevAdi)", baglanti);
                baglanti.Open();
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(id_textbox.Text));
                cmd.Parameters.AddWithValue("@GorevSuresi", Convert.ToInt32(GSuresi_TextBox.Text));
                cmd.Parameters.AddWithValue("@GorevAdi", Convert.ToString(GAdi_TextBox.Text));
                cmd.ExecuteNonQuery();
                metroGrid1.Update();
                baglanti.Close();
            }
            Griddoldur();
        }
    }
}
