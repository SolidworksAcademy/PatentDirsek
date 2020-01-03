using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace PatentDirsek
{
    public partial class Form1 : Form
    {               
        SldWorks swApp;
        ModelDoc2 swModel;
        Feature swFeature;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_CreateModel_Click(object sender, EventArgs e)
        {
            try
            {
                swApp = SwApplication.GetApplication();                
                swModel = (ModelDoc2)swApp.ActiveDoc;
                swFeature = swModel.FeatureByPositionReverse(0);
              
                    ElbowWorker elbow = new ElbowWorker();
                    elbow.OutsideDiameter = Convert.ToDouble(txt_cap.Text);
                    elbow.Thickness = Convert.ToDouble(txt_kalinlik.Text);
                    elbow.Radius = Convert.ToDouble(txt_Radius.Text);
                    elbow.CreateElbow90();                               
            }
           
            catch (Exception)
            {
                MessageBox.Show("Sayısal olmayan bir değer girdiniz veya alanlardan en az birisini boş bıraktınız. Lütfen tekrar deneyiniz...");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }       
    }
}
