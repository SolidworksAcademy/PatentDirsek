using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolidWorks.Interop.sldworks;

namespace PatentDirsek
{
    public static class DocumentManager
    {
        public static void NewPartTemplate() // Yeni bir part dökümanı açan metodum
        {
            SldWorks SldWorks = new SldWorks();
            ModelDoc2 swModel;
            swModel = (ModelDoc2)SldWorks.NewDocument("C:\\ProgramData\\SOLIDWORKS\\SOLIDWORKS 2019\\templates\\Parça.prtdot", 0, 0, 0);
        }
    }
}
