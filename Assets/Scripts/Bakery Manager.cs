using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static BakeryManager instance;
    public bool started = false;
    public string lastTask = null;
    public bool tasks;
    public int score;
    public bool deliverTask;
    public List<GameObject> ingredients;

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
