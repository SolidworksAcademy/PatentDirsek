using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace PatentDirsek
{
    public static class DocumentManager
    {
        public static void NewPartTemplate() // Yeni bir part dökümanı açan metodum
        {
            SldWorks swApp;
            swApp = SwApplication.GetApplication();
            string defaultPartTemplate;
           
            defaultPartTemplate = swApp.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swDefaultTemplatePart);
            swApp.NewDocument(defaultPartTemplate, 0, 0, 0);

        }
    }
}
