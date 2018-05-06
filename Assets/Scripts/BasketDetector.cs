using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketDetector : MonoBehaviour {

    void OnTriggerExit(Collider other){
        if (other.attachedRigidbody.velocity.y < 0)
        {
            GameManager.score++;
        }
    }
}
