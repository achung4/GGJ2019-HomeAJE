using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistersManager : MonoBehaviour
{
    public static SistersManager instance = null;
    public List<Sister> sisterList;


    private void Start()
    {
        sisterList = new List<Sister>();
    }
}
