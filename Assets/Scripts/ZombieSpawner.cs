using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public void SpawnZombie()
    {
        GameObject zombie = ObjectPool.SharedInstance.GetPooledObject(ObjectPool.SharedInstance.zombieObjects); 
        if (zombie != null) {
            zombie.transform.position = transform.position;
            zombie.transform.rotation = transform.rotation;
            zombie.SetActive(true);
        }
    }

    public void SpawnZombieEMP()
    {
        GameObject zombie = ObjectPool.SharedInstance.GetPooledObject(ObjectPool.SharedInstance.zombieEMPObjects); 
        if (zombie != null) {
            zombie.transform.position = transform.position;
            zombie.transform.rotation = transform.rotation;
            zombie.SetActive(true);
        }
    }

    public void SpawnZombieBoss()
    {
        GameObject zombie = ObjectPool.SharedInstance.GetPooledObject(ObjectPool.SharedInstance.zombieBossObjects); 
        if (zombie != null) {
            zombie.transform.position = transform.position;
            zombie.transform.rotation = transform.rotation;
            zombie.SetActive(true);
        }
    }

    public void SpawnZombieGas()
    {
        GameObject zombie = ObjectPool.SharedInstance.GetPooledObject(ObjectPool.SharedInstance.zombieGasObjects); 
        if (zombie != null) {
            zombie.transform.position = transform.position;
            zombie.transform.rotation = transform.rotation;
            zombie.SetActive(true);
        }
    }
}
