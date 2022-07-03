using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointPosition : MonoBehaviour
{
    [SerializeField] private GameObject[] movePointPositions;
    private int movePointPositionsIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(movePointPositions[movePointPositionsIndex].transform.position, transform.position) < .1f)
        {
            movePointPositionsIndex++;
            if (movePointPositionsIndex >= movePointPositions.Length)
            {
                movePointPositionsIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, movePointPositions[movePointPositionsIndex].transform.position, Time.deltaTime * speed);
    }
}
