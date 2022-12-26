using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class S_Laser : MonoBehaviour
{
    public float Vida;
    private S_PlayerMove _PlayerMove;
    // Start is called before the first frame update
    void Start()
    {
        _PlayerMove = GameObject.Find("Jugador").GetComponent<S_PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward,out hit, Mathf.Infinity);

        Debug.Log($"Colisiona con {hit.collider.gameObject.name}");

        transform.localScale = new Vector3(1, hit.distance,1);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Jugador")
        {
            _PlayerMove.TomaDano(10);
        }

        Debug.Log(other.name);
    }
}
