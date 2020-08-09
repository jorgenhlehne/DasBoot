using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    private static List<PathScript> paths = new List<PathScript>();

    public static void AddPath(PathScript path)
    {
        paths.Add(path);
    }

    public static PathScript GetRandomPath()
    {
        int randomint = Random.Range(0, paths.Count);
        PathScript script = paths[randomint];
        return script;
    }
 
}
