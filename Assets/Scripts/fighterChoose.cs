using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fighterChoose : MonoBehaviour
{


    public TextMeshProUGUI P1;
    public TextMeshProUGUI P2;
    public Canvas BaLeanCanvas;
    public GameObject PreviewBaLean;
    public Canvas MedrickCanvas;
    public GameObject PreviewMedrick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        




        //BALEAN
        if (PlayerPrefs.GetInt("Player") == 2)
        { 
            BaLeanCanvas.enabled = true;
            PreviewBaLean.SetActive(true);
        }
        else
        {
            BaLeanCanvas.enabled = false;
            PreviewBaLean.SetActive(false);
        }




        //MEDrICK
        if (PlayerPrefs.GetInt("Player") == 3)
        {
            MedrickCanvas.enabled = true;
            PreviewMedrick.SetActive(true);
        }
        else
        {
            MedrickCanvas.enabled = false;
            PreviewMedrick.SetActive(false);
        }
    }
}
