    using UnityEngine;
using UnityEngine.UI;

public class SimplePlayer : MonoBehaviour
{
    //Personagem
    private Rigidbody rb;
    public float velocidade = 5;
    public float maxAltura = 3; 
    

 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    // Excutado APENAS quando elmentos físico são  alterados
    void FixedUpdate(){
        float h = Input.GetAxis("Horizontal"); //capturar seta do teclado (↑ e ↓)
        float v = Input.GetAxis("Vertical"); //capturar seta do teclado (→ e ←) 
        float pulo = 0;

        if((Input.GetKey(KeyCode.Space) && (rb.position.y < maxAltura))){
            pulo = 3.5f;
            
        }

        Vector3 forca = new Vector3(h, pulo, v); // Vector3 - Vetor de movimento 3D (x,y,z)
        rb.AddForce(forca * velocidade);       
    }


    void Morreu(){
        Debug.Log("Morreu");
    }

}