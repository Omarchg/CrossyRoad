using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Coches : MonoBehaviour
{
    public float velocidad;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, velocidad * Time.deltaTime);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LimiteCocheIzquierda"))
        {
            transform.Translate(0, 0, -65);
        }
        if (other.CompareTag("LimiteCocheDerecha"))
        {
            transform.Translate(0, 0, -65);
        }

    }

}