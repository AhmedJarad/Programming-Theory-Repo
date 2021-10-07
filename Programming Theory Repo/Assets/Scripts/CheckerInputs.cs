using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckerInputs : MonoBehaviour
{
    public GameObject Light;
    private Color LightObjectRenderer;
   public Animator anim;
    public KeyCode Action;
    public bool BoxCanPass;
    private bool Invert = false;
    protected bool StartTimer ;
    public float timer;
     float ORIGIN;
    float OriginalTimer
    {// ENCAPSULATION
        get {return ORIGIN; }
        set {
     
            if (value < 0.0)
            {
                Debug.LogError("minus number not valid");
            }
            else
            {
                ORIGIN = value;
            }
            
         } }
    protected Rigidbody rb;
    public TextMeshProUGUI Score;
    public static int ScoreNum;
    private AudioSource audioSource;
    public AudioClip RightSoundClip, WrongSoundClip;
    private static string RightWrong;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        OriginalTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = $"Score:{ScoreNum}";
        Light.GetComponent<Renderer>().material.color = LightObjectRenderer;
        Inputs();
        TurnOn();
        Timer();




    }
    void Inputs()
    {

    }
    void TurnOn()
    {
        if (Invert)
        {
            if (Input.GetKey(Action))
            {
                BoxCanPass = true;
                LightObjectRenderer = Color.green;
            }
            else
            {
                BoxCanPass = false;
                LightObjectRenderer = Color.red;


            }
            #region tmp
        }
        else if (!Invert)
        {
            if (!Input.GetKey(Action))
            {
                BoxCanPass = true;
                LightObjectRenderer = Color.green;
            }
            else
            {
                BoxCanPass = false;
                LightObjectRenderer = Color.red;
            }

            #endregion
        }

    }
    void Timer()
    {
        if (StartTimer)
        {
            if (timer > 0.1f)
            {
                timer -= Time.deltaTime;

            }
            else
            {
          
          
                timer = OriginalTimer;
                StartTimer = false;
            }
        }

        if (timer < 0.2)
        {

            anim.SetTrigger("Push");
            if (rb != null)
            {
                rb.GetComponent<Rigidbody>().AddForce(Vector3.right * (rb.transform.position.x - anim.transform.Find("3").transform.position.x), ForceMode.Impulse);
            }


        }
    }
  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
 
            if (BoxCanPass)
            {
                GameObject BOX = other.gameObject;
                if (BOX.name == "Red(Clone)" || BOX.name == "Orange(Clone)")
                {
                    ScoreNum -=BOX.GetComponent<Box>().BoxValue;
                    RightWrong = "Wrong";
                    audioSource.PlayOneShot(WrongSoundClip);
                    Debug.Log("Wrong");
                }
                if (BOX.name == "Green(Clone)" || BOX.name == "Purple(Clone)")
                {
                    audioSource.PlayOneShot(RightSoundClip);
                    RightWrong = "Right";
                    Debug.Log("Right");
                    ScoreNum += BOX.GetComponent<Box>().BoxValue;
                }

            }
            else
            {
                GameObject BOX = other.gameObject;
                if (BOX.name == "Red(Clone)" || BOX.name == "Orange(Clone)")
                {
                    audioSource.PlayOneShot(RightSoundClip);
                    StartTimer = true;
                    rb = BOX.GetComponent<Rigidbody>();
                    RightWrong = "Right";
                    Debug.Log("Right");
                        ScoreNum+= BOX.GetComponent<Box>().BoxValue;
          
                }
                if (BOX.name == "Green(Clone)" || BOX.name == "Purple(Clone)")
                {
                    StartTimer = true;
                    rb = BOX.GetComponent<Rigidbody>();
                    audioSource.PlayOneShot(WrongSoundClip);
                    RightWrong = "Wrong";
                    Debug.Log("Wrong");
                     ScoreNum -= BOX.GetComponent<Box>().BoxValue;

                    
                }

            }
        }
    }
}
 


