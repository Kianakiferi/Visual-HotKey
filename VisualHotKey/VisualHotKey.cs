
using VisualHotKey.Program;

namespace VisualHotKey;

public class VisualHotKey
{
    private InstanceMode mode;
    public void SingleInstance(InstanceMode mode) 
    {
        this.mode = mode;
    }

}
