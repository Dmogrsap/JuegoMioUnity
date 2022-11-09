using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    //Variables
    [SerializeField] float speed = 20f;
    [SerializeField] float rotation = 80f;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //Inicializar objeto tipo RidigBody
        rb = GetComponent <Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        moverPlayer();
    }

    void moverPlayer()
    {
        //El speed mueve el vector en z hacia los positivos
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        //El speed mueve el vector en z hacia los negativos
         if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        //Obtenemos giro a la izquierda
        if(Input.GetKey(KeyCode.A)){
            rotationPlayer(-rotation);
        }
        //Obtenemos giro derecha
        if(Input.GetKey(KeyCode.D)){
            rotationPlayer(rotation);
        }
    }

    void rotationPlayer(float rotationSpeed){
        //Esta funcion gira dentro del mismo eje del objeto
        rb.freezeRotation = true;
        //gira el vector y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
