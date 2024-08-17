using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] Color deFaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
        CoordinatesNaming();
        label.enabled = false;
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            CoordinatesNaming();
            label.enabled = true;
        }
        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("You just disabled the labels");
            label.enabled = !label.IsActive();
        }
    }


    void SetLabelColor()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = deFaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void CoordinatesNaming()
    {
        transform.parent.name = coordinates.ToString();
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"{coordinates.x} , {coordinates.y}";
    }
}
