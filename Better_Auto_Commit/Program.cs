using System;
using System.Diagnostics;
using System.IO;

namespace Better_Auto_Commit
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (File.Exists (".gitignore")) {
				string LastRan = "";
				Console.Title = "GitHub Auto Committ";
				while (true) {
					LastRan = DateTime.Now.ToString ("yy-MM-dd h:mm:ss tt");
					Github ("add --all .");
					Github ("commit -m \":floppy_disk: Auto Commit " + LastRan + " :floppy_disk:\"");
					Github ("push origin master");
					sleepy (300, LastRan);
					Console.Clear ();
				}
			} else {
				Console.WriteLine ("Please put me in the base of a GitHub Directory");
				Console.ReadLine ();
			}
		}

		public static void Github(string args)
		{
			Process process = new Process();
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
			process.StartInfo.CreateNoWindow = false;
			process.StartInfo.FileName = "git";
			process.StartInfo.Arguments = args;
			process.Start();
			string result = process.StandardOutput.ReadToEnd();
			Console.WriteLine(result);
		}

		public static void sleepy(int time, string rantime)
		{
			int timeLeft = time;
				while (timeLeft >= 1)
				{
				timeLeft = timeLeft -1;
				Console.Clear ();
				Console.WriteLine ("Last Run Time : " + rantime);
				Console.WriteLine ("Next Commit : " + timeLeft + " Seconds");
				System.Threading.Thread.Sleep (1000);
				}
		}
	}
}
