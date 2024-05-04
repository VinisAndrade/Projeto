using UnityEngine;
using UnityEngine.SceneManagement;

public class controlaAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider colisao){
        if(colisao.CompareTag("Vasco")){
            GetComponent<AudioSource>().Stop(); //Iniciar o componente audioSoucer
            GetComponent<Renderer>().enabled = false; // faz com que o objeto desapareça, no caso, ficará invisivel
            GetComponent<SphereCollider>().enabled = false; // desativa a colisão, pois não poderá colidir novamente após tocar no objeto
            Destroy(gameObject,5); // Destrói o objeto após 5 segundos
            
            //SceneManager.LoadScene("Cena2"); //Chamada da cena
            
        }
    }

}
