using VisualHotKey.Models.Keys;

namespace VisualHotKey.Attribute;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class HotKeyAttribute : System.Attribute
{
    public string Key;
    
    public HotKeyAttribute(string key)
    {
        Key = key;
    }

    //public HotKeyAttribute(params Key[] keys)
	//{

	//}

    //public HotKeyAttribute(Key key, int numberKey)
    //{
    //    Key = key;
    //}


}