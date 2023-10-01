using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text text;
    public float m_timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timer = m_timer + Time.deltaTime;
        m_timer = Mathf.Round(m_timer * 100.0f) * 0.01f;
        text.text = m_timer.ToString("0.00") + "s";
    }
}
