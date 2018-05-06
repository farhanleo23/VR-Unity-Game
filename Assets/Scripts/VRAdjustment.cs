using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.VR;
using UnityEngine.XR;

public class VRAdjustment : MonoBehaviour {

    private Vector3 monitorRotation = new Vector3(-12f, 0f, 0f);
    private Vector3 openVRPosition = new Vector3(0f, -1.75f, 0f);

	// Use this for initialization
	void Awake () {
		
        //checking for VR device
        if (!XRDevice.isPresent)
        {
            //tilt the camera upwards
            transform.localRotation = Quaternion.Euler(monitorRotation);
        } else
        {
            if (XRSettings.loadedDeviceName == "OpenVR")
            {
                // move camera to floor
                transform.localPosition = openVRPosition;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyUp(KeyCode.R))
        {
            InputTracking.Recenter();
        }
    }


	private void OnApplicationQuit()
	{
        //disable VR device when application quites
        XRSettings.enabled = false;
	}
}
