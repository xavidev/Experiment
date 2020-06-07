using System;

[AttributeUsage(AttributeTargets.Property | 
    AttributeTargets.Field, AllowMultiple = true)]
public class SheetAttribute : System.Attribute
{
    private string sheet;

    public SheetAttribute(string sheet)
    {
        this.sheet = sheet;
    }
}