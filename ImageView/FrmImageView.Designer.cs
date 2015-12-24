namespace ImageView
{
    partial class FrmImageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImageView));
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnSelectInExplorer = new System.Windows.Forms.Button();
            this.picImageView = new ImageView.Controls.CtrImageViewer();
            ((System.ComponentModel.ISupportInitialize)(this.picImageView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(576, 521);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.Location = new System.Drawing.Point(13, 521);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnSelectInExplorer
            // 
            this.btnSelectInExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectInExplorer.Location = new System.Drawing.Point(94, 521);
            this.btnSelectInExplorer.Name = "btnSelectInExplorer";
            this.btnSelectInExplorer.Size = new System.Drawing.Size(94, 23);
            this.btnSelectInExplorer.TabIndex = 3;
            this.btnSelectInExplorer.Text = "SelectInExplorer";
            this.btnSelectInExplorer.UseVisualStyleBackColor = true;
            this.btnSelectInExplorer.Click += new System.EventHandler(this.btnSelectInExplorer_Click);
            // 
            // picImageView
            // 
            this.picImageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImageView.BackColor = System.Drawing.Color.Black;
            this.picImageView.ImageShow = null;
            this.picImageView.Location = new System.Drawing.Point(0, 0);
            this.picImageView.Name = "picImageView";
            this.picImageView.Size = new System.Drawing.Size(664, 515);
            this.picImageView.TabIndex = 0;
            this.picImageView.TabStop = false;
            // 
            // FrmImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 550);
            this.Controls.Add(this.btnSelectInExplorer);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.picImageView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmImageView";
            this.Text = "ImageView";
            ((System.ComponentModel.ISupportInitialize)(this.picImageView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CtrImageViewer picImageView;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnSelectInExplorer;
    }
}