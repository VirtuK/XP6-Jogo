using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerfectBuildMinigame : MonoBehaviour
{
    [SerializeField] private List<GameObject> ingredients;
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
            SceneManager.LoadScene("SampleScene");
        }


        txt.text = "Points: " + points;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                count++;
                if (count <= ingredients.Count)
                {
                    currentIngredient = null;
                    currentRigidBody.simulated = true;
                    if (count < ingredients.Count)
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
            if (count > ingredients.Count)
            {
                speed = 4;
                canPlay = false;
                currentIngredient.gameObject.SetActive(false);

            }

        }
        
        if(count >= ingredients.Count && !timer)
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
        
        currentIngredient = Instantiate(ingredients[count].transform, spawnPoint);
        currentIngredient.transform.position = spawnPosition;
        currentRigidBody = currentIngredient.GetComponent<Rigidbody2D>();
        speed += speedIncrease;
        baseObject.transform.localScale = new Vector3(baseObject.transform.localScale.x - 1.5f, 0.1f, 1);

    }
}
