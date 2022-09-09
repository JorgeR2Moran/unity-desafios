using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy Chaser Data", menuName = "ScriptableData/Create Enemy Chaser Data")]
public class EnemyChaserData : ScriptableObject
{
    [Header("Movement Data")]
    [Tooltip("Speed is between 1 and 10")]
    [SerializeField][Range(1f, 10f)] private float speed = 2f;

    [Header("Movement Data")]
    [Tooltip("Enemy Separation is between 1 and 10")]
    [SerializeField] private float enemySeparation = 2f;
    
    public float Speed { get => speed; set => speed = value; }
    public float EnemySeparation { get => enemySeparation; set => enemySeparation = value; }
}
