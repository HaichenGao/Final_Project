using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using UnityEngine.UI;
using TMPro;


public class LoadScene : MonoBehaviour
{
    static LoadScene ThisIsTheOnlyLoadScene;

    public int[] scenarios; 
    private static readonly Random rng = new Random();
    static bool shuffled = false;
    static int k = 0;
    static int j = 100;

    public Vector3 height;

    public float loadingTime = 30f;
    public TextMeshProUGUI loadingText;

    void Start()
    {


        Debug.Log(shuffled);
        //List<int> sceneSequence = new List<int>{2,3,4,5};
        if(!shuffled){
            Shuffle(scenarios);
            shuffled = true;
        }


        if(ThisIsTheOnlyLoadScene != null){
            Destroy(this.gameObject);
            return;
        }

        ThisIsTheOnlyLoadScene = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        // for(int j = 0; j < scenarios.Length; j++)
        // {
        //     Debug.Log (scenarios[j]);
        // }


    }

    void Update()
    {
        if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStart && k != 0)
        {
            GameObject.Find("Questionnaire").GetComponent<Button>().interactable = true;
        }
        switch(k-1)
        {
            case -1:
                GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().enabled = true;
                GameObject.Find("FirstTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("SecondTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ThirdTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ForthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FifthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("TrialReminder").GetComponent<TextMeshProUGUI>().enabled = false;
                if(GameObject.Find("Canvas").GetComponent<CountdownTimer>().trackingStart)
                {
                    GameObject.Find("Next").GetComponent<Button>().interactable = true;
                }
                break;
            case 0:
                GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FirstTrial").GetComponent<TextMeshProUGUI>().enabled = true;
                GameObject.Find("SecondTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ThirdTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ForthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FifthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("TrialReminder").GetComponent<TextMeshProUGUI>().enabled = true;
                break;
            case 1:
                GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FirstTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("SecondTrial").GetComponent<TextMeshProUGUI>().enabled = true;
                GameObject.Find("ThirdTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ForthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FifthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("TrialReminder").GetComponent<TextMeshProUGUI>().enabled = true;
                break;
            case 2:
                GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FirstTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("SecondTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ThirdTrial").GetComponent<TextMeshProUGUI>().enabled = true;
                GameObject.Find("ForthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FifthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("TrialReminder").GetComponent<TextMeshProUGUI>().enabled = true;
                break;
            case 3:
                GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FirstTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("SecondTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ThirdTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ForthTrial").GetComponent<TextMeshProUGUI>().enabled = true;
                GameObject.Find("FifthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("TrialReminder").GetComponent<TextMeshProUGUI>().enabled = true;
                break;
            case 4:
                GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FirstTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("SecondTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ThirdTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("ForthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("FifthTrial").GetComponent<TextMeshProUGUI>().enabled = true;
                GameObject.Find("TrialReminder").GetComponent<TextMeshProUGUI>().enabled = true;
                break;
            // case 5:
            //     GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().enabled = false;
            //     GameObject.Find("FirstTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            //     GameObject.Find("SecondTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            //     GameObject.Find("ThirdTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            //     GameObject.Find("ForthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            //     GameObject.Find("FifthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            //     GameObject.Find("TrialReminder").GetComponent<TextMeshProUGUI>().enabled = false;

            //     break;
        }

        if(k == 6)
        {
            GameObject.Find("Welcome").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("FirstTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("SecondTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("ThirdTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("ForthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("FifthTrial").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("TrialReminder").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("Uploading").GetComponent<TextMeshProUGUI>().enabled = true;
            loadingTime -= 1 * Time.deltaTime;
            loadingText.text = "Data are uploading to UCL server, please wait... " + loadingTime.ToString("0") + "s";
        }

        if(loadingTime <= 0)
        {
            loadingText.text = "Data have been uploaded successfully! Thank you for your participation;-)";
        }
    }

    public void SceneLoaderFirst()
    {
        SceneManager.LoadScene(scenarios[0]);
    }

    public void SceneLoaderSecond()
    {
        SceneManager.LoadScene(scenarios[1]);
    }

    public void SceneLoaderThird()
    {
        SceneManager.LoadScene(scenarios[2]);
    }

    public void SceneLoaderForth()
    {
        SceneManager.LoadScene(scenarios[3]);
    }

    public void SceneLoaderFifth()
    {
        SceneManager.LoadScene(scenarios[4]);
    }

    public void SceneLoader()
    {

        SceneManager.LoadScene(scenarios[k]);
        k += 1;
        Debug.Log(k);

        // if(k == 6)
        // {
        //     GameObject.Find("Logger").GetComponent<Logger>().UploadLogs();
        //     Debug.Log("uploaded");
        // }

    }

    public void UploadingData()
    {


        if(k == 5)
        {
            GameObject.Find("Logger").GetComponent<Logger>().UploadLogs();
            Debug.Log("uploaded");
            k += 1;
            Debug.Log(k);
        }
    }

    // public void UploadingData()
    // {
    //     Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

    // }

    public void ButtonOnClick(GameObject button)
    {
        button.GetComponent<Button>().interactable = true;
        Debug.Log(button.GetComponent<Button>().interactable); 
    }

    public void ButtonOff(GameObject button)
    {
        button.GetComponent<Button>().interactable = false;
        Debug.Log(gameObject.GetComponent<Button>().interactable); 
    }

    public void SetCanvasPosition()
    {
        Transform eyeLevel = GameObject.Find("CenterEyeAnchor").transform;
        height = eyeLevel.position;
        Debug.Log(height.ToString());
    }

    // public void SceneLoaderForth()
    // {
    //     SceneManager.LoadScene(scenarios[3]);
    // }



    
    //Fisher - Yates shuffle
    void Shuffle(int[] a)
    {
        // Loops through array
        for (int i = a.Length; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0,i);
            
            // Save the value of the current i, otherwise it'll overright when we swap the values
            int temp = a[i-1];
            
            // Swap the new and old values
            a[i-1] = a[rnd];
            a[rnd] = temp;
        }
        
        // Print
        for (int i = 0; i < a.Length; i++)
        {
            Debug.Log (a[i]);
        }
    }

}
