using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    void OnEnable()
    {
        // gameManager = GameObject.Find("GameManager");
        if (!transform.gameObject.name.Contains("EMP")) return;
        GameManager.instance.GetComponent<GameManager>().player.transform.GetChild(1).gameObject.SetActive(true);
        GameManager.instance.GetComponent<GameManager>().zombieEMP.Add(transform.gameObject);
    }

    void OnDisable()
    {
        if (!transform.gameObject.name.Contains("EMP")) return;
        if (GameManager.instance == null) return;
        GameManager.instance.GetComponent<GameManager>().zombieEMP.RemoveAt(GameManager.instance.GetComponent<GameManager>().zombieEMP.Count - 1);
        if (GameManager.instance.GetComponent<GameManager>().zombieEMP.Count > 0) return;
        
        GameManager.instance.GetComponent<GameManager>().player.transform.GetChild(1).gameObject.SetActive(false);
    }
}
