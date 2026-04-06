using TMPro;
using UnityEngine;

public class text : MonoBehaviour
{
    public player_stats explorerMisha;
    public TextMeshProUGUI seeButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       seeButton = GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
       seeButton.text = "score: " + explorerMisha.score.ToString(); 
    }
}
