using System.IO;
using Newtonsoft.Json;

namespace EmployeeApp.Functions.Utilities;

public static class JsonFileUtilities
{
    private static readonly JsonSerializerSettings Options
        = new() { NullValueHandling = NullValueHandling.Ignore };
    
    public static void PrettyWrite(object obj, string fileName)
    {
        var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, Options);
        
        File.WriteAllText(fileName, jsonString);
    }
    
    public static T DeserializeFromFile<T>(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"File '{fileName}' not found.");
        }

        var jsonString = File.ReadAllText(fileName);
        var obj = JsonConvert.DeserializeObject<T>(jsonString, Options);

        return obj;
    }
}