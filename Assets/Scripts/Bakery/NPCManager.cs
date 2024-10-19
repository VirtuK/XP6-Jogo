using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> npcs = new List<GameObject>();
    [SerializeField] private GameObject npc = null;
    [SerializeField] private bool start;
    [SerializeField] private bool finish;
    [SerializeField] private GameObject spawn;
    void Start()
    {
        randomizeNPC();
    }

    void Update()
    {
        
    }

    public void randomizeNPC()
    {
        int r = Random.Range(0, npcs.Count);
        if(npc != null)
        {
            Destroy(npc);
        }
        npc = GameObject.Instantiate(npcs[r], spawn.transform);
        start = false;
    }
}
