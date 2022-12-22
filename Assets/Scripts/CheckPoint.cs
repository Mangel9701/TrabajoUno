using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        S_PlayerMove player = other.gameObject.GetComponent<S_PlayerMove>();
        if (other.gameObject.name == "Jugador")
        {
            GameManager.instance.Save(this.transform.position);
        }
    }
}
