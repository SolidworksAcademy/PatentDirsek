using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace PatentDirsek
{
    public class SkirtWorker
    {
        public double BasePlateOD { get; set; }

        public double BasePlateID { get; set; }

        public double BasePlateBoltCircleDia { get; set; }

        public double BasePlateHoleNumber { get; set; }

        public double BasePlateHoleDia { get; set; }

        public double BasePlateThickness { get; set; }


        public void CreateBasePlate()
        {
            DocumentManager.NewPartTemplate();

            SldWorks SldWorks = new SldWorks();
            Feature swFeature;
            bool boolstatus;
            bool status;
            ModelDoc2 swModel;
            Configuration config;
            CustomPropertyManager cusPropMgr;
            int lRetVal;
            DisplayDimension myDisplayDim;
            Dimension myDisplayDim2;

            swModel = (ModelDoc2)SldWorks.ActiveDoc;

            swFeature = swModel.FeatureByPositionReverse(3);  
            swFeature.Name = "Front"; 

            swFeature = swModel.FeatureByPositionReverse(2);  
            swFeature.Name = "Top"; 

            swFeature = swModel.FeatureByPositionReverse(1);  
            swFeature.Name = "Right";


            boolstatus = swModel.Extension.SelectByID2("Top", "PLANE", 0, 0, 0, false, 0, null, 0); 
            swModel.SketchManager.InsertSketch(true); 



            object OutsideSegment = null;
            OutsideSegment = swModel.CreateCircleByRadius2(0, 0, 0, BasePlateOD / 2000);
            boolstatus = swModel.Extension.SelectByID2("", "SKETCHSEGMENT", 0, 0, BasePlateOD / 2000, false, 0, null, 0);
            myDisplayDim = (DisplayDimension)swModel.AddDiameterDimension2(0, 0, BasePlateOD / 2000);
            //myDisplayDim.Parameter("CircleOutside@Çizim1");

            myDisplayDim2 = (Dimension)swFeature.Parameter("D3");

            object InsideSegment = null;
            InsideSegment = swModel.CreateCircleByRadius2(0, 0, 0, BasePlateID / 2000);

            double angle = (BasePlateHoleNumber * 2) / 360;
            double rad = Math.PI * angle / 180.0;
            double cos = BasePlateBoltCircleDia * Math.Cos(rad);
            double sin = BasePlateBoltCircleDia * Math.Sin(rad);

            object AngleSegment1 = null;
            AngleSegment1 = swModel.CreateLine2(0, 0, 0, cos / 1000, cos / 1000, 0);
            boolstatus = swModel.Extension.SelectByID2("", "SKETCHSEGMENT", cos / 1000, cos / 1000, 0, false, 0, null, 0);
            swModel.SketchManager.CreateConstructionGeometry();

            object AngleSegment2 = null;
            AngleSegment2 = swModel.CreateLine2(0, 0, 0, sin / 1000, sin / 1000, 0);
            boolstatus = swModel.Extension.SelectByID2("", "SKETCHSEGMENT", sin / 1000, sin / 1000, 0, false, 0, null, 0);
            swModel.SketchManager.CreateConstructionGeometry();



            swModel.ForceRebuild3(true); // Rebuild
            swModel.ShowNamedView2("*Isometric", -1); // İzometrik görünüm
            swModel.ViewZoomtofit2(); // Ekrana sığdır.
        }
    }
}


