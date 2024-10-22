using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static BakeryManager instance;

    //Variaveis envolvendo os minigames
    public bool started = false;
    public string lastTask = null;
    public bool tasks;
    public int score;
    public bool deliverTask;


    //Variaveis dos NPCs
    public Vector3 npcPosition = Vector3.zero;
    public bool entered = false;
    public GameObject npc;

    //Ingredientes que foram salvos
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
