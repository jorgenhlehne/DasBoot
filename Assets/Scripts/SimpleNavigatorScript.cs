using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using System;

public class SimpleNavigatorScript : MonoBehaviour
{
    public Queue<Transform> path;

    //the ghost Transfomr reprecents where the boat belives its located
    public Transform ghostTransform;
    private Transform destination;
    private Transform previousDestination;

    private float calculatedSpeed;
    private const float EXPECTEDSPEED = 0.2f;
    private float currentSpeed;

    float timeSinceLastAjustment;
    float timeToNextCourse;
    float distanceTraveldSinceLastAjustment;
    float distanceToNextPoint;

    private Guid guid = Guid.NewGuid();

    //delegate used to notify actors when the boat is no longer active
    public delegate void BoatInactive(Transform transform, SimpleNavigatorScript navigatorScript);
    public event BoatInactive onBoatDisabled;

    private void Start()
    {
        path = new Queue<Transform>(PathManager.GetRandomPath().nodes);
        destination = path.Dequeue();
        transform.position = destination.position;
        ghostTransform.position = transform.position;
        currentSpeed = EXPECTEDSPEED;
        timeSinceLastAjustment = 1f;
        distanceTraveldSinceLastAjustment = EXPECTEDSPEED;

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
        timeSinceLastAjustment = 0;
        distanceTraveldSinceLastAjustment = 0;
        distanceToNextPoint = Vector3.Distance(ghostTransform.position, destination.position);
        timeToNextCourse = distanceToNextPoint / EXPECTEDSPEED;
    }

    public void AustCourse()
    {

    }

    private void Update()
    {
        transform.position += (transform.forward * currentSpeed * Time.deltaTime);
        ghostTransform.transform.position += (transform.forward * currentSpeed * Time.deltaTime);

        timeSinceLastAjustment += Time.deltaTime;

        if (timeSinceLastAjustment > timeToNextCourse)
        {
            CalculateNextCourse();
        } 
    }
}
