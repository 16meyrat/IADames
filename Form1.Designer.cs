namespace IADames
{
    partial class MainWindowForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.plateauLayout = new System.Windows.Forms.TableLayoutPanel();
            this.GroupeJoueurs = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectionNoirs = new System.Windows.Forms.ComboBox();
            this.SelectionBlancs = new System.Windows.Forms.ComboBox();
            this.Informations = new System.Windows.Forms.Label();
            this.boutonDemarrer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GroupeJoueurs.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.plateauLayout);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GroupeJoueurs);
            this.splitContainer1.Panel2.Controls.Add(this.Informations);
            this.splitContainer1.Panel2.Controls.Add(this.boutonDemarrer);
            this.splitContainer1.Size = new System.Drawing.Size(658, 489);
            this.splitContainer1.SplitterDistance = 473;
            this.splitContainer1.TabIndex = 0;
            // 
            // plateauLayout
            // 
            this.plateauLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.plateauLayout.ColumnCount = 10;
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10011F));
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10112F));
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10112F));
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10112F));
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10112F));
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10112F));
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10112F));
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10112F));
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10112F));
            this.plateauLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090919F));
            this.plateauLayout.Location = new System.Drawing.Point(12, 12);
            this.plateauLayout.Margin = new System.Windows.Forms.Padding(1);
            this.plateauLayout.Name = "plateauLayout";
            this.plateauLayout.RowCount = 10;
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.plateauLayout.Size = new System.Drawing.Size(460, 465);
            this.plateauLayout.TabIndex = 0;
            // 
            // GroupeJoueurs
            // 
            this.GroupeJoueurs.AutoSize = true;
            this.GroupeJoueurs.Controls.Add(this.label3);
            this.GroupeJoueurs.Controls.Add(this.label2);
            this.GroupeJoueurs.Controls.Add(this.SelectionNoirs);
            this.GroupeJoueurs.Controls.Add(this.SelectionBlancs);
            this.GroupeJoueurs.Location = new System.Drawing.Point(18, 12);
            this.GroupeJoueurs.Name = "GroupeJoueurs";
            this.GroupeJoueurs.Size = new System.Drawing.Size(151, 149);
            this.GroupeJoueurs.TabIndex = 2;
            this.GroupeJoueurs.TabStop = false;
            this.GroupeJoueurs.Text = "Joueurs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Noirs : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Blancs : ";
            // 
            // SelectionNoirs
            // 
            this.SelectionNoirs.FormattingEnabled = true;
            this.SelectionNoirs.Location = new System.Drawing.Point(24, 92);
            this.SelectionNoirs.Name = "SelectionNoirs";
            this.SelectionNoirs.Size = new System.Drawing.Size(121, 24);
            this.SelectionNoirs.TabIndex = 1;
            // 
            // SelectionBlancs
            // 
            this.SelectionBlancs.FormattingEnabled = true;
            this.SelectionBlancs.Location = new System.Drawing.Point(24, 38);
            this.SelectionBlancs.Name = "SelectionBlancs";
            this.SelectionBlancs.Size = new System.Drawing.Size(121, 24);
            this.SelectionBlancs.TabIndex = 0;
            // 
            // Informations
            // 
            this.Informations.AutoEllipsis = true;
            this.Informations.Location = new System.Drawing.Point(15, 211);
            this.Informations.Name = "Informations";
            this.Informations.Size = new System.Drawing.Size(148, 50);
            this.Informations.TabIndex = 1;
            this.Informations.Text = "Choisissez les joueurs";
            this.Informations.UseMnemonic = false;
            // 
            // boutonDemarrer
            // 
            this.boutonDemarrer.AutoSize = true;
            this.boutonDemarrer.Location = new System.Drawing.Point(46, 167);
            this.boutonDemarrer.Name = "boutonDemarrer";
            this.boutonDemarrer.Size = new System.Drawing.Size(78, 27);
            this.boutonDemarrer.TabIndex = 0;
            this.boutonDemarrer.Text = "Demarrer";
            this.boutonDemarrer.UseVisualStyleBackColor = true;
            this.boutonDemarrer.Click += new System.EventHandler(this.boutonDemarrer_Click);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 489);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainWindowForm";
            this.Text = "Jeu de Dames Internationales";
            this.Load += new System.EventHandler(this.MainWindowForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.GroupeJoueurs.ResumeLayout(false);
            this.GroupeJoueurs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel plateauLayout;
        private System.Windows.Forms.Button boutonDemarrer;
        private System.Windows.Forms.GroupBox GroupeJoueurs;
        private System.Windows.Forms.Label Informations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SelectionNoirs;
        private System.Windows.Forms.ComboBox SelectionBlancs;
    }
}

