using System.Collections.Generic;
using UnityEngine;

public class AudioWeapon : ModelMonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> AttackClips;
    [SerializeField] private List<AudioClip> SwapClips;

    private static AudioWeapon instance;
    public static AudioWeapon Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances of AudioManager detected. Destroying the new instance.");
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlaySwapSound(int index = 0)
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is not assigned in AudioManager.");
            return;
        }
        audioSource.clip = SwapClips[index];
        audioSource.Play();
    }

    public void PlayAttackSound(int index = 0)
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is not assigned in AudioManager.");
            return;
        }
        audioSource.clip = AttackClips[index];
        audioSource.Play();
    }

}
