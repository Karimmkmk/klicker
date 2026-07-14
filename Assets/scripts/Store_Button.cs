using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine;

public class Store_Button : MonoBehaviour
{
    public GameObject rescroll;
    public Image pakaz_image;
    public Sprite green;
    public Sprite red;
    private RectTransform rect;
    private bool is_visible;
    public void Start()
    {
        rect = rescroll.GetComponent<RectTransform>();
    }
    public void clickTheButton()
    {
        is_visible = !is_visible;
        if (is_visible == false)
        {
            pakaz_image.sprite = red;
            rect.offsetMin = new Vector2(20000, rect.offsetMin.y);
            rect.offsetMax = new Vector2(20000, rect.offsetMax.y);
        }
        else
        {
            pakaz_image.sprite = green;
            rect.offsetMin = new Vector2 (0, rect.offsetMin.y);
            rect.offsetMax = new Vector2 (0, rect.offsetMax.y);
        }
        //rescroll.SetActive(!rescroll.activeSelf);
    }
}
