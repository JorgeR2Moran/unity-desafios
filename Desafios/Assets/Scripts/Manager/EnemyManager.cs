using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private Transform playerTransform;
    public static float enemyNumber = 0;
    private float enemySpeed = 0.5f;

    public static event Action OnEnemyCreated;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyDestroy += IncreaseEnemySpeed;
        InvokeRepeating("CreateEnemy", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreateEnemy(){
        Debug.Log("OnEnemyCreated - Received - EnemyManager");
        OnEnemyCreated?.Invoke();
        int random =  UnityEngine.Random.Range(0, enemyList.Count);
        GameObject enemy = Instantiate(enemyList[random], new Vector3(playerTransform.position.x, 0, playerTransform.position.z * -1), playerTransform.rotation);
        enemy.GetComponent<Enemy>().PlayerTransform = playerTransform;
        enemy.GetComponent<EnemyChaser>().Velocity += enemySpeed;
        //HUDManager.instance.SetSelectedText(enemy.gameObject.tag);
        Debug.Log("LAST ENEMY: " + enemy.gameObject.tag);
    }

    private void IncreaseEnemySpeed(){
        Debug.Log("OnEnemyDestroy - Received - EnemyManager");
        Debug.Log("CURRENT SPEED: " + enemySpeed);
        enemySpeed += 0.5f;
    }    
}
