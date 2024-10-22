using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerfectBuildMinigame : MonoBehaviour
{
    
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject baseObject;
    public List<GameObject> previousIngredient = new List<GameObject>();


    private Transform currentIngredient = null;
    private Rigidbody2D currentRigidBody;

    private Vector2 spawnPosition = new Vector2(0, 4);

    private float speed = 4;
    private float speedIncrease = 3f;
    private int direction = 1;
    private float Limit = 8;
    private bool canPlay;
    [SerializeField] private int count = 0;
    public int points;
    [SerializeField] private TMP_Text txt;
    private float time = 0;
    private bool timer;



    // Start is called before the first frame update
    void Start()
    {
        spawnNewIngredient();
        canPlay = true;
        for(int i = 0; i < BakeryManager.instance.NPCingredients.Count; i++)
        {
            if (BakeryManager.instance.NPCingredients[i] == BakeryManager.instance.ingredients[i])
            {
                points++;
            }
            else
            {
                points--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        if(time <= 0 && timer)
        {
            BakeryManager.instance.deliverTask = true;
            BakeryManager.instance.score = points;
            SceneManager.LoadScene("SampleScene");
        }


        txt.text = "Pontos: " + points;
        if (currentIngredient)
        {
            float movement = Time.deltaTime * speed * direction;
            currentIngredient.position += new Vector3(movement, 0, 0);
            if (Mathf.Abs(currentIngredient.position.x) > Limit)
            {
                currentIngredient.position = new Vector3(direction * Limit, currentIngredient.position.y, 0);
                direction = -direction;
            }
        }
        if (canPlay)
        {
            if (Input.GetKeyDown(KeyCode.E) && count < BakeryManager.instance.ingredients.Count)
            {
                count++;
                if (count <= BakeryManager.instance.ingredients.Count)
                {
                    currentIngredient = null;
                    currentRigidBody.simulated = true;
                    if (count < BakeryManager.instance.ingredients.Count)
                    {
                        spawnNewIngredient();
                    }
                }
                else
                {
                    speed = 4;
                    canPlay = false;
                    currentIngredient.gameObject.SetActive(false);
                }
                
            }
            if (count > BakeryManager.instance.ingredients.Count)
            {
                speed = 4;
                canPlay = false;
                currentIngredient.gameObject.SetActive(false);

            }

        }
        
        if(count >= BakeryManager.instance.ingredients.Count && !timer)
        {
            timer = true;
            time = 5;
            print("end" + time);
            
        }

        for (int i = 0; i < previousIngredient.Count; i++) {
            if (previousIngredient[i].transform.position.y < baseObject.transform.position.y)
            {
                points--;
                previousIngredient.Remove(previousIngredient[i]);
            } 
        }
    }


    void spawnNewIngredient()
    {
        
        currentIngredient = Instantiate(BakeryManager.instance.ingredients[count].transform, spawnPoint);
        currentIngredient.transform.position = spawnPosition;
        currentRigidBody = currentIngredient.GetComponent<Rigidbody2D>();
        speed += speedIncrease;
        baseObject.transform.localScale = new Vector3(baseObject.transform.localScale.x - 1.625f, 0.1f, 1);

    }
}
