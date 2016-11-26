using UnityEngine;
using System.Collections;

public class ObjRespawner : MonoBehaviour
{
    [SerializeField] private GameObject objToSpawn;
    [Tooltip("Only fill out spawn pos OR distance to move, spawnPos = set position")]
    [SerializeField] private Vector3 spawnPos;
    [Tooltip("Only fill out target pos OR distance to move, distance = move X units forward")]
    [SerializeField] private float distanceToMove;
    [SerializeField] private float respawnTimer;

    void Start()
    {

    }
}
