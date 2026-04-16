using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine;

public class Store_Button : MonoBehaviour
{
  public GameObject rescroll;
  public Image pakaz_image;
  public Sprite green;
  public Sprite red;
  public void clickTheButton()
    {
        if (rescroll.activeSelf)
        {
            pakaz_image.sprite = red;
        }
        else
        {
            pakaz_image.sprite = green;
        }
        rescroll.SetActive(!rescroll.activeSelf);
    }
}
