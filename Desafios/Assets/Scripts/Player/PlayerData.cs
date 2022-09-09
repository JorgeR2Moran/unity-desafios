using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player Data", menuName = "ScriptableData/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("General Data")]
    [Tooltip("Speed is between 1 and 10")]
    [SerializeField][Range(1f, 10f)] private float speed = 2f;

    [Header("General Data")]
    [Tooltip("Raydistance is between 1 and 15")]
    [SerializeField] [Range(1f, 15f)] private float rayDistance = 3f;

    public float Speed { get => speed; set => speed = value; }
    public float RayDistance { get => rayDistance; set => rayDistance = value; }
}
