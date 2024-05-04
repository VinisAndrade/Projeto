using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganhaVidaeMana : MonoBehaviour
{
    public enum TIPO{
        vida,
        mana
    }
    public TIPO tipoItem;
    public float reposicaoVida;
    public float reposicaoMana;
    private GameObject jogador;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
    }

    void OnTriggerStay(Collider other){
        if(Input.GetKey("e") && other.gameObject == jogador.gameObject){
            switch(tipoItem){
                case TIPO.vida:
                    player.vidaAtual += reposicaoVida;
                    Destroy(gameObject);
                    break; 
                case TIPO.mana:
                    player.manaAtual += reposicaoMana;
                    Destroy(gameObject);
                    break; 
            }
        }
    }

    void OnTriggerEnter(){
        switch(tipoItem){
                case TIPO.vida:
                    player.vidaAtual += reposicaoVida;
                    Destroy(gameObject);
                    break; 
                case TIPO.mana:
                    player.manaAtual += reposicaoMana;
                    Destroy(gameObject);
                    break; 
            }
    }


}
