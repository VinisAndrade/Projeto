using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    private bool estaDentro;
    public int expInimigo;
    private int expSobra;

    void OnTriggerEnter(){
        estaDentro = true;
    }
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown("e") && estaDentro == true){
            if(player.experiencia + expInimigo < player.xpNecessario){
                player.experiencia = player.experiencia + expInimigo;
                Destroy(gameObject);
            }else if(player.experiencia + expInimigo >= player.xpNecessario){
                expSobra = (player.experiencia + expInimigo) - player.xpNecessario;
                player.nivel = player.nivel+1;
                player.experiencia = expSobra;
                Destroy(gameObject);
            }
        }
    }
}
