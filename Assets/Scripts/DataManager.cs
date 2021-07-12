using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string PlayerName { get; private set; }
    public string HighScorePlayerName { get; private set; }
    public int HighScore { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadDataFromFile();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public void SetHighScore(string name, int score)
    {
        HighScore = score;
        HighScorePlayerName = name;
    }

    [System.Serializable]
    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
    }

    public void SaveDataToFile()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.HighScoreName = HighScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            HighScorePlayerName = data.HighScoreName;
        }
        else
        {
            HighScore = 0;
            HighScorePlayerName = "";
        }
    }
}
