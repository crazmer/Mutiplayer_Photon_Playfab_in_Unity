using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex=0;
    private float minDistance = 0.1f;
    private float lastWaypointIndex;

    public float movementSpeed = 1f;
    private float roatationSpedd = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex]; 
    }

    // Update is called once per frame
    void Update()
    {
        float movemntStep = movementSpeed * Time.deltaTime;
        float rotationStep = roatationSpedd * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        Debug.DrawRay(transform.position, transform.forward * 50f,Color.green,0f);
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWayPoint(distance);
        //Debug.Log(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position,movementSpeed);

    }
    void CheckDistanceToWayPoint(float currentDistance)
    {
        if (currentDistance<=minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }
    void UpdateTargetWaypoint()
    {
        if(targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }
}
