using System;

// Nuget Packages 
using Rainbows;
using NAudio.Wave;
using System.Runtime.CompilerServices;

public class Program{

    
    public object callFunctionInString(string functionName, params object[] parameters)
    {
        var method = this.GetType().GetMethod(functionName);
        if (method != null)
        {
            return method?.Invoke(this, parameters);
        }
        else
        {
            throw new Exception($"Method {functionName} not found.");
        }
    }

    public static async void Main(string[] args){
        // GameSelect.gameSelect();
    }
}