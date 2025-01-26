using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AmbientSoundController : MonoBehaviour
{
    private AudioSource _audioSourceAmbient;
    private AudioSource _audioSourceSoundTrack;

    [FormerlySerializedAs("ambientSounds")]
    [FormerlySerializedAs("_ambientSounds")]
    [Header("Ambient Sounds")]
    [SerializeField] private AudioClip[] ambientRiver;
    [SerializeField] private AudioClip[] ambientSea;
    [SerializeField] private bool switchToRiverAmbience = false;
    
    [FormerlySerializedAs("_soundTracks")]
    [Header("Sound Tracks")]
    [SerializeField] private AudioClip[] soundTracks;
    
    void Start()
    {
        AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
        _audioSourceAmbient = audioSources[0];
        _audioSourceSoundTrack = audioSources[1];

        if (switchToRiverAmbience)
        {
            int idx_ambient_sound = Random.Range(0, ambientRiver.Length);
            _audioSourceAmbient.clip = ambientRiver[idx_ambient_sound];
        }
        else
        {
            int idx_ambient_sound = Random.Range(0, ambientSea.Length);
            _audioSourceAmbient.clip = ambientSea[idx_ambient_sound];
        }
        _audioSourceAmbient.Play();
        
        int idx_sound_track = Random.Range(0, soundTracks.Length);
        _audioSourceSoundTrack.clip = soundTracks[idx_sound_track];
        _audioSourceSoundTrack.Play();
    }
}
