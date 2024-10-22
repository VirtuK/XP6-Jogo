using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject ingredient;
    private PlayerInteraction pI;
    private bool used;
    private NPCManager NPCManager;

    private void Start()
    {
        pI = FindFirstObjectByType<PlayerInteraction>();
        NPCManager = FindFirstObjectByType<NPCManager>();
    }
    public void OnInteract(string name)
    {

        switch (name)
        {
            case "NPC":
            {
                    if (BakeryManager.instance.tasks == false)
                    {
                        pI.tasks.setTask(task);
                        BakeryManager.instance.tasks = true;
                        BakeryManager.instance.npcPosition = new Vector3(-1.5f, 1.13f, 2.5f);
                    }
                    else
                    {
                        pI.tasks.endTask();
                        this.GetComponent<Animator>().SetBool("exit", true);
                        BakeryManager.instance.entered = false;
                    }
                    break;
            }
            case "Oven":
                {
                    if (BakeryManager.instance.deliverTask)
                    {
                        Message("O pedido já está pronto, entregue-o");
                    }
                    else if (BakeryManager.instance.tasks && BakeryManager.instance.ingredients.Count > 0)
                    {
                        StartCoroutine(load());
                    }
                    else if (BakeryManager.instance.tasks && BakeryManager.instance.ingredients.Count <= 0)
                    {
                        Message("Nenhum ingrediente foi selecionado");
                    }
                    else
                    {
                        Message("Nenhum pedido deve ser realizado no momento");
                    }
                    break;
                }
            case "Ingredient":
                {
                    if (BakeryManager.instance.ingredients.Count < 5)
                    {
                        IngredientSelector selector = FindAnyObjectByType<IngredientSelector>();
                        selector.SelectIngredient(ingredient);
                    }
                    else
                    {
                        Message("5 Ingredientes já foram selecionados");
                    }
                    break;
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

    void Message(string msg)
    {
        txt.GetComponent<TMP_Text>().text = msg;
        txt.SetActive(true);
        StartCoroutine(fadeText());
    }

    public void FinishAnimation()
    {
        NPCManager.randomizeNPC();
    }
}
