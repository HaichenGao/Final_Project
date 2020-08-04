using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour
{
    static LoadScene ThisIsTheOnlyLoadScene;

    public int[] scenarios; 
    private static readonly Random rng = new Random();
    static bool shuffled = false;

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

    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void ButtonOnClick(GameObject button)
    {
        button.GetComponent<Button>().interactable = false;
        Debug.Log(gameObject.GetComponent<Button>().interactable); 
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
