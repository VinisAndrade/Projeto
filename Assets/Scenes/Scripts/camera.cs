using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    public GameObject jogador;
    private Vector3 offset;

    //movimento do mouse
    public bool travaMouse = true; //opção para travar o cursor - pensando em implementações futuras
    public float mouseX = 0.0f, mouseY = 0.0f;
    public float sensibilidade = 0.5f;

    // Start is called before the first frame update
    void Start () {
        offset = transform.position - jogador.transform.position;

        if (!travaMouse) {
            return;
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update () {
        Vector3 posicao = new Vector3 (jogador.transform.position.x, 0f, jogador.transform.position.z);
        transform.position = posicao + offset;

        mouseX += Input.GetAxis ("Mouse X") * sensibilidade;
        mouseY += Input.GetAxis ("Mouse Y") * sensibilidade;
        transform.eulerAngles = new Vector3 (mouseY, mouseX, 0);
    }
}