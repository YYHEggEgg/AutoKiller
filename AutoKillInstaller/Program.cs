// See https://aka.ms/new-console-template for more information
using Microsoft.Win32;
using System.Diagnostics;
#pragma warning disable CA1416 // 验证平台兼容性

Console.WriteLine("AutoKiller (Kaedehara Kazuha version) v1.0.0 Installer");
Console.WriteLine(@"AutoKiller will be installed in D:\AutoKiller\");
if (Process.GetProcessesByName("AutoKiller").Length != 0)
{
    Console.WriteLine("Please close the AutoKiller and continue.");
    Console.ReadLine();
}

if (File.Exists(@"D:\AutoKiller\AutoKiller.exe"))
{
    Console.WriteLine("Update Mode");
}
else
{
    Console.WriteLine("New Install Mode");
    Console.WriteLine("Registry Writing: .\\AutoKiller -startup");
    string path = @"D:\AutoKiller\AutoKiller.exe";
    RegistryKey rk = Registry.LocalMachine;
    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
    rk2.SetValue("AutoKiller (Kaedehara Kazuha version)", path);
    rk2.Close();
    rk.Close();
}
Directory.CreateDirectory(@"D:\AutoKiller");
string thisPath = AppDomain.CurrentDomain.BaseDirectory;
File.Copy($@"{thisPath}\AutoKiller.exe", @"D:\AutoKiller\AutoKiller.exe", true);
File.Copy($@"{thisPath}\AutoKiller.dll", @"D:\AutoKiller\AutoKiller.dll", true);
File.Copy($@"{thisPath}\AutoKiller.pdb", @"D:\AutoKiller\AutoKiller.pdb", true);
File.Copy($@"{thisPath}\AutoKiller.deps.json", @"D:\AutoKiller\AutoKiller.deps.json", true);
File.Copy($@"{thisPath}\AutoKiller.runtimeconfig.json", @"D:\AutoKiller\AutoKiller.runtimeconfig.json", true);

Console.WriteLine("Enjoy the AutoKiller with Kaedehara Kazuha!");
Console.ReadLine();
