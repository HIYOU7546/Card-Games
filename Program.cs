using System;

// Nuget Packages 
using Rainbows;
using NAudio.Wave;
using System.Runtime.CompilerServices;

public class Program
{

    /// <summary>
    /// Dynamically calls a method by its name with the provided parameters.
    /// </summary>
    /// <param name="functionName">The name of the function you want to call.</param>
    /// <param name="parameters">The parameters to the function you want to call</param>
    /// <returns>The outcome of the method called.</returns>
    /// <exception cref="Exception">Function called wasn't found.</exception>
    // public object callFunctionInString(string functionName, params object[] parameters)
    // {
    //     var method = this.GetType().GetMethod(functionName);
    //     if (method != null)
    //         return method.Invoke(this, parameters);
    //     else
    //         throw new Exception($"Method {functionName} not found.");
    // }

    public static async void Main(string[] args)
    {
        // GameSelect.gameSelect();
    }
}