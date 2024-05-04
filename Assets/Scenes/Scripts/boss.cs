using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {
    private bool estaDentro;

    void OnTriggerEnter () {
        estaDentro = true;
    }

    void OnTriggerExit () {
        estaDentro = false;
    }

    void Update () {
        if (estaDentro == true) {
            player.vidaAtual = player.vidaAtual - 0.1f;
        }
    }
}


public class DestroyBasic : MonoBehaviour

{
    void Update ()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
}