using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class Persistor : MonoBehaviour
{
    public static Persistor Instance;

    public string playerName;
    public string hiScoreName = "Name";
    public int hiScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadHiScore();
    }




    [System.Serializable]
    class SaveData
    {
        public string hiScoreName;
        public int hiScore;
    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiScoreName = data.hiScoreName;
            hiScore = data.hiScore;
        }
    }

    public void SaveHiScore()
    {
        SaveData data = new SaveData();
        data.hiScoreName = hiScoreName;
        data.hiScore = hiScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }     

}
