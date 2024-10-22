using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.Jobs;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> npcs = new List<GameObject>();
    [SerializeField] private GameObject npc = null;
    [SerializeField] private bool start;
    [SerializeField] private bool finish;
    public GameObject spawn;
    void Start()
    {
       
        randomizeNPC();
        
    }

    public void randomizeNPC()
    {
        
        if(npc != null)
        {
            Destroy(npc);
        }
        if (!BakeryManager.instance.entered)
        {
            int r = Random.Range(0, npcs.Count);
            npc = GameObject.Instantiate(npcs[r]);
            BakeryManager.instance.npc = npcs[r];
        }
        else
        {
            npc = GameObject.Instantiate(BakeryManager.instance.npc, BakeryManager.instance.npcPosition, Quaternion.identity);
        }
        if (!BakeryManager.instance.entered)
        {
            npc.GetComponent<Animator>().SetBool("enter", true);
            BakeryManager.instance.entered = true;
        }
        npc.name = "NPC";
        start = false;
    }
}
