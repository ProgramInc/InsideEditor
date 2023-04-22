using UnityEngine;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class ReadScriptFile
{
    /*public string scriptName; // the name of the script file to read*/

    public static string ReadFile(string scriptName)
    {
        // Define the search pattern for the script file
        string searchPattern = scriptName + ".cs";

        // Search for the file in the Assets folder and all its subfolders
        string[] filePaths = Directory.GetFiles(Application.dataPath, searchPattern, SearchOption.AllDirectories);

        // Check if any files were found
        if (filePaths.Length > 0)
        {
            // Use the first file found (assuming there is only one)
            string filePath = filePaths.First();

            // Read the contents of the file
            string fileContents = File.ReadAllText(filePath);

            // Define regex patterns for syntax highlighting
            fileContents = ConlorizeRichText(fileContents);
            /*fileContents = Regex.Replace(fileContents, commentsPattern, "<color=gray>$0</color>");*/


            // Print the contents of the file to the console
            return fileContents;
        }
        else
        {
            Debug.LogError("File not found: " + searchPattern);
            return "File Not Found!";
        }
    }

    private static string ConlorizeRichText(string fileContents)
    {
        string keywordsPattern = "\\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while)\\b";
        string MonoBehaviourPattern = "\\b(Awake|Start|OnEnable|OnDisable()|Update()|FixedUpdate())\\b";
        string stringsPattern = "\".*?\"";
        string commentsPattern = "//.*?$|/\\*.*?\\*/";
        string methodNames = @"(?<=void\\s+)\\w+\r\n";
        string MethodNamesPattern = @"\b(public|private|protected)?\s*(void|\w+)\s+(\w+)\s*";

        // Apply syntax highlighting
        fileContents = Regex.Replace(fileContents, MethodNamesPattern, "<color=red>$0</color>");
        fileContents = Regex.Replace(fileContents, keywordsPattern, "<color=blue>$0</color>");
        fileContents = Regex.Replace(fileContents, stringsPattern, "<color=green>$0</color>");
        fileContents = Regex.Replace(fileContents, MonoBehaviourPattern, "<color=yellow>$0</color>");
        return fileContents;
    }

    public static void WriteFile(string scriptName, string data)
    {
        // Define the search pattern for the script file
        string searchPattern = scriptName + ".cs";

        // Search for the file in the Assets folder and all its subfolders
        string[] filePaths = Directory.GetFiles(Application.dataPath, searchPattern, SearchOption.AllDirectories);

        // Check if any files were found
        if (filePaths.Length > 0)
        {
            // Use the first file found (assuming there is only one)
            string filePath = filePaths.First();

            // Read the contents of the file

            if (File.Exists(filePath))
            {
                string formattedData = Regex.Replace(data, @"<[^>]*>", "");
                File.WriteAllText(filePath, formattedData);
            }
        }
    }
}
