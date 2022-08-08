using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.transform.parent != null && other.transform.parent.gameObject.name.Equals("Portal")){
            Debug.Log("Collison: " + other.transform.parent.gameObject.name);
            if(other.transform.parent.gameObject.GetComponent<PortalManager>() != null){
                Debug.Log("Shrinker");
            }
            else{
                Debug.Log("No specific component.");
            }
        }
        if(other.gameObject.name.Equals("Wall")){
            Debug.Log("Collison: " + other.transform.parent.gameObject.name);
            if(other.gameObject.GetComponent<WallManager>() != null){
                Debug.Log("Teleporter");
            }
            else{
                Debug.Log("No specific component.");
            }
        }
    }
}
