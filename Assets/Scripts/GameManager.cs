using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemySpawner;
    public List<GameObject> zombieEMP = new List<GameObject>();
    public static GameManager instance;
    public AudioSource audioSource;
    public Queue zombieQueue = new Queue();
    public Queue zombieSpecialQueue = new Queue();
    public Queue bulletQueue = new Queue();

    public GameObject GameOverText;

    public CinemachineShake cinemachineShake;

    public Cooldown zombieSpawnCD;
    public Cooldown zombieEMPSpawnCD;
    public Cooldown zombieBossSpawnCD;
    public Cooldown zombieGasSpawnCD;

    public Text defeatedText;
    public int defeatedInt;

    void Awake()
    {
        instance = this;
        zombieSpawnCD = new Cooldown();
        zombieEMPSpawnCD = new Cooldown();
        zombieBossSpawnCD = new Cooldown();
        zombieGasSpawnCD = new Cooldown();
    }

    void Start()
    {
        player = GameObject.Find("Player");
        zombieSpawnCD.CDStart(1.0f);
        zombieEMPSpawnCD.CDStart(10.0f);
        zombieBossSpawnCD.CDStart(100.0f);
        zombieGasSpawnCD.CDStart(5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.activeInHierarchy)
        {
            GameOverText.SetActive(true);
            Time.timeScale = 0f;
        } else {
            GameOverText.SetActive(false);
            Time.timeScale = 1f;
        }

        DoCooldown(zombieSpawnCD);

        if (zombieSpawnCD.CDBool())
        {
            DoSpawnZombies();
            Debug.Log("Ended");
        }

        DoCooldown(zombieEMPSpawnCD);

        if (zombieEMPSpawnCD.CDBool())
        {
            DoSpawnZombieEMP();
            Debug.Log("Ended");
        }

        DoCooldown(zombieBossSpawnCD);

        if (zombieBossSpawnCD.CDBool())
        {
            DoSpawnZombieBoss();
            Debug.Log("Ended");
        }

        DoCooldown(zombieGasSpawnCD);

        if (zombieGasSpawnCD.CDBool())
        {
            DoSpawnZombieGas();
            Debug.Log("Ended");
        }
    }

    public void DoCooldown(Cooldown cooldown)
    {
        cooldown.UpdateCooldown(cooldown);

        if (cooldown.CDStarted)
        {
            cooldown.UpdateCooldown(cooldown);
            Debug.Log("started");
        }
    }

    public void DoSpawnZombies()
    {
        zombieSpawnCD.CDEnd();
        GetSpawner().gameObject.GetComponent<ZombieSpawner>().SpawnZombie();
        zombieSpawnCD.CDStart(1.0f);
    }

    public void DoSpawnZombieEMP()
    {
        zombieEMPSpawnCD.CDEnd();
        GetSpawner().gameObject.GetComponent<ZombieSpawner>().SpawnZombieEMP();
        zombieEMPSpawnCD.CDStart(50.0f);
    }

    public void DoSpawnZombieBoss()
    {
        zombieBossSpawnCD.CDEnd();
        GetSpawner().gameObject.GetComponent<ZombieSpawner>().SpawnZombieBoss();
        zombieBossSpawnCD.CDStart(100.0f);
    }

    public void DoSpawnZombieGas()
    {
        zombieGasSpawnCD.CDEnd();
        GetSpawner().gameObject.GetComponent<ZombieSpawner>().SpawnZombieGas();
        zombieGasSpawnCD.CDStart(5.0f);
    }
    
    public void DoDefeatedEnemiesUIUpdate()
    {
        defeatedInt++;
        defeatedText.text = "x " + defeatedInt.ToString();
    }

    public Transform GetSpawner()
    {
        return enemySpawner.transform.GetChild(Random.Range(0, enemySpawner.transform.childCount));
    }
}
