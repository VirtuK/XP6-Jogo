using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public string message;
    public string task;
    public Material normal;
    public Material highlight;
    public GameObject txt;
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
            if (pI.task == false)
            {
                pI.tasks.setTask(task);
                pI.task = true;
            }
            else if (pI.taskMark == true && pI.task == true)
            {
                pI.tasks.endTask();
            }
        }


        if(this.name == "Oven")
        {
            if (pI.task)
            {
                StartCoroutine(load());   
            }
            else
            {
                txt.SetActive(true);
                StartCoroutine(fadeText());
            }
        }
    }

    IEnumerator load()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("PerfectBuild");
    }

    IEnumerator fadeText()
    {
        yield return new WaitForSeconds(1);
        txt.SetActive(false);
        
    }
}
