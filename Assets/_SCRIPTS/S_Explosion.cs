using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Explosion : MonoBehaviour
{
    float tiempo, duracion,MaxEscala;
    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        transform.localScale = Vector3.one * (tiempo/ duracion)*MaxEscala;
        //de tama�o cero hasta el tama�o maximo segun la duracion
    }
}
