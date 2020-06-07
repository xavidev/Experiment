using System;

[AttributeUsage(AttributeTargets.Property | 
    AttributeTargets.Field, AllowMultiple = true)]
public class FieldAttribute : System.Attribute 
{
    public string Field { get; private set; }

    public FieldAttribute(string field)
    {
        this.Field = field;
    }
}