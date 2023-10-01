using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody _rb;
    public float bulletSpeed;

    public float wallCounter;
    public GameObject bulletTrail;

    

    // Start is called before the first frame update
    void Start()
    {
        _rb.AddForce(transform.forward * bulletSpeed - _rb.velocity, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) {
        if  (other.transform.gameObject.tag == "Zombie")
        {
            Debug.Log("Zombie");
            other.transform.gameObject.SetActive(false);
            GameManager.instance.DoDefeatedEnemiesUIUpdate();
        }
        if  (other.transform.gameObject.tag == "ZombieSpecial")
        {
            Debug.Log("ZombieSpecial");
            other.transform.gameObject.SetActive(false);
            GameManager.instance.DoDefeatedEnemiesUIUpdate();
        }
        if  (other.transform.gameObject.tag == "Wall")
        {
            Debug.Log("Wall");
            wallCounter++;
            GetComponent<AudioSource>().Play();
            if (wallCounter >= 3)
            {
                transform.gameObject.SetActive(false);
                bulletTrail.SetActive(false);
                wallCounter = 0;
            }
            GameManager.instance.cinemachineShake.ShakeCamera(0.5f, 0.05f);
        }
    }

    public void shootBullet()
    {
        _rb.AddForce(transform.forward * bulletSpeed - _rb.velocity, ForceMode.Impulse);
    }

    public void OnBulletEnabled()
    {
        bulletTrail.SetActive(true);
    }
}
