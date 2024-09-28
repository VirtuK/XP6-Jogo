using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;
    [SerializeField] private TMP_Text scoreMessage;

    private void Awake()
    {
       if(BakeryManager.instance.lastTask != null)
        {
            setTask(BakeryManager.instance.lastTask);
        }
    }
    public void setTask(string txt)
    {
        this.txt.text = "- " + txt;
        BakeryManager.instance.lastTask = txt;
    }

    public void endTask()
    {
        BakeryManager.instance.lastTask = null;
        BakeryManager.instance.tasks = false;
        scoreMessage.gameObject.SetActive(true);
        scoreMessage.text = "Parabéns você completou esse pedido com " + BakeryManager.instance.score
            + " Pontos.";
        StartCoroutine(closeMessage());
        setTask("");
    }

    IEnumerator closeMessage()
    {
        yield return new WaitForSeconds(2);
        scoreMessage.gameObject.SetActive(false);
    }
}
