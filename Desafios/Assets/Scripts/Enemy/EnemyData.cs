using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy Data", menuName = "ScriptableData/Create Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("General Data")]
    [Tooltip("Raydistance is between 1 and 15")]
    [SerializeField] [Range(1f, 15f)] private float rayDistance = 3f;

    public float RayDistance { get => rayDistance; set => rayDistance = value; }
}
