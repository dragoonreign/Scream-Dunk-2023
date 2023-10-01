using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float zombieSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate((GameManager.instance.GetComponent<GameManager>().player.transform.position - transform.position).normalized * zombieSpeed * Time.deltaTime);
    }
}
