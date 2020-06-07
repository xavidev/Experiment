using System;
using System.Collections.Generic;

public class Mapping
{
    private Dictionary<string, Action<string, object>> result;

    public Mapping(Dictionary<string, Action<string, object>> result)
    {
        this.result = result;
    }
}