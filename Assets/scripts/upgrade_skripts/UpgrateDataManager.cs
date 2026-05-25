using System.Collections.Generic;
using UnityEngine;

public class UpgrateDataManager : MonoBehaviour
{
    Dictionary<string, DataUpgrade> clovar = new Dictionary<string, DataUpgrade>();
    public void AddData(string key, DataUpgrade infa)
    {
        clovar.Add(key, infa);
    }
    public DataUpgrade GetData(string key)
    {
        DataUpgrade vremas;
        if (clovar.TryGetValue(key, out vremas))
        {
            return vremas;
        }
        return null;
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
