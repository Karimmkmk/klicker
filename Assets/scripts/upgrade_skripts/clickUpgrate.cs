using UnityEngine;

public class clickUpgrate : AbstractUpgrade
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Update2()
    {
        
    }
    protected override void Start02()
    {
        buttonSystem.OnClick += onclick;
        Title.text = "2 в 1";
        basePrice = 1000;
    }
    public override void buy_action()
    {
        
    }
    void onclick()
    {
        exemp.Box.score += data.kolichestvo;
    }
}
