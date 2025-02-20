using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BubbleBase : MonoBehaviour
{
    [SerializeField] private List<AudioClip> pop_sounds;
    [SerializeField] private ParticleSystem pop_particles;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Pop(bool with_sound = false)
    {
        GetComponent<SphereCollider>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;

        pop_particles.Play();

        if (with_sound)
        {
            int audio_pick = Random.Range(0, pop_sounds.Count - 1);
            audioSource.volume = Random.Range(0.5f, 1.0f);
            audioSource.pitch = Mathf.Lerp(2.0f, 0.2f, transform.localScale.x);
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
