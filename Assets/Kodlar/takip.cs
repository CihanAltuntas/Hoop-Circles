using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class takip : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if(player.position.y > transform.position.y){
        transform.position = new Vector3(transform.position.x,player.position.y, transform.position.z);
        }
    }
}
