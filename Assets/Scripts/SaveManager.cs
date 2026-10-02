using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string path;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "save.json");
    }

    public void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true); 

        File.WriteAllText(path, json);
        Debug.Log($"Game Saved to: {path}");
    }

    public SaveData LoadGame()
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning("No save file found! Returning fresh data.");
            return new SaveData();
        }

        // 1. Read the raw text string back from disk
        string json = File.ReadAllText(path);

        // 2. Turn the string back into a usable C# object
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        return data;
    }
}
