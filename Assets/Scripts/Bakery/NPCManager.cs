using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> npcs = new List<GameObject>();
    [SerializeField] private GameObject npc = null;
    [SerializeField] private bool start;
    [SerializeField] private bool finish;
    [SerializeField] private Tasks taskManager;
    public GameObject spawn;
    void Start()
    {
        taskManager = FindAnyObjectByType<Tasks>();
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
            npc = GameObject.Instantiate(BakeryManager.instance.npc, BakeryManager.instance.npcPosition, new Quaternion(0,180,0,1));
            npc.GetComponent<Animator>().SetBool("idle", true);
            
        }
        if (!BakeryManager.instance.entered)
        {
            npc.GetComponent<Animator>().SetBool("enter", true);
            BakeryManager.instance.entered = true;
        }
        npc.name = "NPC";
        start = false;
        setUI();
    }

    public void setUI()
    {
        taskManager.taskBallon = GameObject.FindWithTag("taskBallon");
        taskManager.taskImage = GameObject.FindWithTag("taskImage");
        taskManager.count = GameObject.FindWithTag("taskCount").GetComponent<TMP_Text>();
        taskManager.img = taskManager.taskImage.GetComponent<SpriteRenderer>();
        taskManager.taskBallon.SetActive(false);
    }
}
