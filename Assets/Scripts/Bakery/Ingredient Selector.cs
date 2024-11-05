using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSelector : MonoBehaviour
{
    [SerializeField] private GameObject spritePrefab;
    [SerializeField] private GameObject imagePrefab;
    [SerializeField] private GameObject canvas;
    private float yOffset = 720;

    private void Start()
    {
        BakeryManager.instance.ingredients.Clear();
    }
    public void SelectIngredient(GameObject ingredient)
    {
        if (BakeryManager.instance.ingredients.Count < 5)
        {
            BakeryManager.instance.ingredients.Add(ingredient);
            CreateBox(ingredient.GetComponent<SpriteRenderer>().sprite);
        }

    }

    private void CreateBox(Sprite ingredient)
    {
        GameObject obj = Instantiate(spritePrefab);
        obj.transform.SetParent(canvas.transform, false);
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - yOffset, obj.transform.position.z);
        GameObject img = Instantiate(imagePrefab);
        img.transform.SetParent(obj.transform, false);
        img.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
        img.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        img.GetComponent<Image>().sprite = ingredient;
        yOffset -= 180;
    }
}
