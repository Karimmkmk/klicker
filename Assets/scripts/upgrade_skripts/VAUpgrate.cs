using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VAUpgrate : AbstractUpgrade
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool is_active;
    public Button button_upgrate;
    protected override void Start02()
    {
        button_upgrate.onClick.AddListener(IsActiveTrue);
        Title.text = "автокликер";
        basePrice = 5000;
    }
    public override void buy_action()
    {

    }
    public void Update()
    {
        if (is_active)
            buttonSystem.InvokeEvent();

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
