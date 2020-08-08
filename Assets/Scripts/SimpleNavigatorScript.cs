using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class SimpleNavigatorScript : MonoBehaviour
{
    public Queue<Transform> path;

    public Transform ghostTransform;
    private Transform destination;
    private Transform previousDestination;

    private float calculatedSpeed;
    private const float EXPECTEDSPEED = 5f;
    private float currentSpeed;

    //delegate used to notify actors when the boat is no longer active
    public delegate void BoatInactive(Transform transform, SimpleNavigatorScript navigatorScript);
    public event BoatInactive onBoatDisabled;

    private void OnEnable()
    {
        path = PathManager.GetRandomPath().nodes;
        transform.position = path.Dequeue().position;
        currentSpeed = EXPECTEDSPEED;

        LightHouseManager.RegisterBoatWithLightHouses(transform, this);

        CalculateNextCourse();
    }

    private void OnDisable()
    {
        onBoatDisabled(transform, this);
    }

    public void CalculateNextCourse()
    {
        previousDestination = destination;
        destination = path.Dequeue();
        ghostTransform.LookAt(destination);
        transform.rotation = ghostTransform.rotation;
        
        
    }

    public void AustCourse()
    {

    }



}
