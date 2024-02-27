using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    void Start()
    {
        MoveToNextWaypoint();
    }

    void Update()
    {
        if (Random.Range(1, 11) == 5)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Vector3 nextPosition = waypoints[currentWaypointIndex].position;
            StartCoroutine(MoveObject(nextPosition, 1f));
            currentWaypointIndex++;
        }
        else
        {
            currentWaypointIndex = 0;
        }
    }

    IEnumerator MoveObject(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}

