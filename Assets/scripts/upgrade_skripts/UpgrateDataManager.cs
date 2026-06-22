using System.Collections.Generic;
using UnityEngine;

public class UpgrateDataManager : MonoBehaviour
{
    public player_stats exemp;
    Dictionary<string, DataUpgrade> clovar = new Dictionary<string, DataUpgrade>();
    public void AddData(string key, DataUpgrade infa)
    {
        if (clovar.ContainsKey(key))
        {
            return;
        }
        clovar.Add(key, infa);
        print("Add Data " + key);
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
    void Awake()
    {
        exemp = GameObject.Find("Canvas").GetComponent<player_stats>();
        exemp.PostLoad += ConvertorLC;
        exemp.PreSave += ConvertorCL;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ConvertorCL()
    {
        if (clovar.Count > 0)
        {
            exemp.Box.clovolist.Clear();
        }
        foreach (KeyValuePair<string, DataUpgrade> aktyal in clovar)
        {
            exemp.Box.clovolist.Add(new DataUpgradePair(aktyal.Key, aktyal.Value));
        }
    }
    private void ConvertorLC()
    {
        foreach (var aktyal in exemp.Box.clovolist)
        {
            if (clovar.ContainsKey(aktyal._key))
            {
                clovar[aktyal._key] = aktyal._dataUpgrade;
            }
            else
            {
                AddData(aktyal._key, aktyal._dataUpgrade);
            }
        }
    }
}