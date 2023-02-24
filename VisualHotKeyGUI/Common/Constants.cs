namespace VisualHotKey.CLI.Common;

public struct Constants
{
    public struct PublicFolder
    {
        public const string PublicFolderPath = "Public";

        public static readonly string ScriptsFolderPath = Path.Combine(PublicFolderPath, "Scripts");
    }
}
