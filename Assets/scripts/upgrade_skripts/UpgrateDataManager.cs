using System.Collections.Generic;
using UnityEngine;

public class UpgrateDataManager : MonoBehaviour
{
    Dictionary<string, DataUpgrade> clovar = new Dictionary<string, DataUpgrade>();
    public void AddData(string key, DataUpgrade infa)
    {
        clovar.Add(key, infa);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
