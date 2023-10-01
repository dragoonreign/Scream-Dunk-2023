using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.gameObject.tag == "Zombie" || other.transform.gameObject.tag == "ZombieSpecial")
        {
            transform.gameObject.SetActive(false);
        }
    }
}
