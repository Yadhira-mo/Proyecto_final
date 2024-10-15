using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    public float speed = 2;

    //destrucción de la bala despues de cierto tiempo
    public float lifeTime = 2;

    //con el bool cambia la dirección de la bala depende de la posición del Enemy
    public bool left;


    private void Start()
    {
        // Se pone Destroy en START es para cuando la bala se lance pasa un cierto tiempo y se destruya
        Destroy(gameObject,lifeTime);
    }

    private void Update()
    {
        //condición de posición
        if (left)
        {
            // la bala cogera un vector left(-1) y se multiplicara por la velocidad y los fps
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
    }

}
