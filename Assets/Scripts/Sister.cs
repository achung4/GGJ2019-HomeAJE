using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sister
{

    private string name;
    private Vector3 hidingLocation;

    Sister( string name, Vector3 hidingLocation )
    {
        this.name = name;
        this.hidingLocation = hidingLocation;
    }

    public string getName()
    {
        return this.name;
    }

    public Vector3 getHidingLocation()
    {
        return this.hidingLocation;
    }
}