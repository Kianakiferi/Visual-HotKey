using Microsoft.ClearScript.V8;
using System.Runtime.InteropServices;
using VisualHotKey.CLI.Common;

namespace VisualHotKey.CLI;

public class Program
{
    public static int Main(string[] args)
    {
        var filePath = Path.Combine
        (
            Directory.GetCurrentDirectory(), 
            Constants.PublicFolder.ScriptsFolderPath, 
            "test.js"
        );
        
        using (V8ScriptEngine engine = new())
        {
            engine.DocumentSettings.AccessFlags = Microsoft.ClearScript.DocumentAccessFlags.EnableFileLoading;
            engine.DefaultAccess = Microsoft.ClearScript.ScriptAccess.Full;

            V8Script script = engine.CompileDocument(filePath);
            engine.Execute(script);

            var result = engine.Script.Greeting();

            Console.WriteLine(result);
        }
        return 0;
    }
}
