using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    //intervalo de tiempo de la bala
    private float waitedTime;

    //tiempo que se van a lanzar las balas
    public float waitTimeToAttack = 3;

    // activar animación de ataque
    public Animator animator;

    //referencia del bullet prefab
    public GameObject bulletPrefab;

    //posición de lanzamiento de la bala
    public Transform launchSpawnPoint;


    private void Start()
    {
        //tiempo que va transcurrir hasta que ataquemos
        waitedTime = waitTimeToAttack;
    }

    private void Update()
    {
        // si el waitedTime es menor igual a 0 nuestro Enemy va a atacar
        if (waitedTime<=0)
        {
            waitedTime = waitTimeToAttack;
            // activar animación de ataque
            animator.Play("Attack");
            //invocar el lanzamiento de la bala
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            // resta segundos al waitedTime y se crea un ciclo para cuando pase el tiempo ataque de nuevo
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        //referencia a la bala
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }




}
