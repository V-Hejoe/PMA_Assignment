using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    //Based on IManager from "Learning C# by Developing Games with Unity Sixth Edition": https://github.com/PacktPublishing/Learning-C-by-Developing-Games-with-Unity-Sixth-Edition/blob/main/Ch_13_Starter/Assets/Scripts/IManager.cs
    string State { get; set; }
    void Initialize();
}