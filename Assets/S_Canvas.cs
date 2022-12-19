using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Canvas : MonoBehaviour
{
    public GameObject FondoNegro;
    public Image Fondo;
    // Start is called before the first frame update
    void Start()
    {
        FondoNegro.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        //FondoNegro.color =new Color(0,0,0,0);
        
    
    void OnApplicationQuit()
    {
        Fondo.color = new Color(0,0,0,0);
        Debug.Log("Application ending after " + Time.time + " seconds");
        FondoNegro.SetActive(false);
    }
}
