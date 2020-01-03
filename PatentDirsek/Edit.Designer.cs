namespace PatentDirsek
{
    partial class Edit
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Radius = new System.Windows.Forms.TextBox();
            this.txt_kalinlik = new System.Windows.Forms.TextBox();
            this.txt_cap = new System.Windows.Forms.TextBox();
            this.btn_UpdateModel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(31, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Radius :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Thickness : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Diameter : ";
            // 
            // txt_Radius
            // 
            this.txt_Radius.Location = new System.Drawing.Point(102, 115);
            this.txt_Radius.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Radius.Name = "txt_Radius";
            this.txt_Radius.Size = new System.Drawing.Size(151, 25);
            this.txt_Radius.TabIndex = 10;
            // 
            // txt_kalinlik
            // 
            this.txt_kalinlik.Location = new System.Drawing.Point(102, 70);
            this.txt_kalinlik.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_kalinlik.Name = "txt_kalinlik";
            this.txt_kalinlik.Size = new System.Drawing.Size(151, 25);
            this.txt_kalinlik.TabIndex = 9;
            // 
            // txt_cap
            // 
            this.txt_cap.Location = new System.Drawing.Point(103, 28);
            this.txt_cap.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_cap.Name = "txt_cap";
            this.txt_cap.Size = new System.Drawing.Size(151, 25);
            this.txt_cap.TabIndex = 8;
            // 
            // btn_UpdateModel
            // 
            this.btn_UpdateModel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_UpdateModel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_UpdateModel.Location = new System.Drawing.Point(55, 160);
            this.btn_UpdateModel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_UpdateModel.Name = "btn_UpdateModel";
            this.btn_UpdateModel.Size = new System.Drawing.Size(199, 47);
            this.btn_UpdateModel.TabIndex = 7;
            this.btn_UpdateModel.Text = "Update Model";
            this.btn_UpdateModel.UseVisualStyleBackColor = false;
            this.btn_UpdateModel.Click += new System.EventHandler(this.btn_UpdateModel_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(272, 219);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Radius);
            this.Controls.Add(this.txt_kalinlik);
            this.Controls.Add(this.txt_cap);
            this.Controls.Add(this.btn_UpdateModel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Edit";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_UpdateModel;
        public System.Windows.Forms.TextBox txt_Radius;
        public System.Windows.Forms.TextBox txt_kalinlik;
        public System.Windows.Forms.TextBox txt_cap;
    }
}