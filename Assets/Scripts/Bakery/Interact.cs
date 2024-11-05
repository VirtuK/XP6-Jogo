using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public string message;
    public Sprite task;
    public GameObject txt;
    public GameObject ingredient;
    private PlayerInteraction pI;
    private NPCManager NPCManager;
    [SerializeField] List<GameObject> ingredients = new List<GameObject>();
    [SerializeField] List<GameObject> ingredients2 = new List<GameObject>();
    [SerializeField] List<GameObject> ingredients3 = new List<GameObject>();
    private List<List<GameObject>> options = new List<List<GameObject>>();

    private void Start()
    {
        pI = FindFirstObjectByType<PlayerInteraction>();
        NPCManager = FindFirstObjectByType<NPCManager>();
        options.Add(ingredients);
        options.Add(ingredients2);
        options.Add(ingredients3);
    }
    public void OnInteract(string name)
    {

        switch (name)
        {
            case "NPC":
            {
                    if (BakeryManager.instance.tasks == false)
                    {
                        
                        BakeryManager.instance.tasks = true;
                        BakeryManager.instance.npcPosition = new Vector3(-1.5f, 0f, 2.5f);
                        int r = Random.Range(0, 3);
                        BakeryManager.instance.NPCingredients = options[r];
                        pI.tasks.setTask(task);
                    }
                    else
                    {
                        pI.tasks.endTask();
                        this.GetComponent<Animator>().SetBool("idle", false);
                        this.GetComponent<Animator>().SetBool("exit", true);
                        BakeryManager.instance.entered = false;
                    }
                    break;
            }
            case "Table":
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

    public void Idle()
    {
        GetComponent<Animator>().SetBool("idle", true);
    }
}
