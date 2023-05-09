using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class MyJson
    {
        public static void Write<T>(string path, T obj)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
        }
        public static T Read<T>(string path)
        {
            if (!File.Exists(path))
            {
                Write<List<string>>(path, new List<string>());
            }
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}
