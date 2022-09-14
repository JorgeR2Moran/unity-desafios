using UnityEngine;

public class EnemyChaser : Enemy
{
    [SerializeField] private EnemyChaserData enemyChaserData;
    private float velocity = 0.5f;

    public float Velocity { get => velocity; set => velocity = value; }
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
                transform.position += direction.normalized * Velocity * Time.deltaTime;
            }
        }
    }
}
