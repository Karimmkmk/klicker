using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [Header("Audio Settings:")]
    [SerializeField] private AudioClip musicClip;
    [SerializeField] [Range(0f, 1f)] private float volume = 0.5f;
    [SerializeField] private bool playOnStart = true;
    
    private static BackgroundMusic instance;
    private AudioSource audioSource;
    
    private void Awake()
    {
        // Singleton паттерн - предотвращает создание дубликатов музыки
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Музыка не уничтожается при смене сцены
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        
        ConfigureAudioSource();
    }
    
    private void ConfigureAudioSource()
    {
        audioSource.clip = musicClip;
        audioSource.volume = volume;
        audioSource.loop = true; // Цикличное воспроизведение
        audioSource.playOnAwake = playOnStart;
    }
    
    private void Start()
    {
        if (playOnStart && musicClip != null)
        {
            PlayMusic();
        }
    }
    
    public void PlayMusic()
    {
        if (audioSource != null && musicClip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    
    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    
    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
    
    public void ResumeMusic()
    {
        if (audioSource != null && !audioSource.isPlaying && audioSource.time > 0)
        {
            audioSource.UnPause();
        }
    }
    
    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
    
    public float GetVolume()
    {
        return volume;
    }
    
    public bool IsPlaying()
    {
        return audioSource != null && audioSource.isPlaying;
    }
}
