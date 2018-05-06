using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour {

    [SerializeField]
    private GameObject throwingObject;

    private Rigidbody objectRigidBody;

    private Vector3 startingPosition;
    private Quaternion startingRotation;

    private float objectForce = 0f;
    private float maximumForce = 600f;
    private float delay = 1f;
    private float timer;

    [SerializeField]
    private float objectReturnSpeed = 25f;

    [SerializeField]
    private AudioSource objectReturnAudioSound;

    [SerializeField]
    private AudioClip objectReturnAudioClip;


	// Use this for initialization
	void Start () {
        objectRigidBody = throwingObject.GetComponent<Rigidbody>();
        startingPosition = throwingObject.transform.localPosition;
        startingRotation = throwingObject.transform.localRotation;
        objectRigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		
        //if player has started the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            BeginThrow();
        }

        //if player is continuing to hold down the mouse button
        if (Input.GetMouseButton(0))
        {
            PowerUpThrow();
        }

        //if player releases the mouse button
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseObject(); 
        }
    }

    private void BeginThrow(){

        objectRigidBody.isKinematic = true;
        objectRigidBody.velocity = Vector3.zero;
        objectRigidBody.angularVelocity = Vector3.zero;

        //return object to start position

        throwingObject.transform.parent = transform;
        throwingObject.transform.localRotation = startingRotation;

        StartCoroutine(ReturnObject());

        //play the object return sound
        objectReturnAudioSound.PlayOneShot(objectReturnAudioClip);

    }

    private void ReleaseObject(){

        objectRigidBody.isKinematic = false;
        throwingObject.transform.parent = null;
        objectRigidBody.AddRelativeForce(throwingObject.transform.forward * objectForce);

        //resetting force and timer
        objectForce = 0f;
        timer = 0f;

        StopCoroutine(ReturnObject());
    }

    private void PowerUpThrow(){

        //increment timer onc per frame
        timer += Time.deltaTime;
        if (timer > delay)
        {
            timer = delay;
        }

        //lerp the object force the longer the player holds
        float percentage = timer / delay;

        objectForce = Mathf.Lerp(0f, maximumForce, percentage);

    }

    IEnumerator ReturnObject(){

        float distanceThreshold = 0.1f;
        //while there is still small amount of distance between the thrown object and starting position
        while (Vector3.Distance(throwingObject.transform.localPosition, startingPosition) > distanceThreshold)
        {
            //.. move the ball to starting the position
            throwingObject.transform.localPosition = Vector3.Lerp(throwingObject.transform.localPosition,
                                                                  startingPosition, 
                                                                  Time.deltaTime * objectReturnSpeed);

            //..if the thrown object is now close to the start position, reset the position directly
            if (Vector3.Distance(throwingObject.transform.localPosition, startingPosition) < 0.1f)
            {
                throwingObject.transform.localPosition = startingPosition;
            }


            // yeild back control to the main script
            yield return null;

        }
    }
}
