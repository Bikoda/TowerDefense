using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Transform ballista;

    Turret turret;

    public bool IsPlaceable { get { return isPlaceable; }}
    void Start()
    {
        turret = FindAnyObjectByType<Turret>();
    }

    void Update()
    {
        
    }
    void OnMouseDown()
    {
        PlaceTurret();
        Debug.Log("you've placed a turret");
    }

    void PlaceTurret()
    {
        if (isPlaceable)
        {
            
            Instantiate(ballista, transform.position, Quaternion.identity);
            turret.GoldPayment();
            isPlaceable = false;
            
        }
    }


}
