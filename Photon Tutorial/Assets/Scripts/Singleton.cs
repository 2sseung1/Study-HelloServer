using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class Singleton<T> : MonoBehaviourPunCallbacks where T : MonoBehaviourPunCallbacks
{
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }

    private static T _instance;

    protected void Awake()
    {
        if (_instance != null)
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }

            return;
        }

        _instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    protected abstract void Initialize();
}