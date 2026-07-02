using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    public player_stats explorer;
    public delegate void OnClickDelegate();
    public event OnClickDelegate OnClick;
    public void fancshen()
    {
        explorer.Box.score += 1;
        OnClick?.Invoke();
    }
    public void InvokeEvent()
    {
        OnClick?.Invoke();
    }
}
