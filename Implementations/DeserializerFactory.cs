using System;
using System.Collections.Generic;
using System.IO;

public class DeserializerFactory<T> where T : IDeserializerModel, new()
{
    private string path;
    private Dictionary<string, IDeserializer<T>> deserializerTable = 
        new Dictionary<string, IDeserializer<T>>(StringComparer.OrdinalIgnoreCase);
    
    public DeserializerFactory(string path)
    {
        this.path = path;
        this.InitTable();
    }

    private void InitTable()
    {
        this.deserializerTable.Add(".xlsx", new ExcelDeserializer<T>(this.path));
        this.deserializerTable.Add(".xls", new ExcelDeserializer<T>(this.path));
    }

    public IDeserializer<T> Make()
    {
        var fileType = Path.GetExtension(this.path);
        deserializerTable.TryGetValue(fileType, out IDeserializer<T> result);

        if (result == null)
        {
            throw new NotImplementedException();
        }

        return result;
    }
}
