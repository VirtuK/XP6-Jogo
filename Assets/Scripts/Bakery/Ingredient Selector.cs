using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientSelector : MonoBehaviour
{
    [SerializeField] private GameObject txtPrefab;
    [SerializeField] private GameObject canvas;
    private float yOffset;

    private void Start()
    {
        BakeryManager.instance.ingredients.Clear();
    }
    public void SelectIngredient(GameObject ingredient)
    {
        if (BakeryManager.instance.ingredients.Count < 5)
        {
            BakeryManager.instance.ingredients.Add(ingredient);
            CreateText(ingredient.name);
        }

    }

    private void CreateText(string ingredient)
    {
      GameObject obj = Instantiate(txtPrefab);
      obj.transform.SetParent(canvas.transform, false);
      obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - yOffset, obj.transform.position.z);
      yOffset+=80;
      obj.GetComponent<TMP_Text>().text = ingredient; 
    }
}
