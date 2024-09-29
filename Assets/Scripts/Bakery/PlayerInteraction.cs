using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;
    private GameObject previousHit;
    [SerializeField] private GameObject txt;
    
    public bool taskMark = false;
    public Tasks tasks;

    void Update()
    {
        Vector3 player = new Vector3(this.transform.position.x, this.transform.position.y + 1.5f, this.transform.position.z - .5f);
        Ray ray = new Ray(player, cam.transform.forward * 2);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance))
        {
            if(hit.collider.GetComponent<Interact>() != null)
            {
                if (previousHit != null)
                {
                    previousHit.GetComponent<Renderer>().material = previousHit.GetComponent<Interact>().normal;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<Interact>().OnInteract();
                    
                }
                if (hit.collider.name != "NPC")
                {
                    hit.collider.GetComponent<Renderer>().material = hit.collider.GetComponent<Interact>().highlight;
                }
                previousHit = hit.collider.gameObject;
                txt.SetActive(true);
            }
            else
            {
                if (previousHit != null && previousHit.name != "NPC")
                {
                    previousHit.GetComponent<Renderer>().material = previousHit.GetComponent<Interact>().normal;
                }
                txt.SetActive(false);
            }

        }
        else
        {
            if (previousHit != null && previousHit.name != "NPC")
            {
                previousHit.GetComponent<Renderer>().material = previousHit.GetComponent<Interact>().normal;
            }
            txt.SetActive(false);
        }
    }
}
