using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shooting, patrolling;

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private AIDetector detector;


    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        player = GetComponentInChildren<PlayerController>();
    }

    private void Update()
    {
        if (detector.TargetVisible)
        {
            shooting.PerformAction(player, detector);
        }
        else
        {
            patrolling.PerformAction(player, detector);
        }
    }
}
