using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public class SimpleButtonSound : MonoBehaviour
{
    private Button button;
    private AudioSource audioSource;

    [SerializeField] private AudioClip clickSound;

    private void Awake()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }
}