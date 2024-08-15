using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyMover : MonoBehaviour
{
    [SerializeField] List <Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float travelSpeed = 1f;
    GameObject[] pathToFollow;
    private int lives = 2;
    Enemy enemy;

    void Awake()
    {
        enemy = FindAnyObjectByType<Enemy>();
    }

    void Update()
    {
        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }    
    }
    void OnEnable()
    {
        
        FindPathTag();
        ReturnToStart();
        StartCoroutine(FollowPath());
        
    }

    void FindPathTag()
    {
        path.Clear();
        GameObject waypointPathParent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in waypointPathParent.transform) 
        {
            //insert waypoint in path.
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
            {
                path.Add(child.GetComponent<Waypoint>());
            }
            
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
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

        
        EnemyDamange();
    }

    private void EnemyDamange()
    {
        gameObject.SetActive(false);
        enemy.GoldStolen();
        Debug.Log($"You just lost a live! you have {lives} lives left!");
    }
}
