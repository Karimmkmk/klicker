using UnityEngine;

public class VAUpgrate : AbstractUpgrade
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start02()
    {
        Title.text = "автокликер";
        basePrice = 5000;
    }
    public override void buy_action()
    {

    }

}
