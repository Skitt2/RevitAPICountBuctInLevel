using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPICountBuctInLevel
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<Duct> ductInstances = new FilteredElementCollector(doc, doc.ActiveView.Id)
            .OfCategory(BuiltInCategory.OST_DuctCurves)
            .WhereElementIsNotElementType()
            .Cast<Duct>()
            .ToList();

            TaskDialog.Show("Количество воздуховодов на активном этаже: ", ductInstances.Count.ToString());
            return Result.Succeeded;
        }
    }
}
