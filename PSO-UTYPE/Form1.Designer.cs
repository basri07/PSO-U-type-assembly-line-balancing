namespace PSO_UTYPE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gorev_button = new MetroFramework.Controls.MetroTile();
            this.matris_button = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // gorev_button
            // 
            this.gorev_button.ActiveControl = null;
            this.gorev_button.Location = new System.Drawing.Point(4, 100);
            this.gorev_button.Name = "gorev_button";
            this.gorev_button.Size = new System.Drawing.Size(154, 167);
            this.gorev_button.TabIndex = 0;
            this.gorev_button.Text = "GÖREVLER";
            this.gorev_button.TileImage = ((System.Drawing.Image)(resources.GetObject("gorev_button.TileImage")));
            this.gorev_button.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gorev_button.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.gorev_button.UseSelectable = true;
            this.gorev_button.UseTileImage = true;
            this.gorev_button.Click += new System.EventHandler(this.gorev_button_Click);
            // 
            // matris_button
            // 
            this.matris_button.ActiveControl = null;
            this.matris_button.Location = new System.Drawing.Point(164, 100);
            this.matris_button.Name = "matris_button";
            this.matris_button.Size = new System.Drawing.Size(258, 167);
            this.matris_button.Style = MetroFramework.MetroColorStyle.Pink;
            this.matris_button.TabIndex = 1;
            this.matris_button.Text = "ÖNCÜL LİSTESİ";
            this.matris_button.TileImage = ((System.Drawing.Image)(resources.GetObject("matris_button.TileImage")));
            this.matris_button.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.matris_button.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.matris_button.UseSelectable = true;
            this.matris_button.UseTileImage = true;
            this.matris_button.Click += new System.EventHandler(this.matris_button_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(4, 273);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(693, 161);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "PSO-ÇÖZÜM";
            this.metroTile1.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile1.TileImage")));
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(429, 100);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(268, 167);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTile2.TabIndex = 3;
            this.metroTile2.Text = "ARDIL LİSTESİ";
            this.metroTile2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile2.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile2.TileImage")));
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 444);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.matris_button);
            this.Controls.Add(this.gorev_button);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "ANASAYFA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile gorev_button;
        private MetroFramework.Controls.MetroTile matris_button;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
    }
}

