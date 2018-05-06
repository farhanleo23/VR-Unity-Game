using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImpactSound : MonoBehaviour {

    [SerializeField]
    private List<AudioClip> audioClips;

    [SerializeField]
    private AudioSource audioSource;

    void OnCollisionEnter(Collision other){

        //move the audio source to the contact point
        audioSource.transform.position = other.contacts[0].point;

        //adjust volume to relative velocity
        audioSource.volume = Mathf.Clamp01(other.relativeVelocity.magnitude * 0.2f);

        //randomize the pitch to add more varity
        audioSource.pitch = Random.Range(0.98f, 1.02f);

        //randomly chose clip from available list of clips
        audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];

        //play the clip
        audioSource.Play();
    }
	
}
