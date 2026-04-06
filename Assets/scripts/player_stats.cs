using UnityEngine;
using System.IO;

public class player_stats : MonoBehaviour
{
    public save Box = new save();
    void save_game()
    {
        string json_stroka = JsonUtility.ToJson(Box);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json_stroka);

    }
    void load_game()
    {
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
            string vozvrat = File.ReadAllText(Application.persistentDataPath + "/save.json");
        Box = JsonUtility.FromJson<save>(vozvrat);
        }
        else
        {
            save_game();
        }
    }
    void OnDestroy()
    {
        save_game();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        load_game();
        print(Application.persistentDataPath + "/save.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class save
{
    public ulong score;
}