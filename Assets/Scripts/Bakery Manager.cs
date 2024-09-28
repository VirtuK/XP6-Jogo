using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static BakeryManager instance;
    public string lastTask;
    public bool tasks;
    public int score;

    private void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
