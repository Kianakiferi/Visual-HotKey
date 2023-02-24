// See https://aka.ms/new-console-template for more information

//#NoEnv
//#Warn
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using VisualHotKey.Program;

SingleInstance(Force);

SendMode(Input);
SetWorkingDir(Directory.GetCurrentDirectory());
SetKeyDelay(35);

const string commandFileName = "Stellaris 命令.csv";

if (!File.Exists(commandFileName))
{
    return;
}

var commandList = LoadCommands(commandFileName);

RegistCommands(commandList);


List<Command> LoadCommands(string commandFileName)
{
    var result = new List<Command>();

    using (var reader = new StreamReader(commandFileName))
    using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
    {
        result = csv.GetRecords<Command>().ToList();
    }

    return result;
}

void RegistCommands(List<Command> commandList)
{
    HotKey(IfWinActive, vhk_class, "SDL_app");

    foreach (var item in commandList)
    {
        Hotkey(item.Key, ExecuteCallBack);
    }
}


void ExecuteCallBack() {

}
void Execute(ActionType actionType, params string[] commands){
    switch (actionType)
    {
        case ActionType.Input:
            {
                SendCommand(commands[0]);
                break;
            }
        case ActionType.Run:
            {
                RunCommandArray(commands);
                break;
            }
        default:
            break;
    }
}

void SendCommand(string command) {
    Send(command);
    Send(Key.Space);
}

void RunCommand(string command) {
    Send(command);
    Sleep(150);
    Send(Key.Enter);
    Sleep(150);
}

void RunCommandArray(string[] commands) {
    foreach (var item in commands)
    {
        RunCommand(item);
    }
}

void OpenCommandsCSVFileHandler()
{
    Run(commandFileName);
}


void ReloadCommandsHandler()
{
    commandList.Clear();
    Reload();
}

public class Command
{
    [Index(0)]
    public string Key { get; set; }

    [Index(1)]
    public string Description { get; set; }

    [Index(2)]
    public string Commands { get; set; }

    [Index(3)]
    public ActionType ActionType { get; set; } = ActionType.Input;

    public override string ToString() => $"{{ {Description}, {Commands}, {ActionType} }}";
}

public enum ActionType
{
    Input,
    Run
}

