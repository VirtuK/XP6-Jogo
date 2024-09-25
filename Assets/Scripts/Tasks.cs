using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;

    public void setTask(string txt)
    {
        this.txt.text = "- " + txt;
    }

    public void endTask()
    {
        txt.text = "<s>" + txt.text + "</s>";
    }
}
