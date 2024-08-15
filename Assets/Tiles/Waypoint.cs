using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Turret ballista;

    Turret turret;

    public bool IsPlaceable { get { return isPlaceable; } }
    void Start()
    {
        turret = FindAnyObjectByType<Turret>();
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
            bool isPlaced = turret.CreateTower(ballista, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
