using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Moneda : MonoBehaviour
{
    private float VelocidadRotacion = 360;

    private void Update()
    {
        transform.Rotate(new Vector3(0,VelocidadRotacion*Time.deltaTime));
    }
}
