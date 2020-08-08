using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightHouseManager
{
    private static List<LightHouseScript> lightHouses;

    public static void AddLighHouse(LightHouseScript lightHouse)
    {
        lightHouses.Add(lightHouse);
    }
    
    public static List<LightHouseScript> GetLightHouses() 
    { 
        return new List<LightHouseScript>(lightHouses);    
    }
    
    //Adds a boat to the boat dictionary of every lighthouse
    public static void RegisterBoatWithLightHouses(Transform boatTransform, SimpleNavigatorScript navigationScript)
    {
        foreach(LightHouseScript lightHouse in lightHouses)
        {
            lightHouse.addBoat(boatTransform, navigationScript);
        }
    }

}
