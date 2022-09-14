using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private EnemyData enemyData;
    public static event Action OnEnemyDestroy;

    public Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }

    private void FixedUpdate()
    {
        EnemyRaycast();
    }

    private void EnemyRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out hit, enemyData.RayDistance))
        {
            if (hit.transform.CompareTag("Player")){
                GameManager.Score--;
                GameManager.HitCar = true;
                Debug.Log("OnEnemyDestroy - Called - EnemyMovement");
                OnEnemyDestroy?.Invoke();
                Destroy(gameObject);
            }
        }else{
            GameManager.HitCar = false;
        }
    }

    protected void LookPlayer()
    {
        Vector3 playerDirection = PlayerTransform.position - transform.position;
        Quaternion newRotetion = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotetion, 2f * Time.deltaTime);
        //transform.LookAt(playerTransform);
    }   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = raycastPoint.TransformDirection(Vector3.forward) * enemyData.RayDistance;
        Gizmos.DrawRay(raycastPoint.position, direction);
    }
}
