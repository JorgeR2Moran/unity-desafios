using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletManager : MonoBehaviour
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

    [SerializeField] private UnityEvent OnTriggerSpeedUp;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("OnTriggerSpeedUp - Called - BulletManager");
            OnTriggerSpeedUp?.Invoke();
            Destroy(gameObject);
        }
    }
}
