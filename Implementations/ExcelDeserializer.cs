using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;

public class ExcelDeserializer<T> : IDeserializer<T> where T : new()
{
    private string path;
    private string sheet;

    private Type currentType;
    private T model;

    private Dictionary<string, PropertyInfo> mapping = 
        new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);

    public ExcelDeserializer(string path)
    {
        this.model = new T();
        this.path = path;
        this.GetMapping();
    }

    public T  Deserialize()
    {
        using (var package = new ExcelPackage(new FileInfo(this.path)))
        {
            var sheet = package.Workbook.Worksheets[this.sheet];
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.reflection.propertyinfo.setvalue?view=netcore-3.1

        return this.model;
    }

    private void GetMapping()
    {
        this.currentType = this.model.GetType();
        this.sheet = (string)currentType.GetCustomAttributes(typeof(SheetAttribute), false).FirstOrDefault();

        var properties = currentType.GetType().GetProperties();
        foreach (var property in properties)
        {
            var attribute = property
                            .GetCustomAttributes(typeof(FieldAttribute), false)
                            .FirstOrDefault();
            this.mapping.Add((string)attribute, property);
        }
    }
}