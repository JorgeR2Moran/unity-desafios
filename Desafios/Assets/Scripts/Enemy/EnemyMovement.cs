using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private enum EnemyType{Peeper, Stalker};
    [SerializeField][Range(1f, 10f)] private float speed = 2f;
    [SerializeField] private EnemyType enemyType = EnemyType.Peeper;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float enemySeparation = 2f;
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private float rayDistance = 3f;

    public Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(enemyType)
        {
            case EnemyType.Peeper:
                LookPlayer();
                break;
            case EnemyType.Stalker:
                ChasePlayer();
                break;
        }
    }

    private void FixedUpdate()
    {
        EnemyRaycast();
    }

    private void EnemyRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Player")){
                GameManager.HitCar = true;
                Debug.Log("Hit Car");
                Destroy(gameObject);
            }
        }else{
            GameManager.HitCar = false;
        }
    }

    private void LookPlayer()
    {
        Vector3 playerDirection = PlayerTransform.position - transform.position;
        Quaternion newRotetion = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotetion, 2f * Time.deltaTime);
        //transform.LookAt(playerTransform);
    }

    private void ChasePlayer()
    {
        LookPlayer();
        if(!GameManager.HitCar){
            Vector3 direction = PlayerTransform.position - transform.position;
            if(direction.magnitude > enemySeparation)
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = raycastPoint.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawRay(raycastPoint.position, direction);
    }
}
