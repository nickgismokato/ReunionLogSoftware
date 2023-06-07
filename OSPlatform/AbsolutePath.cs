using System;
using System.IO;

namespace OSPlatform{
    public class AbsolutePath{
        //Fields
        public static string projectName = "ReunionLogSoftware";
        public string projectFileName = $"{projectName}.csproj";
        public string projectPath;
        
        //Constructor
        public AbsolutePath(){
            string currentDir = Directory.GetCurrentDirectory();
            System.Console.WriteLine(currentDir);
            string parentDir = Directory.GetParent(currentDir).FullName;
            System.Console.WriteLine(parentDir);
            projectPath = currentDir;
        }

        public string GetProjectPath(){
            return projectPath;
        }
    }
}