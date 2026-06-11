using UnityEngine;

public class iventsofscore : MonoBehaviour
{
    public player_stats dlascore;
    public Animator animator;
    void onyeaanim()
    {
        animator.SetInteger("animate", (int)dlascore.Box.score);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        onyeaanim();
    }
}
