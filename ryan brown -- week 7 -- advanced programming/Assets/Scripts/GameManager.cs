using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Color unitColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class saveData
    {
        public Color unitColor;
    }

    public void saveColor()
    {
        saveData data = new saveData();
        data.unitColor = unitColor;

        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",jsonData);
    }

    public void loadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        string jsonData = File.ReadAllText(path);

        saveData data = JsonUtility.FromJson<saveData>(jsonData);

        unitColor = data.unitColor;
    }

}
