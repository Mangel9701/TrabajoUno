using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour, IPointerClickHandler
{
    public string sceneName;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        SceneManager.LoadScene(sceneName);
    }
}
