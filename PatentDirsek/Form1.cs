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
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_CreateModel_Click(object sender, EventArgs e)
        {
            try
            {
                ElbowWorker elbow = new ElbowWorker();

                elbow.OutsideDiameter = Convert.ToDouble(txt_cap.Text);
                elbow.Thickness = Convert.ToDouble(txt_kalinlik.Text);
                elbow.Radius = Convert.ToDouble(txt_Radius.Text);

                elbow.CreateElbow90();
            }
            catch (Exception)
            {
                MessageBox.Show("Alfanumerik bir değer girdiniz veya alanlardan en az birisini boş bıraktınız. Lütfen tekrar deneyiniz...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SkirtWorker s = new SkirtWorker();

            s.BasePlateOD = Convert.ToDouble(2000);
            s.BasePlateID = Convert.ToDouble(1650);
            s.BasePlateBoltCircleDia = Convert.ToDouble(1875);
            s.BasePlateHoleNumber = Convert.ToDouble(24);
            s.BasePlateHoleDia = Convert.ToDouble(34);
            s.BasePlateThickness = Convert.ToDouble(25);

            s.CreateBasePlate();
        }

        SldWorks swApp = new SldWorks();
        public AssemblyDoc swAssemblyDoc;
        ModelDoc2 swModel;
        ModelDocExtension swDocExt;
        Hashtable openAssem;
        string tmpPath;
        ModelDoc2 tmpObj;
        bool boolstat;
        bool stat;
        Component2 swComponent;
        Feature matefeature;
        string MateName;
        string FirstSelection;
        string SecondSelection;
        string strCompName;
        string AssemblyTitle;
        string AssemblyName;
        int errors;
        int warnings;

        int mateError;

        private void button2_Click(object sender, EventArgs e)
        {

            swModel = (ModelDoc2)swApp.ActiveDoc;

            // Set up event
            swAssemblyDoc = (AssemblyDoc)swModel;
            openAssem = new Hashtable();

            // Get title of assembly document
            AssemblyTitle = swModel.GetTitle();

            // Split the title into two strings using the period (.) as the delimiter
            string[] strings = AssemblyTitle.Split(new Char[] { '.' });

            // Use AssemblyName when mating the component with the assembly
            AssemblyName = (string)strings[0];



            boolstat = true;
            string strCompModelname = null;
            strCompModelname = "111.sldprt";

            // Because the component resides in the same folder as the assembly, get
            // the assembly's path and use it when opening the component
            tmpPath = swModel.GetPathName();
            int idx;
            idx = tmpPath.LastIndexOf("D:\\denemesolid\\1.SLDASM");
            string compPath;
            tmpPath = tmpPath.Substring(0, (idx));
            compPath = string.Concat(tmpPath, strCompModelname);


            // Open the component
            tmpObj = (ModelDoc2)swApp.OpenDoc6(compPath, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);

            // Check to see if the file is read only or cannot be found; display error
            // messages if either
            if (warnings == (int)swFileLoadWarning_e.swFileLoadWarning_ReadOnly)
            {
                MessageBox.Show("This file is read only.");
                boolstat = false;
            }

            if (tmpObj == null)
            {
                MessageBox.Show("Cannot locate the file.");
                boolstat = false;
            }

            // Re-activate the assembly so that you can add the component to it
            swModel = (ModelDoc2)swApp.ActivateDoc3(AssemblyTitle, true, (int)swRebuildOnActivation_e.swUserDecision, ref errors);

            // Add the camtest part to the assembly document.
            //
            // Currently only one option, swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig,
            // works for adding a part using IComponent2::AddComponent5
            // The other options, swAddComponentConfigOptions_e.swAddComponentConfigOptions_NewConfigWithAllReferenceModels
            // and swAddComponentConfigOptions_e.swAddComponentConfigOptions_NewConfigWithAsmStructure,
            // work only for adding assemblies
            swComponent = (Component2)swAssemblyDoc.AddComponent5(strCompModelname, (int)swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig, "", false, "", -1, -1, -1);

            // Make the component virtual
            stat = swComponent.MakeVirtual();

            // Get the name of the component for the mate
            strCompName = swComponent.Name2;

            // Create the name of the mate and the names of the planes to use for the mate
            MateName = "top_coinc_" + strCompName;
            FirstSelection = "Top@" + strCompName + "@" + AssemblyName;
            SecondSelection = "Front@" + AssemblyName;

            swModel.ClearSelection2(true);
            swDocExt = (ModelDocExtension)swModel.Extension;

            // Select the planes for the mate
            boolstat = swDocExt.SelectByID2(FirstSelection, "PLANE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            boolstat = swDocExt.SelectByID2(SecondSelection, "PLANE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);

            // Add the mate
            matefeature = (Feature)swAssemblyDoc.AddMate3((int)swMateType_e.swMateCOINCIDENT, (int)swMateAlign_e.swMateAlignALIGNED, false, 0, 0, 0, 0, 0, 0, 0, 0, false, out mateError);
            //matefeature.Name = MateName;


            swModel.ViewZoomtofit2();

        }
    }
}
