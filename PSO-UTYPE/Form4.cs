using System;
using System.Collections;
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
    public partial class iterasyonSayisi_Textbox : MetroFramework.Forms.MetroForm
    {
        public List<Gorevler> GorevListesi = new List<Gorevler>();
        public List<OncelikMatrisi> OncelikListesi = new List<OncelikMatrisi>();
        public List<ArdilMatrisi> ArdilListesi = new List<ArdilMatrisi>();
        public iterasyonSayisi_Textbox()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand komut;

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_PSO_UTYPEDataSet4.OncelikMatrisi' table. You can move, or remove it, as needed.
            this.oncelikMatrisiTableAdapter2.Fill(this._PSO_UTYPEDataSet4.OncelikMatrisi);
            // TODO: This line of code loads data into the '_PSO_UTYPEDataSet3.OncelikMatrisi' table. You can move, or remove it, as needed.
            this.gorevlerTableAdapter.Fill(this._PSO_UTYPEDataSet.Gorevler);

            baglanti = new SqlConnection("Data Source=BASRI\\BASRI;Initial Catalog=PSO-UTYPE;Integrated Security=True");
            da = new SqlDataAdapter("Select *From Gorevler", baglanti);
            ds = new DataSet();
            DataTable dt = new DataTable();
            baglanti.Open();
            da.Fill(dt);
            GorevlerGrid.DataSource = dt;
            baglanti.Close();
    
            string sql1 = "SELECT*FROM Gorevler";
            baglanti.Open();
            komut = new SqlCommand(sql1, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Gorevler Gorev = new Gorevler();
                Gorev.ID = Convert.ToInt32(dr[0]);
                Gorev.GorevSuresi = Convert.ToInt32(dr[1]);
                GorevListesi.Add(Gorev);
            }
            baglanti.Close();
    
            string sql2 = "SELECT*FROM OncelikMatrisi";
            baglanti.Open();
            komut = new SqlCommand(sql2, baglanti);
            SqlDataReader dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                OncelikMatrisi oncelik = new OncelikMatrisi();
                oncelik.ID = Convert.ToInt32(dr2[0]);
                oncelik.GorevID = Convert.ToInt32(dr2[1]);
                oncelik.BirOncekiGorevID = Convert.ToInt32(dr2[2]);
                oncelik.BaslangıcBitis = Convert.ToBoolean(dr2[3]);
                OncelikListesi.Add(oncelik);
            }
            baglanti.Close();

            string sql3 = "SELECT*FROM ArdilMatrisi";
            baglanti.Open();
            komut = new SqlCommand(sql3, baglanti);
            SqlDataReader dr3 = komut.ExecuteReader();
            while (dr3.Read())
            {
                ArdilMatrisi ardil = new ArdilMatrisi();
                ardil.SIRA = Convert.ToInt32(dr3[0]);
                ardil.GorevID = Convert.ToInt32(dr3[1]);
                ardil.BirSonrakiGorevID = Convert.ToInt32(dr3[2]);
                ardil.BaslangicBitis = Convert.ToBoolean(dr3[3]);
                ArdilListesi.Add(ardil);
            }
            baglanti.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            int ParcacikSayisi, İterasyonSayisi, CevrimSuresi,GorevSayisi,OncelikSayisi,istasyonSayisi,ToplamGorevSuresi,ArdilSayisi;
            CevrimSuresi = Convert.ToInt32(CevrimSuresi_Textbox.Text);
            İterasyonSayisi = Convert.ToInt32(iterasyonSayisi_TxtBox.Text);
            ParcacikSayisi = Convert.ToInt32(ParcacikSayisi_Textbox.Text);
            ToplamGorevSuresi = 0;

            List<Gorevler> ParcacikGorevleri = GorevListesi.CloneList().ToList();
            List<OncelikMatrisi> ParcacikMatrisi = OncelikListesi.CloneList().ToList();
            List<ArdilMatrisi> ParcacikArdilMatrisi = ArdilListesi.CloneList().ToList();
            GorevSayisi = ParcacikGorevleri.Count();
            OncelikSayisi = OncelikListesi.Count();
            ArdilSayisi = ArdilListesi.Count();
            for (int g = 0; g < GorevSayisi; g++)
            {
                ToplamGorevSuresi += GorevListesi[g].GorevSuresi;
            }
            istasyonSayisi = (ToplamGorevSuresi / CevrimSuresi)+1;
            int[] istasyonSuresi = new int[istasyonSayisi];
            for(int f=0;f<istasyonSayisi;f++)
            {
                istasyonSuresi[f] = 0;
            }
            int ToplamBaslangıcBitisGorevSayisi = 0;
            double BaslangicSecmeOlasiligi;
            int i;
            #region İLK ATANACAK OLAN GÖREV SEÇİMİ
           
            //Önce Kaç tane Başlangıç veya Bitiş Görevi var onun sayımı yapılır
            for (i=0;i< OncelikSayisi;i++)
            {
                if (ParcacikMatrisi[i].BaslangıcBitis == true)
                {
                    ToplamBaslangıcBitisGorevSayisi++;
                }
            }
            int[] BaslangicBitisGorevID = new int[ToplamBaslangıcBitisGorevSayisi];
            ArrayList AtanabiliGorevlerID = new ArrayList();
            ArrayList AtananGorevlerID = new ArrayList();
            int a = 0;
            //Başlagıç veya Bitiş görevlerinin ID'leri kontrol edilir
            for (i = 0; i < OncelikSayisi ; i++)
            {
                if (ParcacikMatrisi[i].BaslangıcBitis == true)
                {
                    a++;
                    BaslangicBitisGorevID[a - 1] = ParcacikMatrisi[i].GorevID;
                    AtanabiliGorevlerID.Add(BaslangicBitisGorevID[a - 1]);
                }
            }
            // BaslangicSecmeOlasiligi = 1 / ToplamBaslangıcBitisGorevSayisi;
            //Kaç başlangıç veye bitiş elemanı varsa ona göre rastgele bir seçim yapılır ve biri seçilir.
            int Seed = Convert.ToInt32(Seed_TextBox.Text);
            Random rastgele = new Random();
            int AtanacakGorevIndexi=0;
            for (int Rnd = 0; Rnd < Seed; Rnd++)
            { 
              AtanacakGorevIndexi = rastgele.Next(0, ToplamBaslangıcBitisGorevSayisi);
            }
            int AtancakGorevID = BaslangicBitisGorevID[AtanacakGorevIndexi];
            string IstasyonString = "***";
            int DizideAra(int item, ArrayList array)
            {
                for (int q = 0; q < array.Count; q++)
                {
                    if (item == Convert.ToInt32(array[q]))
                    {
                        return q;
                        
                    }
                }
                return -1;
            }
            #endregion
            //Görev Atama döngüsü
            int AtanabilirGorevID;
            int s = 0;
            int t = 0;
        İstasyonEtiketi:
            if (t != 0)
                s++;
            for (s = s; s < istasyonSayisi; s++)
            {   
                
                IstasyonString += "***";
                AtamaEtiketi:
                
                for (t =t; t< GorevSayisi; t++)
                {
                   
                
                    //İlk Atama
                    if (t == 0 && s==0)
                    {
                        IstasyonString += Convert.ToString(AtancakGorevID) + "-";
                        istasyonSuresi[s] += ParcacikGorevleri[AtancakGorevID - 1].GorevSuresi;
                        AtananGorevlerID.Add(AtancakGorevID);
                        AtanabiliGorevlerID.Remove(AtancakGorevID);
                       
                        for (int o = 0; o < OncelikSayisi; o++)
                        {
                            int VarmıOncelik = DizideAra(ParcacikMatrisi[o].BirOncekiGorevID, AtananGorevlerID);
                            if (VarmıOncelik!=-1)
                            {
                            AtanabilirGorevID = ParcacikMatrisi[o].GorevID;
                            int Varmı = DizideAra(AtanabilirGorevID, AtananGorevlerID);
                                if (Varmı==-1)
                                {
                                    AtanabiliGorevlerID.Add(AtanabilirGorevID);
                                }
                          
                            }
                            int VarmıArdillik = DizideAra(ParcacikArdilMatrisi[o].BirSonrakiGorevID, AtananGorevlerID);
                             if(VarmıArdillik!=-1)
                             {
                                 AtanabilirGorevID = ParcacikMatrisi[o].GorevID;

                                 int Varmı = DizideAra(AtanabilirGorevID, AtananGorevlerID);
                                 if (Varmı == -1)
                                 {
                                       AtanabiliGorevlerID.Add(AtanabilirGorevID);
                                 }
                                
                             }
                        }
                        AtanabiliGorevlerID.TrimToSize();
                        //Atanabilir Görevler Adım Adım Kontrol Edildi.
                        /* for(int z=0;z<AtanabiliGorevlerID.Count;z++)
                        { 
                        listBox1.Items.Add(AtanabiliGorevlerID[z].ToString());
                        }*/
                        continue;
                    }
                    int RandomElemanSayisi = listBox2.Items.Count;
                    for (int Ernd = 0;  Ernd < AtanabiliGorevlerID.Count; Ernd++)
                    {

                        for(int Seeder = 0; Seeder<Seed;Seeder++)
                        {
                            AtanacakGorevIndexi = rastgele.Next(0, AtanabiliGorevlerID.Count);
                            AtancakGorevID = Convert.ToInt32(AtanabiliGorevlerID[AtanacakGorevIndexi]);
                        }
                        
                        int yoksa = listBox2.Items.IndexOf(AtancakGorevID);
                        if(yoksa!=-1)
                        {
                            Ernd--;
                            continue;
                        }
                        else if (yoksa ==-1)
                        {
                           
                            listBox2.Items.Add(AtancakGorevID);
                            if (istasyonSuresi[s] + ParcacikGorevleri[AtancakGorevID - 1].GorevSuresi > CevrimSuresi && Ernd  == (AtanabiliGorevlerID.Count-1))
                            {
                                listBox2.Items.Clear();
                                goto İstasyonEtiketi;
                            }
                            if (istasyonSuresi[s] + ParcacikGorevleri[AtancakGorevID - 1].GorevSuresi > CevrimSuresi)
                            {
                                continue;
                            }
                            if (istasyonSuresi[s] + ParcacikGorevleri[AtancakGorevID - 1].GorevSuresi <= CevrimSuresi)
                            {
                               
                                IstasyonString += Convert.ToString(AtancakGorevID) + "-";
                                istasyonSuresi[s] += ParcacikGorevleri[AtancakGorevID - 1].GorevSuresi;
                                AtananGorevlerID.Add(AtancakGorevID);
                                AtanabiliGorevlerID.Remove(AtancakGorevID);
                                for (int o = 0; o < OncelikSayisi; o++)
                                {
                                    int VarmıOncelik = DizideAra(ParcacikMatrisi[o].BirOncekiGorevID, AtananGorevlerID);
                                    if (VarmıOncelik != -1)
                                    {
                                        AtanabilirGorevID = ParcacikMatrisi[o].GorevID;
                                        int Atanabilirdevarmi = DizideAra(AtanabilirGorevID, AtanabiliGorevlerID);
                                        if(Atanabilirdevarmi==-1)
                                        { 
                                            int Varmı = DizideAra(AtanabilirGorevID, AtananGorevlerID);
                                            if (Varmı == -1)
                                            {
                                                AtanabiliGorevlerID.Add(AtanabilirGorevID);
                                            }
                                        }
                                    }
                                    int VarmıArdillik = DizideAra(ParcacikArdilMatrisi[o].BirSonrakiGorevID, AtananGorevlerID);
                                    if (VarmıArdillik != -1)
                                    {
                                        AtanabilirGorevID = ParcacikMatrisi[o].GorevID;
                                        int Atanabilirdevarmi = DizideAra(AtanabilirGorevID, AtanabiliGorevlerID);
                                        if (Atanabilirdevarmi == -1)
                                        {
                                            int Varmı = DizideAra(AtanabilirGorevID, AtananGorevlerID);
                                            if (Varmı == -1)
                                            {
                                                AtanabiliGorevlerID.Add(AtanabilirGorevID);
                                            }
                                        }
                                    }
                                }
                               
                                listBox2.Items.Clear();
                                break;
                            }
                        }
                    }                                    
                }                   
            }
            listBox1.Items.Add(IstasyonString);
        }                
    }
    internal static class Extensions
    {
        public static IList<T> CloneList<T>(this IList<T> list) where T : ICloneable
        {
            return list.Select(item => (T)item.Clone()).ToList();
        }
        public static int CountTimes<T>(this List<T> list, T item)
        {
            return ((from t in list where t.Equals(item) select t).Count());
        }
    }
}
