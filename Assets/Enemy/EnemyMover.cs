using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyMover : MonoBehaviour
{
    [SerializeField] List <Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float travelSpeed = 1f;

    void Start()
    {

        StartCoroutine(FollowPath());
    }

    void Update()
    {
        
    }

    IEnumerator FollowPath()
    {
        
        foreach (Waypoint waypoint in path)
        {
            Vector3 currentLoationPoint = transform.position;
            Vector3 waypointLocation = waypoint.transform.position;
            float travelPercentage = 0f;

            transform.LookAt(waypointLocation);

            while (travelPercentage < 1)
            {
                travelPercentage += Time.deltaTime * travelSpeed;
                Vector3 waypointLocationLERP = Vector3.Lerp(currentLoationPoint, waypointLocation, travelPercentage);
                //Debug.Log($"Moving to: {waypoint.name}");
                transform.position = waypointLocationLERP;
                yield return new WaitForEndOfFrame();
            }

        }
    }

}
