using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public Queue<Transform> nodes = new Queue<Transform>();
    public Transform[] arraynodes;
    private void Awake()
    {
        foreach(Transform t in arraynodes)
        {
            nodes.Enqueue(t);
        }
        PathManager.AddPath(this);
    }

}
