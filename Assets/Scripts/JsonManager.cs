using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonManager
{
    private static JsonManager _instance;


    public static JsonManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new JsonManager();
            }
            return _instance;
        }
    }

    public JsonManager()
    {
#if UNITY_ANDROID
        fileDir = string.Format("{0}/{1}", Application.persistentDataPath,fileDir);
        filePath = string.Format("{0}/{1}", fileDir, fileName);
#elif UNITY_IPHONE
        fileDir = string.Format("{0}/{1}", Application.persistentDataPath,fileDir);
        filePath = string.Format("{0}/{1}", fileDir, fileName);
#else
        fileDir = string.Format("{0}/{1}", Application.dataPath, _fileDir);
        filePath = string.Format("{0}/{1}", fileDir, _fileName);
#endif
    }

    private const string _fileDir = "Save";
    private const string _fileName = "GameData.json";
    private readonly string fileDir;
    private readonly string filePath;



    public string Read()
    {
        string result = "";
        if (File.Exists(filePath))
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                result = sr.ReadToEnd();
            }
        }
        return result;
    }


    public T GetGameData<T>()
    {
        return JsonConvert.DeserializeObject<T>(Read());
    }

    public string Save<T>(T gameData)
    {
        if (!Directory.Exists(fileDir))
        {
            Directory.CreateDirectory(fileDir);
        }
        string jsonStr = JsonConvert.SerializeObject(gameData);
        using (StreamWriter sw = File.CreateText(filePath))
        {
            sw.Write(jsonStr);
        }
        return jsonStr;
    }

    public string UpdateData<T>(T gameData)
    {
        return Save(gameData);
    }
}
