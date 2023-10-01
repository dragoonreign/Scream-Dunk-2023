using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchZombie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Zombie")
        {
            if (transform.root.GetComponent<TopDownMovement>().bMaxBullet)
            {
                Debug.Log("Danger");
            } else {
                Debug.Log("Captured zombie");
                other.transform.gameObject.SetActive(false);
                if (transform.root.GetComponent<TopDownMovement>().bulletCount < transform.root.GetComponent<TopDownMovement>().maxBulletCount) {
                    transform.root.GetComponent<TopDownMovement>().bulletCount++;
                }
            }
        }
    }
}
