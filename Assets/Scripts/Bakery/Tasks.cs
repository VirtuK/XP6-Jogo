using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private TMP_Text scoreMessage;
    [SerializeField] private TMP_Text count;

    private void Start()
    {
       if(BakeryManager.instance.lastTask != null)
        {
            setTask(BakeryManager.instance.lastTask);
        }
    }
    public void setTask(Sprite sprite)
    {
        img.gameObject.SetActive(true);
        this.img.sprite = sprite;
        BakeryManager.instance.lastTask = sprite;

        int x = 0;
        for(int i = 0; i < BakeryManager.instance.NPCingredients.Count; i++)
        {
            if (BakeryManager.instance.NPCingredients[i].name == "Tentaculo")
            {
                x++;
            }
        }
        count.text = x + "x";
    }

    public void endTask()
    {
        BakeryManager.instance.lastTask = null;
        BakeryManager.instance.tasks = false;
        BakeryManager.instance.deliverTask = false;
        BakeryManager.instance.taskCount++;
        scoreMessage.gameObject.SetActive(true);
        scoreMessage.text = "Você completou esse pedido com " + BakeryManager.instance.score
            + " Pontos.";
        StartCoroutine(closeMessage());
        img.gameObject.SetActive(false);
    }

    IEnumerator closeMessage()
    {
        yield return new WaitForSeconds(2);
        scoreMessage.gameObject.SetActive(false);
        BakeryManager.instance.score = 0;
    }
}
