using UnityEngine;

public class clickUpgrate : AbstractUpgrade
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start02()
    {
        Title.text = "2 в 1";
        basePrice = 1000;
    }

}
