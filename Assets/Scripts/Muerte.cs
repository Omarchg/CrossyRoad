using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject findepartida;
    public GameObject movimiento;
    public GameObject camara;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coche"))
        {
            muerte();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LimiteJugador"))
        {
            muerte();
        }
        if (other.gameObject.CompareTag("Agua"))
        {
            muerte();
        }
    }
    void muerte()
    {
        findepartida.SetActive(true);
        gameObject.SetActive(false);
        movimiento.SetActive(false);
        camara.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
    }
}
