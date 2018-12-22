using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTPS : MonoBehaviour {


    private GameObject gameobject;


    private static GameManagerTPS m_instance;
    public static GameManagerTPS instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = GameObject.Find("GameManagerTPS").GetComponent<GameManagerTPS>();
                m_instance.gameobject = m_instance.transform.gameObject;
                m_instance.gameobject.AddComponent<InputController>();
                m_instance.gameobject.AddComponent<Timer>();
                
            }
            return m_instance;
        }
        
    }

    private Timer m_timer;
    public Timer timer
    {
        get
        {
            if(m_timer == null)
            {
                m_timer = gameObject.GetComponent<Timer>();
            }
            return m_timer;
        }
    }


    private InputController m_InputController;
    public InputController inputController
    {
        get
        {
            if(m_InputController == null)
            {
                m_InputController = gameObject.GetComponent<InputController>();
            }
            return m_InputController;
        }
    }

    private Player m_LocalPlayer;
    public Player localPlayer
    {
        get
        {
            return m_LocalPlayer;
        }
    }


}
