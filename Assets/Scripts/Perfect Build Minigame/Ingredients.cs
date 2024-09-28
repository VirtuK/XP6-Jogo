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
    {
      if (collision.gameObject.name == pbm.previousIngredient[pbm.previousIngredient.Count - 1].name)
      {
          pbm.points++;
          pbm.previousIngredient.Add(this.gameObject);
          Destroy(this.GetComponent<Ingredients>());
      }
        
    }
}
