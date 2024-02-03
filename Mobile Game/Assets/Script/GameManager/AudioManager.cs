using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]

    public AudioClip[] BackGroundThem;
    public AudioClip KillEffect;
    public AudioClip DieEffects;
    public AudioClip WinEffect;
    public AudioClip MovementEffect;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogWarning("Duplicate AudioManager instance found. Destroying the duplicate.");
            SFXSource = instance.SFXSource;
            Destroy(this.gameObject);
            return;  // Ensure that the method exits after destroying the duplicate
        }

        // Print debug information about SFXSource
        if (SFXSource == null)
        {
            Debug.LogWarning("SFXSource is null in Awake method.");
        }

        int rand = Random.Range(0, BackGroundThem.Length);
        musicSource.clip = BackGroundThem[rand];
        musicSource.Play();
    }
    private void Update()
    {
        if(!musicSource.isPlaying)
        {
            TranstionBetweenTwoSong();
        }
    }
    public void PlayClip(AudioClip clip)
    {
        if (clip != null && SFXSource != null)
        {
            SFXSource.PlayOneShot(clip);
        }
        if (clip == null) 
        {
            Debug.LogWarning("Audio clip is null. Cannot play the clip.");
        }
        if (SFXSource == null)
        {
            Debug.LogWarning("Audio source is null. Cannot play the clip.");
        }
    }
    private void TranstionBetweenTwoSong()
    {
        musicSource.Stop();

        if(musicSource.clip == BackGroundThem[0])
        {
            musicSource.clip = BackGroundThem[1];
            musicSource.Play();
        }
        else
        {
            musicSource.clip = BackGroundThem[0];
            musicSource.Play();
        }
    }
}
