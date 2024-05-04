using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
    //Personagem
    private Rigidbody rb;
    private float velocidade = 10;
    private float maxAltura = 3;

    //Sistema de XP
    public static int experiencia;
    public static int nivel;
    public int aumentoPorNivel;
    public int expInicial;
    public static int xpNecessario;
    public Font Fonte;

    //Sistema de Vida
    public Image barraVida;
    [Range (20, 500)]
    public float vidaCheia = 100;
    public static float vidaAtual;

    //Sistema de Mana
    public Image barraMana;
    [Range (20, 500)]
    public float manaCheia = 100;
    public static float manaAtual;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        vidaAtual = vidaCheia;
        nivel = 0;
    }

    // Update is called once per frame
    void Update () {
        xpNecessario = expInicial + aumentoPorNivel * nivel;
        if (experiencia >= xpNecessario) {
            nivel = nivel + 1;
            experiencia = 0;
        }
        aplicarBarras ();
        sistemVida ();

    }

    // Excutado APENAS quando elmentos físico são  alterados
    void FixedUpdate () {
        //movimentoPersonagem ();

        //Outra forma de movimentar
        float h = Input.GetAxis ("Horizontal"); //capturar seta do teclado (↑ e ↓)
        float v = Input.GetAxis ("Vertical"); //capturar seta do teclado (→ e ←) 
        float pulo = 0;

        if ((Input.GetKey (KeyCode.Space) && (rb.position.y < maxAltura))) {
            pulo = 3.5f;
        }
        Vector3 forca = new Vector3 (h, pulo, v); // Vector3 - Vetor de movimento 3D (x,y,z)
        if (Input.GetKey ("w") || Input.GetKey ("s") || Input.GetKey ("a") || Input.GetKey ("d") || ((Input.GetKey (KeyCode.Space) && (rb.position.y < maxAltura)))) {
            rb.AddForce (forca * velocidade);
        } else {
            rb.velocity = Vector3.zero; //zera força exercida no objeto

        }
    }

    void aplicarBarras () {

        barraVida.fillAmount = ((1 / vidaCheia) * vidaAtual);
        barraMana.fillAmount = ((1 / manaCheia) * manaAtual);
    }

    void sistemVida () {
        if (vidaAtual >= vidaCheia) {
            vidaAtual = vidaCheia;
        } else if (vidaAtual <= 0) {
            vidaAtual = 0;
            Morreu ();
        }
    }

    void sistemMana () {
        if (manaAtual >= manaCheia) {
            manaAtual = vidaCheia;
        } else if (manaAtual <= 0) {
            manaAtual = 0;
        }
    }

    void Morreu () {
        Debug.Log ("Morreu");
    }

    void OnGUI () {
        GUI.skin.font = Fonte;
        GUI.skin.label.fontSize = Screen.height / 30;

        GUI.Label (new Rect (Screen.width / 2 - Screen.width / 2.1f, Screen.height / 2 - Screen.height / 2.1f, Screen.width / 1.5f, Screen.height / 4), "Nivel: " + nivel);
        GUI.Label (new Rect (Screen.width / 2 - Screen.width / 2.1f, Screen.height / 2 - Screen.height / 2.5f, Screen.width / 1.5f, Screen.height / 4), "EXP: " + experiencia);
        GUI.Label (new Rect (Screen.width / 2 - Screen.width / 2.1f, Screen.height / 2 - Screen.height / 3f, Screen.width / 1.5f, Screen.height / 4), "P/ Proximo Nivel: " + (xpNecessario - experiencia) + " XP");
    }

    void Andar2 () {
        float andar = 1, correr = 2;

        if (Input.GetKey ("w")) {
            if (velocidade == 1) {
                transform.Translate (0, 0, andar * velocidade * Time.deltaTime);
                //GetComponent<Animation> ().Play ("Andar");
            } else if (velocidade == 2) {
                transform.Translate (0, 0, correr * velocidade * Time.deltaTime);
                //GetComponent<Animation> ().Play ("Correr");
            }
        }
        if (Input.GetKey (KeyCode.LeftShift)) {
            velocidade = 2;
        } else {
            velocidade = 1;
        }
    }

    void movimentoPersonagem () {
        float pulo = 0;
        if ((Input.GetKey (KeyCode.Space) && (rb.position.y < maxAltura))) {
            pulo = 3.5f;

        }
        Vector3 posicao = new Vector3 (Input.GetAxisRaw ("Horizontal"), pulo, Input.GetAxis ("Vertical"));
        rb.velocity = posicao * velocidade;
    }
}