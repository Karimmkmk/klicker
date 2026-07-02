using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class DataUpgrade
{
    public uint kolichestvo;
}
[System.Serializable]
public class DataUpgrade_default : DataUpgrade
{

}
public abstract class AbstractUpgrade : MonoBehaviour
{
    protected UpgrateDataManager manager;
    protected player_stats exemp;
    protected TextMeshProUGUI Title;
    protected TextMeshProUGUI Count;
    protected TextMeshProUGUI price;
    [SerializeField] protected DataUpgrade data = new DataUpgrade_default();
    [SerializeField] protected uint basePrice;
    [SerializeField] protected float multiplier = 1;
    protected ButtonSystem buttonSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Regist()
    {
        data = manager.GetData(this.GetType().Name);
        if (data == null)
        {
            manager.AddData(this.GetType().Name, data);
        }
    }
    void Start()
    {
        buttonSystem = GameObject.Find("Click_Button").GetComponent<ButtonSystem>();
        manager = GameObject.Find("Canvas").GetComponent<UpgrateDataManager>();
        exemp = GameObject.Find("Canvas").GetComponent<player_stats>();
        Title = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        price = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        // TODO: вытаскиваем текст из дочернего объекта.
        Regist();
        Start02();
        linkbutton();
    }
    protected abstract void Start02();
    private void linkbutton()
    {
        Button boxbutton = GetComponent<Button>();
        boxbutton.onClick.AddListener(CA_ative);
    }

    // Update is called once per frame
    void Update()
    {
        uint bla = ToPrice();
        price.text = bla.ToString();
    }
    public uint ToPrice()
    {
        return (uint)(multiplier * (basePrice * (data.kolichestvo + 1)));
    }
    public abstract void buy_action();
    private void CA_ative()
    {
        if (exemp.Box.score < ToPrice())
        {
            return;
        }
        exemp.Box.score -= ToPrice();
        data.kolichestvo += 1;
        buy_action();
    }
}
