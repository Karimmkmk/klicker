using UnityEngine;
using System.IO;

public class player_stats : MonoBehaviour
{
    public ulong score;
    public save Box = new save();
    void save_game()
    {
        string json_stroka = JsonUtility.ToJson(Box);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json_stroka);
        print(Application.persistentDataPath + "/save.json");

    }
    void load_game()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        save_game();
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