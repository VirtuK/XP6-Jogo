using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    private PerfectBuildMinigame pbm;


    private void Start()
    {
        pbm = FindAnyObjectByType<PerfectBuildMinigame>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {for (int i = 0; i < pbm.previousIngredient.Count; i++)
        {
            if (collision.gameObject.name == pbm.previousIngredient[i].name)
            {
                pbm.points++;
                pbm.previousIngredient.Add(this.gameObject);
                Destroy(this.GetComponent<Ingredients>());
            }
        }
    }
}
