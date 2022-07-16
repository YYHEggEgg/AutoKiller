namespace AutoKiller
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (args.Length == 1)
            {
                if (args[0] == "-startup")
                {
                    Form_Welcome.HideWindow = true;
                }
            }
            Application.Run(new Form_Welcome());
        }
    }
}