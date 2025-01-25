using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AmbientSoundController : MonoBehaviour
{
    private AudioSource _audioSourceAmbient;
    private AudioSource _audioSourceSoundTrack;

    [FormerlySerializedAs("_ambientSounds")]
    [Header("Ambient Sounds")]
    [SerializeField] private AudioClip[] ambientSounds;
    
    [FormerlySerializedAs("_soundTracks")]
    [Header("Sound Tracks")]
    [SerializeField] private AudioClip[] soundTracks;
    
    void Start()
    {
        AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
        _audioSourceAmbient = audioSources[0];
        _audioSourceSoundTrack = audioSources[1];
        
        int idx_ambient_sound = Random.Range(0, ambientSounds.Length);
        int idx_sound_track = Random.Range(0, soundTracks.Length);
        
        _audioSourceAmbient.clip = ambientSounds[idx_ambient_sound];
        _audioSourceSoundTrack.clip = soundTracks[idx_sound_track];
        
        _audioSourceAmbient.Play();
        _audioSourceSoundTrack.Play();
    }
}
