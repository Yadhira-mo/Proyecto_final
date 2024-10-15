using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FruitCollected : MonoBehaviour
{
    public AudioSource clip;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //desactivo fruta
            GetComponent<SpriteRenderer>().enabled = false;
            //activa animacion de desaparecer
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

           
            // destruccion de objeto
            Destroy(gameObject, 0.5f);

            clip.Play();
        }
    }




}
