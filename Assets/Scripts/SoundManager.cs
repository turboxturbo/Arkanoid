using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static SoundManager instance;
    private AudioSource audioSource;
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 0f;
    }
    public void PlayBarBreak(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
