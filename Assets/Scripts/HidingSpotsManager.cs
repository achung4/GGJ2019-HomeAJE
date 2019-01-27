using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpotsManager : MonoBehaviour
{
    public static List<Transform> hidingSpotsList;

    // Start is called before the first frame update
    void Start()
    {
        hidingSpotsList = new List<Transform>();
        foreach (Transform child in transform)
        {
            //child is your child transform
            hidingSpotsList.Add( child );

        }
    }

}
