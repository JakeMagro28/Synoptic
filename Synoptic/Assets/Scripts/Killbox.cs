using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D football)
    {
        print("Collision with " + football.name);
        Destroy(football.gameObject);

    }


    


}
