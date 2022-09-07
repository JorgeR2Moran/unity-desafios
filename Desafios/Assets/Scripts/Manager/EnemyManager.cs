using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreateEnemy(){
        int random =  Random.Range(0, enemyList.Count);
        GameObject enemy = Instantiate(enemyList[random], new Vector3(playerTransform.position.x, 0, playerTransform.position.z * -1), playerTransform.rotation);
        enemy.GetComponent<EnemyMovement>().PlayerTransform = playerTransform;

        HUDManager.instance.SetSelectedText(enemy.gameObject.tag);
        Debug.Log("LAST ENEMY: " + enemy.gameObject.tag);
    }
}
