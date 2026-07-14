using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VAUpgrate : AbstractUpgrade
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool is_active;
    public Button button_upgrate;
    public GameObject autoclick;
    protected override void Start02()
    {
        button_upgrate.onClick.AddListener(IsActiveTrue);
        Title.text = "автокликер";
        basePrice = 5000;
    }
    public override void buy_action()
    {
        
    }
    protected override void Update2()
    {
        if (is_active)
        {
            exemp.Box.score += 1;
            buttonSystem.InvokeEvent();
        }
        if (data.kolichestvo < 1)
        {
            autoclick.SetActive(false);
        }
        else if (is_active == true)
        {
            autoclick.SetActive(false);
        }
        else if (data.kolichestvo > 1 && is_active == false)
        {
            autoclick.SetActive(true);
        }

    }
    public void IsActiveTrue()
    {
        if (is_active == true)
            return;
        if (data.kolichestvo < 1)
            return;
        is_active = true;
        data.kolichestvo -= 1;
        StartCoroutine(WaitClick());
    }
    IEnumerator WaitClick()
    {
        yield return new WaitForSeconds(30);
        is_active = false;
    }
}
