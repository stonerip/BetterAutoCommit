using System;
using System.Diagnostics;

namespace Better_Auto_Commit
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Title = "GitHub Auto Committ";
			Github("--version");
			Github("add --all .");
			Github("commit -m \":floppy_disk: Auto Commit %mydate%_%mytime% :floppy_disk:\"");
			Github("push origin master");

			Console.WriteLine ("Done");
			Console.ReadLine ();
		}

		public static void Github(string args)
		{
			Process process = new Process();
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
			process.StartInfo.CreateNoWindow = false;
			//process.StartInfo.FileName = "C:\\Users\\bsherow\\AppData\\Local\\GitHub\\PortableGit_c2ba306e536fdf878271f7fe636a147ff37326ad\\bin\\git.exe";
			process.StartInfo.FileName = "git";
			process.StartInfo.Arguments = args;
			process.Start();
			string result = process.StandardOutput.ReadToEnd();
			Console.WriteLine(result);
		}
	}
}
