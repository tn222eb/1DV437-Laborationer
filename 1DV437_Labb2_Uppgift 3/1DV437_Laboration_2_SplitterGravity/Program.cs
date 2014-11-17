#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace _1DV437_Laboration_2_Smoke
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
