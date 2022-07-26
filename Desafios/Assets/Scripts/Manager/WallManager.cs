using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallManager : MonoBehaviour
{
    /*[SerializeField] private float triggerTeleportTime = 2f;
    [SerializeField] private Transform nextPortal;
    private float timeInPortal = 0;

    private void OnCollisionStay(Collision other)
    {
        timeInPortal += Time.deltaTime;
        if (timeInPortal >= triggerTeleportTime)
        {
            other.transform.position = new Vector3(Random.Range(-4f, 4f), other.transform.position.y, Random.Range(-4f, 4f));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        timeInPortal = 0;
    }*/

    [SerializeField] private UnityEvent OnTriggerOutOfBounds;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("OnTriggerOutOfBounds - Called - WallManager");
            OnTriggerOutOfBounds?.Invoke();
        }
    }
}
