using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Transform ballista;
    public bool IsPlaceable { get { return isPlaceable; }}


    void OnMouseDown()
    {
        
        if (isPlaceable)
        {
            Instantiate(ballista, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
        
    }


}
