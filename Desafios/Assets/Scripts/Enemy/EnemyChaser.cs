using UnityEngine;

public class EnemyChaser : Enemy
{
    [SerializeField] private EnemyChaserData enemyChaserData;

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    protected void ChasePlayer()
    {
        LookPlayer();
        if(!GameManager.HitCar){
            Vector3 direction = PlayerTransform.position - transform.position;
            if(direction.magnitude > enemyChaserData.EnemySeparation)
            {
                transform.position += direction.normalized * enemyChaserData.Speed * Time.deltaTime;
            }
        }
    }
}
