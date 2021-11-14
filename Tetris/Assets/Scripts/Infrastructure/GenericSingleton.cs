using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError(typeof(T).ToString() + " is NULL.");
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
            Debug.LogError(typeof(T).ToString() + " aready have one on" + _instance.gameObject.name);

        _instance = this as T;
        Init();
    }

    /// <summary>
    /// Need to initialize in awake, please reload Init
    /// </summary>
    public virtual void Init() { }
}
