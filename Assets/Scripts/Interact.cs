using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string message;
    public string task;
    public Material normal;
    public Material highlight;
    private PlayerInteraction pI;
    private bool used;

    private void Start()
    {
        pI = FindFirstObjectByType<PlayerInteraction>();
    }
    public void OnInteract()
    {
        if (this.name == "NPC")
        {
            if (used == false)
            {
                pI.tasks.setTask(task);
                used = true;
            }
            else if (pI.taskMark == true && used == true)
            {
                pI.tasks.endTask();
            }
        }
        if(this.name == "Oven")
        {
            pI.taskMark = true;
        }
    }
}
