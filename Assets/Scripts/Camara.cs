using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;
    public float minX, maxX, minY, maxY;


    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, minX, maxX),
                                         Mathf.Clamp(player.position.y, minY, maxY),
                                         -10);
    }
}
