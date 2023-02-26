using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSET : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Choice1", 1);
        PlayerPrefs.SetInt("Choice2", 0);
        PlayerPrefs.SetInt("Player", 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
