using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatentDirsek
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        SldWorks swApp;
        ModelDoc2 swModel;

        private void btn_UpdateModel_Click(object sender, EventArgs e)
        {
            swApp = SwApplication.GetApplication();
            swModel = swApp.ActiveDoc;

            Dimension myDimension = default(Dimension);
            myDimension = (Dimension)swModel.Parameter("D1@SweepSection");
            myDimension.SystemValue = Convert.ToDouble(txt_cap.Text) / 1000;

            myDimension = (Dimension)swModel.Parameter("D1@SweepPath");
            myDimension.SystemValue = Convert.ToDouble(txt_Radius.Text) / 500;

            myDimension = (Dimension)swModel.Parameter("D1@Elbow");
            myDimension.SystemValue = Convert.ToDouble(txt_kalinlik.Text) / 1000;

            swModel.ForceRebuild3(false);
            swModel.ShowNamedView2("", (int)swStandardViews_e.swIsometricView);
            swModel.ViewZoomtofit2();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            
        }
    }
}
