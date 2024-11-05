using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    private PerfectBuildMinigame pbm;
    private Camera cam;

    private void Start()
    {
        pbm = FindAnyObjectByType<PerfectBuildMinigame>();
        cam = FindAnyObjectByType<Camera>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, cam.transform.rotation, 10 * Time.deltaTime);
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
