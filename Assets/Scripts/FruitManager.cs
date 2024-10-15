using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public GameObject transition;

    //referencias al texto de frutas recogidas
    public Text totalFruits;
    public Text fruitsCollected;

    //referencia al numero total de frutas
    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }
    
    
    private void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
    }
    
    
    
    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            //Debug.Log("No quedan frutas, Victoria");
            levelCleared.gameObject.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
        }

    }

    void ChangeScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



}
