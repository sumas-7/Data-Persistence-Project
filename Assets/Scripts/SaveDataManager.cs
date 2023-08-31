using System.IO;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager instance;
    public string playerName;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SaveData(int score)
    {
        if(score > LoadData().score)
        {
            SaveFile saveData = new SaveFile();
            saveData.playerName = this.playerName;
            saveData.score = score;

            string json = JsonUtility.ToJson(saveData);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }
    public SaveFile LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            return JsonUtility.FromJson<SaveFile>(json);
        }
        else
            return new SaveFile();
    }
}

[System.Serializable]
public class SaveFile
{
    public SaveFile()
    {
        score = 0;
        playerName = "Name";
    }

    public int score;
    public string playerName;
}