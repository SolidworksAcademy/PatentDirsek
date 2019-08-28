namespace PatentDirsek
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
            this.btn_CreateModel = new System.Windows.Forms.Button();
            this.txt_cap = new System.Windows.Forms.TextBox();
            this.txt_kalinlik = new System.Windows.Forms.TextBox();
            this.txt_Radius = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_CreateModel
            // 
            this.btn_CreateModel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_CreateModel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_CreateModel.Location = new System.Drawing.Point(83, 196);
            this.btn_CreateModel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CreateModel.Name = "btn_CreateModel";
            this.btn_CreateModel.Size = new System.Drawing.Size(171, 43);
            this.btn_CreateModel.TabIndex = 0;
            this.btn_CreateModel.Text = "Modeli Oluştur";
            this.btn_CreateModel.UseVisualStyleBackColor = false;
            this.btn_CreateModel.Click += new System.EventHandler(this.btn_CreateModel_Click);
            // 
            // txt_cap
            // 
            this.txt_cap.Location = new System.Drawing.Point(124, 37);
            this.txt_cap.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cap.Name = "txt_cap";
            this.txt_cap.Size = new System.Drawing.Size(130, 33);
            this.txt_cap.TabIndex = 1;
            // 
            // txt_kalinlik
            // 
            this.txt_kalinlik.Location = new System.Drawing.Point(124, 75);
            this.txt_kalinlik.Margin = new System.Windows.Forms.Padding(2);
            this.txt_kalinlik.Name = "txt_kalinlik";
            this.txt_kalinlik.Size = new System.Drawing.Size(130, 33);
            this.txt_kalinlik.TabIndex = 2;
            // 
            // txt_Radius
            // 
            this.txt_Radius.Location = new System.Drawing.Point(124, 113);
            this.txt_Radius.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Radius.Name = "txt_Radius";
            this.txt_Radius.Size = new System.Drawing.Size(130, 33);
            this.txt_Radius.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Diameter : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thickness : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Radius :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 272);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Radius);
            this.Controls.Add(this.txt_kalinlik);
            this.Controls.Add(this.txt_cap);
            this.Controls.Add(this.btn_CreateModel);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Harun Murat Özgüç";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateModel;
        private System.Windows.Forms.TextBox txt_cap;
        private System.Windows.Forms.TextBox txt_kalinlik;
        private System.Windows.Forms.TextBox txt_Radius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

