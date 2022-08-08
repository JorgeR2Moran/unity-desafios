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

    private void LookPlayer()
    {
        Vector3 playerDirection = playerTransform.position - transform.position;
        Quaternion newRotetion = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotetion, 2f * Time.deltaTime);
        //transform.LookAt(playerTransform);
    }

    private void ChasePlayer()
    {
        LookPlayer();
        Vector3 direction = playerTransform.position - transform.position;
        if(direction.magnitude > enemySeparation)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}
