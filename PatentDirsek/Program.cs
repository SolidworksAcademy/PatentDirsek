using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatentDirsek
{
    static class Program
    {
        /// <summary>
        /// Harun Murat Özgüç.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            SldWorks swApp;
            ModelDoc2 swModel;
            Feature swFeature;
            DisplayDimension swDispDim;

            swApp = SwApplication.GetApplication();
            swModel = swApp.ActiveDoc;
            swFeature = swModel.FeatureByPositionReverse(0);

            DialogResult select = new DialogResult();
            
            if (swFeature.Name == "Elbow")
            {
                select = MessageBox.Show("If you want to edit the drawing, click the OK button, and press the No button to draw a new elbow.", "", MessageBoxButtons.YesNo);
                if (select == DialogResult.Yes)
                {
                    swModel.Extension.SelectByID2("D1@SweepSection", "DIMENSION", 0, 0, 0, false, 0, null, 0);
                    swDispDim = swModel.SelectionManager.GetSelectedObject6(1, -1);
                    double outsideDiameter = swDispDim.GetDimension2(0).Value;


                    swModel.Extension.SelectByID2("D1@SweepPath", "DIMENSION", 0, 0, 0, false, 0, null, 0);
                    swDispDim = swModel.SelectionManager.GetSelectedObject6(1, -1);
                    double radius = swDispDim.GetDimension2(10).Value / 2;


                    swModel.Extension.SelectByID2("D1@Elbow", "DIMENSION", 0, 0, 0, false, 0, null, 0);
                    swDispDim = swModel.SelectionManager.GetSelectedObject6(1, -1);
                    double thickness = swDispDim.GetDimension2(0).Value;

                    Edit updateForm = new Edit();

                    updateForm.txt_cap.Text = outsideDiameter.ToString();
                    updateForm.txt_kalinlik.Text = thickness.ToString();
                    updateForm.txt_Radius.Text = radius.ToString();

                    Application.Run(updateForm);
                }
                else if (select == DialogResult.No)
                {
                    Application.Run(new Form1());
                }                
            }
            else
            {
                Application.Run(new Form1());
            }
        }        
    }
}
