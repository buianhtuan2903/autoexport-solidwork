using System;
using SolidWorks.Interop.sldworks;

namespace Autoexport
{
    class Export
    {
        public void transfer(String fileitem, String folderitem, String nameitem)
        {
            int longstatus = 0;
            ModelDoc2 swDoc = null;

            SldWorks swApp = new SldWorks(); 
            swApp.Visible = false;
            swDoc = swApp.OpenDoc6(fileitem, 3, 0, "", 0 , 0);
            ModelDoc2 swModel = swApp.ActiveDoc;
            //swDoc = swApp.ActiveDoc;
            //swDoc.GetActiveSketch();
            //swDoc.GraphicsRedraw2();
            longstatus = swModel.SaveAs3(folderitem + "\\" + nameitem + ".PDF", 0, 0);
            longstatus = swModel.SaveAs3(folderitem + "\\" + nameitem + ".DWG", 0, 0);
            swDoc.ClearSelection2(true);
            swDoc = null;
            swApp.CloseDoc(fileitem);
        }
    }
}
