using DialogueEditor;
using UnityEngine;

public class diomanager : MonoBehaviour
{
    public ConversationManager explorer;
    public player_stats player_Stats;
    public Transform boxbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void dio1()
    {
        NPCConversation npc = boxbox.GetChild(0).GetComponent<NPCConversation>();
        explorer.StartConversation(npc);
        player_Stats.Box.dialogue = 1;
    }
}
