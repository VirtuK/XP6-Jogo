using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private GameObject txt;
    
    public bool taskMark = false;
    public Tasks tasks;

    void Update()
    {
        Vector3 player = new Vector3(this.transform.position.x, this.transform.position.y + 1.1f, this.transform.position.z - .5f);
        Ray ray = new Ray(player, cam.transform.forward * 4);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance))
        {
            if(hit.collider.GetComponent<Interact>() != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.tag != "Ingredient")
                    {
                        hit.collider.GetComponent<Interact>().OnInteract(hit.collider.gameObject.name);
                    }
                    else
                    {
                        hit.collider.GetComponent<Interact>().OnInteract(hit.collider.gameObject.tag);
                    }
                    
                }
                txt.SetActive(true);
            }
            else
            {
                txt.SetActive(false);
            }

        }
        else
        {
            txt.SetActive(false);
        }
    }
}
