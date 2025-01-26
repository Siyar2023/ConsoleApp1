using System;
using System.Windows.Forms;

namespace MiniWebbrowser
{
    // The Program class contains the entry point for the application.
    internal static class Program
    {
        // The Main method is the entry point of the application, marked with [STAThread] to indicate the threading model.
        [STAThread]
        static void Main()
        {
            // Enables visual styles for the application to make the UI look modern and visually appealing.
            Application.EnableVisualStyles();

            // Sets the default text rendering engine to be compatible with the current operating system.
            Application.SetCompatibleTextRenderingDefault(false);

            // Runs the application by creating an instance of the Main form (MiniBrowserForm) and displaying it.
            Application.Run(new MiniBrowserForm());
        }
    }
}