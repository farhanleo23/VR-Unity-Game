using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerSound : MonoBehaviour
{

    [SerializeField]
    private List<AudioClip> audioClips;

    [SerializeField]
    private AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {

        //move the audio source to the other game object
        audioSource.transform.position = other.transform.position;

        //adjust volume to relative velocity of the collision
        audioSource.volume = Mathf.Clamp01(other.GetComponent<Rigidbody>().velocity.magnitude * 0.2f);

        //randomize the pitch to add more varity
        audioSource.pitch = Random.Range(0.98f, 1.02f);

        //randomly chose clip from available list of clips
        audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];

        //play the clip
        audioSource.Play();
    }

}
