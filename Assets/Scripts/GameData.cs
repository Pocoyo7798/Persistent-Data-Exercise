using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public string PlayerName;
    public int BestScore;
    public string BestPlayerName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestPlayerName;
        public int BestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.BestPlayerName = BestPlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayerName = data.BestPlayerName;
            BestScore = data.BestScore;
        }
    }
}
