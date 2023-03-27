using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

public class DataManager : MonoBehaviour, IManager
{
    //Based on DataManager from Chapter 12 of "Learning C# by Developing Games with Unity Sixth Edition": https://github.com/PacktPublishing/Learning-C-by-Developing-Games-with-Unity-Sixth-Edition/blob/main/Ch_13_Starter/Assets/Scripts/DataManager.cs

    [SerializeField] private float time;
    
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    
    private string _dataPath;
    private string _textFile;
    
    void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data/";

        Debug.Log(_dataPath);

        _textFile = _dataPath + $"Save_Data.csv";
    }

    void Start()
    {
        Initialize();

        if (Accelerometer.current == null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
        }
    }

    public void StartDataCollecting()
    {
        float remainingTime = time;

        while (remainingTime > 0)
        {
            UpdateTextFile();
            remainingTime -= Time.deltaTime;
        }
    }

    public void Initialize()
    {
        _state = "Data Manager initialized..";
        Debug.Log(_state);

        NewDirectory();
        NewTextFile();
        ReadFromFile(_textFile);
    }

    public void FilesystemInfo()
    {
        Debug.LogFormat("Path separator character: {0}",
        Path.PathSeparator);
        Debug.LogFormat("Directory separator character: {0}",
        Path.DirectorySeparatorChar);
        Debug.LogFormat("Current directory: {0}",
        Directory.GetCurrentDirectory());
        Debug.LogFormat("Temporary path: {0}",
        Path.GetTempPath());
    }

    public void NewDirectory()
    {
        if (Directory.Exists(_dataPath))
        {
            Debug.Log("Directory already exists...");
            return;
        }
        Directory.CreateDirectory(_dataPath);
        Debug.Log("New directory created!");
    }

    public void DeleteDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            Debug.Log("Directory doesn't exist or has already been deleted...");

            return;
        }
        
        Directory.Delete(_dataPath, true);
        Debug.Log("Directory successfully deleted!");
    }

    public void NewTextFile()
    {
        if (File.Exists(_textFile))
        {
            Debug.Log("File already exists...");
            return;
        }
        File.WriteAllText(_textFile, "x,y,z\n\n");
        Debug.Log("New file created!");
    }

    public void UpdateTextFile()
    {
        if (!File.Exists(_textFile))
        {
            Debug.Log("File doesn't exist...");
            return;
        }
        File.AppendAllText(_textFile, $"{Input.acceleration.x},{Input.acceleration.y},{Input.acceleration.z}\n");
        Debug.Log("File updated successfully!");
    }

    public void ReadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist...");
            return;
        }
        Debug.Log(File.ReadAllText(filename));
    }

    public void DeleteFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist or has already been deleted...");

            return;
        }
        File.Delete(_textFile);
        Debug.Log("File successfully deleted!");
    }
}