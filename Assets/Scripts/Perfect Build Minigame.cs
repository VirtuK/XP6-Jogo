using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectBuildMinigame : MonoBehaviour
{
    [SerializeField] private List<GameObject> ingredients;
    [SerializeField] private Transform spawnPoint;

    private Transform currentIngredient = null;
    private Rigidbody2D currentRigidBody;

    private Vector2 spawnPosition = new Vector2(0, 4);

    private float speed = 4;
    private float speedIncrease = 0.5f;
    private int direction = 1;
    private float Limit = 5;
    [SerializeField] private int count;




    // Start is called before the first frame update
    void Start()
    {
        spawnNewIngredient();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentIngredient) 
        {
            float movement = Time.deltaTime * speed * direction;
            currentIngredient.position += new Vector3(movement, 0, 0);
            if(Mathf.Abs(currentIngredient.position.x) > Limit)
            {
                currentIngredient.position = new Vector3(direction * Limit, currentIngredient.position.y, 0);
                direction = -direction;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentIngredient = null;
            currentRigidBody.simulated = true;
            count++;
            spawnNewIngredient();
        }
        if(count >= ingredients.Count)
        {
            count = 0;
            speed = 4;
        }
    }


    void spawnNewIngredient()
    {
        currentIngredient = Instantiate(ingredients[count].transform, spawnPoint);
        currentIngredient.transform.position = spawnPosition;
        currentRigidBody = currentIngredient.GetComponent<Rigidbody2D>();
        speed += speedIncrease;

    }
}
