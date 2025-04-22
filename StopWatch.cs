using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Diagnostics;



namespace PaperMEP.TestTool
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class StopWatch : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            // Get the current Revit application and document
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            // Start the stopwatch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Your add-in's code here
            try
            {
                // Simulate some work
                System.Threading.Thread.Sleep(5000); // Wait for 1 second

                // Stop the stopwatch
                stopwatch.Stop();
                // Get the elapsed time
                TimeSpan timeSpan = stopwatch.Elapsed;
                string timeElapsed = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                timeSpan.Hours,
                                                timeSpan.Minutes,
                                                timeSpan.Seconds,
                                                timeSpan.Milliseconds);

                // Display the execution time in a TaskDialog
                TaskDialogResult result = TaskDialog.Show("Revit", $"Add-in Execution Time: {timeElapsed}");
            }
            catch (Exception ex)
            {
                TaskDialogResult result = TaskDialog.Show("Revit", $"Error: {ex.Message}" );
                return Result.Failed;
            }

            return Result.Succeeded;
        }
    }
}