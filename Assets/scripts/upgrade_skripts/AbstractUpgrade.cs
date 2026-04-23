using TMPro;
using UnityEngine;
[System.Serializable]public class DataUpgrade
{
   public uint kolichestvo;
}
public abstract class AbstractUpgrade : MonoBehaviour
{
    protected TextMeshProUGUI Title;
    protected TextMeshProUGUI Count;
    protected TextMeshProUGUI price;
    [SerializeField]protected DataUpgrade data = new DataUpgrade();
    [SerializeField]protected uint basePrice;
    [SerializeField]protected float multiplier = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Title = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        price = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        // TODO: вытаскиваем текст из дочернего объекта.
        Start02();
    }
    protected abstract void Start02();

    // Update is called once per frame
    void Update()
    {
        price.text = (multiplier * basePrice * data.kolichestvo).ToString();
    }
}
