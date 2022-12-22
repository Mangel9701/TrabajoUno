using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager instance;
    public Transform initialPoint;
    public GameObject player;

    public void Awake() {
        if (instance != null) {
            return;
        }

        instance = this;
    }

    public void Save(Vector3 pos)
    {
        PlayerPrefs.SetFloat("xPos", pos.x);
        PlayerPrefs.SetFloat("yPos", pos.y);
        PlayerPrefs.SetFloat("zPos", pos.z);
    }

    public void Load() {

        float x = PlayerPrefs.GetFloat("xPos", initialPoint.position.x);
        float y = PlayerPrefs.GetFloat("yPos", initialPoint.position.y);
        float z = PlayerPrefs.GetFloat("zPos", initialPoint.position.z);

        player.transform.position = new Vector3(x, y, z);
    }
}
