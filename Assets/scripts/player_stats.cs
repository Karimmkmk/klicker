using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class player_stats : MonoBehaviour
{
    public save Box = new save();
    public delegate void MyD();
    public event MyD PostLoad;
    public event MyD PreSave;
    void save_game()
    {
        PreSave?.Invoke();
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
        PostLoad?.Invoke();
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
    void OnApplicationQuit()
    {
        save_game();
    }
}
[System.Serializable]
public class save
{
    
    public List<KeyValuePair<string, DataUpgrade>> clovolist = new ();
    public ulong score;
    public uint dialogue;
    public int atnosh;
}