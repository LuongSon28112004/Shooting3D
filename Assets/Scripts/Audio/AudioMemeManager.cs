using System.Collections.Generic;
using UnityEngine;

public class AudioMemeManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> memeClips;

    private static AudioMemeManager instance;
    public static AudioMemeManager Instance { get => instance; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances of AudioMemeManager detected. Destroying the new instance.");
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayMemeSound(int index = 0)
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is not assigned in AudioMemeManager.");
            return;
        }
        if (index < 0 || index >= memeClips.Count)
        {
            Debug.LogWarning("Invalid index for meme sound.");
            return;
        }
        audioSource.clip = memeClips[index];
        audioSource.Play();
    }
}
