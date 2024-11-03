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
    public bool finished;


    //Variaveis dos NPCs
    public Vector3 npcPosition = Vector3.zero;
    public bool entered = false;
    public GameObject npc;
    public List<GameObject> NPCingredients;

    //Contador de pedidos
    public int taskCount;

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

    public void ResetValues()
    {
        started = false;
        lastTask = null;
        tasks = false;
        score = 0;
        deliverTask = false;
        finished = false;

        npcPosition = Vector3.zero;
        entered = false;
        npc = null;
        NPCingredients.Clear();

        taskCount = 0;

        ingredients.Clear();
    }
}
