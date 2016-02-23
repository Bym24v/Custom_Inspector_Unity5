using UnityEngine;
using System.Collections;
using UnityEditor;

public class mInspector : MonoBehaviour
{
    public enum Status
    {
        Waypoints,
        FreePatrol
    };

    public Status estado;

    public int slider;

    public string name;

    public GameObject obj;

    public Transform mTransform;
 }
