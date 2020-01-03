using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatentDirsek
{
    internal class SwApplication
    {
        private static SldWorks swApp;

        private SwApplication()
        {

        }

        internal static SldWorks GetApplication()
        {
            if (swApp == null)
            {
                swApp = Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application")) as SldWorks;
                swApp.Visible = true;

                return swApp;
            }
            return swApp;
        }

        internal static void Dispose()
        {
            if (swApp != null)
            {
                swApp.ExitApp();
                swApp = null;
            }
        }
    }
}
