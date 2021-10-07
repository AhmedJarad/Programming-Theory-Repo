using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject[] colorsObjects;
   public float a;
 //   private int RandomRate=3 ;
    private void Awake()
    {
      Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        a = 3;
        InvokeRepeating("RandomInsObjects",5, RandomIntBetweenInc(2f,2.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");

        }
        
    }
    void RandomInsObjects()
    {
        if (RandomIntBetweenInc(1, 4) == 1)
        {
            Instantiate(colorsObjects[RandomIntBetweenInc(0, 3)]);

        }
        if (RandomIntBetweenInc(1, 4) == 2)
        {
            Instantiate(colorsObjects[RandomIntBetweenInc(0, 3)]);
        }
        if (RandomIntBetweenInc(1, 4) == 3)
        {
            Instantiate(colorsObjects[RandomIntBetweenInc(0, 3)]);
        }
        if (RandomIntBetweenInc(1, 4) == 4)
        {
            Instantiate(colorsObjects[RandomIntBetweenInc(0, 3)]);
        }
    }
  public int RandomIntBetweenInc(int number1,int number2)
    {// POLYMORPHISM
        return Random.Range(number1, number2+1);
     
    }
    public float RandomIntBetweenInc(float number1, float number2)
    {// POLYMORPHISM
        return Random.Range(number1, number2);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("Box"))
            {
                 
                a -= Time.deltaTime;
                if (a < 0.1)
                {
                    Destroy(other.gameObject);
                    a = 3;
                }
               

            }

        
        }
    }
  public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void Exit()
    {
        Application.Quit();
    }
    private void OnTriggerExit(Collider other)
    {
        a = 3;
    }
}
