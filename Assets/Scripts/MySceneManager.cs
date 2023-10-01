using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    Scene scene;
    public int currScene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        currScene = scene.buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoLoadNextLevel()
    {
        SceneManager.LoadScene(currScene + 1);
    }

    public void DoLoadThisLevel()
    {
        SceneManager.LoadScene(currScene);
    }
}
