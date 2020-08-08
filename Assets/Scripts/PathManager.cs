using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    private static List<PathScript> paths;

    public static void AddPath(PathScript path)
    {
        paths.Add(path);
    }

    public static PathScript GetRandomPath()
    {
        var Random = new Random();
        return paths[Random.Range(0,paths.Count)];
    }
 
}
