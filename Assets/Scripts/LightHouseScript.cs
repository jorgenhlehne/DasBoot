using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class LightHouseScript : MonoBehaviour
{
    //Dictionary for keeping trakc of active boats on the board
    Dictionary<Transform, SimpleNavigatorScript> boats = new Dictionary<Transform, SimpleNavigatorScript>();


    private void Start()
    {
        LightHouseManager.AddLighHouse(this);
    }

    //Adds a boat to the dict of active boats and listens to event for when the boat is removed from the board.
    public void addBoat(Transform boatTransform, SimpleNavigatorScript navigation)
    {
        boats.Add(boatTransform, navigation);
        navigation.onBoatDisabled += RemoveBoat;
    }

    //Removes boat from dictionary
    public void RemoveBoat(Transform transform, SimpleNavigatorScript script)
    {
        boats.Remove(transform);
    }

}
