using TMPro;
using UnityEngine;

public abstract class AbstractUpgrade : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Count;
    public TextMeshProUGUI description;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Title = GetComponent<TextMeshProUGUI>();
        // TODO: вытаскиваем текст из дочернего объекта.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
