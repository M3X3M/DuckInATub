using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BubbleBase : MonoBehaviour
{
    [SerializeField] private List<AudioClip> pop_sounds;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Pop(bool with_sound = false)
    {
        GetComponent<SphereCollider>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;

        if (with_sound)
        {
            int audio_pick = Random.Range(0, pop_sounds.Count - 1);
            StartCoroutine(PlayClipAndExecute(pop_sounds[audio_pick]));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator PlayClipAndExecute(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        Destroy(gameObject);
    }
}
