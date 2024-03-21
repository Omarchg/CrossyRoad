using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    public bool estando = false;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        estando = true;
    }

    private void OnTriggerExit(Collider other)
    {
        estando=false;
    }
}
