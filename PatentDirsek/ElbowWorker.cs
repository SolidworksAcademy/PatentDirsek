using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace PatentDirsek
{
    public class ElbowWorker
    {
        public double OutsideDiameter { get; set; } // Dış çap
        public double Thickness { get; set; } // Kalınlık
        public double Radius { get; set; } // Dirsek Radüsü


        public void CreateElbow90() // 90 Derecelik Patent Dirsek Çizen Metod
        {
            // TANIMLAMALAR          
            SldWorks swApp;
            Feature swFeature;
            bool boolstatus;
            bool status;
            ModelDoc2 swModel;
            Configuration config;
            CustomPropertyManager cusPropMgr;
            int lRetVal;

            //SldWorks Singleton
            swApp = SwApplication.GetApplication();

            // Oluşturduğum DocumentManager sınıfındaki NewPartTeplate metodumu çalıştırarak yeni bir part dosyası açıyorum.
            DocumentManager.NewPartTemplate();


            // Yeni açtığım part dosyasını swModele set ediyorum
            swModel = (ModelDoc2)swApp.ActiveDoc;


            // Unsur ağacındaki düzlemlerin isimlerini değiştiriyorum. Değiştirmemin nedeni solidworks'ü başka bir dilde kullansam bile bu isimleri en başta istediğim isimlerle değiştirerek kod akışında yapacağım düzlem seçimlerinde verdiğim isimleri çağırabileceğim.(örn:48. satırda düzlem seçiyorum)
            swFeature = swModel.FeatureByPositionReverse(3); // SEÇİYORUM 
            swFeature.Name = "Front"; // DEĞİŞTİRİYORUM

            swFeature = swModel.FeatureByPositionReverse(2); // SEÇİYORUM 
            swFeature.Name = "Top"; // DEĞİŞTİRİYORUM

            swFeature = swModel.FeatureByPositionReverse(1); // SEÇİYORUM 
            swFeature.Name = "Right"; // DEĞİŞTİRİYORUM

            // Yukarıda düzlemleri seçerken  kullandığım metod FeatureByPositionReverse() metodudur.İçerisine verdiğim integer değer ise unsur ağacındaki aşağıdan yukarıya doğru olan sırasıdır.
            //örnek verecek olursak yeni bir part dosyası açtığımızda aşağıdaki gibi bir unsur ağacı gelir.

            //---
            // Malzeme (4)
            // Front Plane (3)
            // Top Plane (2)
            // Right Plane (1)
            // Origin (0)

            // Unsur ağacının en sonundakinin index numarası her zaman 0'dır ve yukarıya doğru artar.


            boolstatus = swModel.Extension.SelectByID2("Front", "PLANE", 0, 0, 0, false, 0, null, 0); // Front Plane'i seçiyorum.
            swModel.SketchManager.InsertSketch(true); // Seçili Plane'e Sketch açıyorum.

            // Sketch içerisine Bir daire çiziyorum (dirseğin radüsü)
            object ElbowSegment = null;
            ElbowSegment = swModel.CreateCircleByRadius2(0, 0, 0, Radius / 1000); // Burada radüs değerini 1000'e bölmemin nedeni solidworksün kod tarafında kullanılan değerleri metre olarak algılamasındandır. Ben değerlerimi kullanıcı arayüzünden milimetre olarak aldığım için kod tarafında tekrar metreye çevirmem gerekiyor.(Tabiki bu işlemleri kolaylaştırmak için bir metod kullanılabilir yada sınıflar içerisinde set edebilirsin.)

            // Daire ölçülendirmesi ekliyorum
            swModel.AddDiameterDimension(0,0,0);

            // Unsur ağacının el altında olan sketch'i, yani çizdiğim daireyi seçiyorum ve ismini SweepPath olarak değiştiriyorum.
            swFeature = swModel.FeatureByPositionReverse(0);
            swFeature.Name = "SweepPath";


            ElbowSegment = swModel.CreateLine2(0, 0, 0, 0, Radius / 1000, 0); // CreateLine2 metodu ile çizgi çiziyorum
            boolstatus = swModel.Extension.SelectByID2("", "SKETCHSEGMENT", 0, Radius / 1000, 0, false, 0, null, 0); // çizgiyi seçiyorum
            swModel.SketchManager.CreateConstructionGeometry(); // Seçili çizimi Construction Geometry'e çeviriyorum

            ElbowSegment = swModel.CreateLine2(0, 0, 0, Radius / 1000, 0, 0);
            boolstatus = swModel.Extension.SelectByID2("", "SKETCHSEGMENT", Radius / 1000, 0, 0, false, 0, null, 0);
            swModel.SketchManager.CreateConstructionGeometry();

            swModel.ClearSelection2(true); // Seçim listesini Temizliyorum
            boolstatus = swModel.Extension.SelectByID2("", "SKETCHSEGMENT", -Radius / 1000, 0, 0, false, 0, null, 0);

            boolstatus = swModel.SketchManager.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, -Radius / 1000, 0, 0);
            swModel.SketchManager.InsertSketch(true);

            boolstatus = swModel.Extension.SelectByID2("Top", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            ElbowSegment = swModel.CreateCircleByRadius2(Radius / 1000, 0, 0, OutsideDiameter / 2000);
            swModel.AddDiameterDimension(0,0,0);
            swModel.SketchManager.InsertSketch(true);
            swFeature = swModel.FeatureByPositionReverse(0);
            swFeature.Name = "SweepSection";

            // Seçim listesini Temizliyorum
            swModel.ClearSelection2(true);

            // çizdiğim sketch leri seçiyorum.
            status = swModel.Extension.SelectByID2("SweepSection", "SKETCH", 0, 0, 0, false, 0, null, 0);
            status = swModel.Extension.SelectByID2("SweepPath", "SKETCH", 0, 0, 0, true, 0, null, 0);

            // Seçmiş olduğum sketchleri sweep(süpürerek katı oluştur) komutu ile katılıyorum
            swFeature = swModel.FeatureManager.InsertProtrusionSwept3(false, false, 0, false, false, 0, 0, true, -Thickness / 1000, 0, 0, 0, true, true, true, 0, true);

            // Katıladığım unsurun ismini elbow olarak değiştiriyorum.
            swFeature = swModel.FeatureByPositionReverse(0);
            swFeature.Name = "Elbow";

            swModel.ForceRebuild3(true); // Rebuild
            swModel.ShowNamedView2("*Isometric", -1); // İzometrik görünüm
            swModel.ViewZoomtofit2(); // Ekrana sığdır.
            
            // Custom Property Ekliyorum
            config = (Configuration)swModel.GetActiveConfiguration();
            cusPropMgr = config.CustomPropertyManager;

            lRetVal = cusPropMgr.Add3("Description", (int)swCustomInfoType_e.swCustomInfoText, "ELBOW / DİRSEK", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

            lRetVal = cusPropMgr.Add3("Grade", (int)swCustomInfoType_e.swCustomInfoText, "---", (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);

            lRetVal = cusPropMgr.Add3("Code", (int)swCustomInfoType_e.swCustomInfoText, "ASME B16.9 ASME SEC.II PART A", (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);

            lRetVal = cusPropMgr.Add3("Dimensions", (int)swCustomInfoType_e.swCustomInfoText, "Ø" + OutsideDiameter + "x" + Thickness + "  LR90º", (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);
        }
    }
}
