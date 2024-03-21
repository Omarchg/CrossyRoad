using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCreator : MonoBehaviour
{
    public List<GameObject> Terreno1;
    public List<GameObject> Terreno2;
    public List<GameObject> Terreno3;
    float terrenoMedio = 0f;
    TriggerEnter triggerEnter;
    public GameObject piso;
    bool haybloque = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Terreno1[Random.Range(0,Terreno1.Count)], piso.transform);
    }

    public void CrearTerreno()
    {
        if (terrenoMedio < 6f)
        {
            GameObject TerrenoCreado = Instantiate(Terreno2[Random.Range(0, Terreno2.Count)]);
            TerrenoCreado.transform.parent = piso.transform;
            terrenoMedio++;
        }
        else
        {
            if (haybloque == false)
            {
                GameObject TerrenoCreado2 = Instantiate(Terreno3[Random.Range(0, Terreno3.Count)]);
                TerrenoCreado2.transform.parent = piso.transform;
            }
            
            
        }
        
        
        
    }

    public void OnTriggerStay(Collider other)
    {
        haybloque = true;
    }

    public void OnTriggerExit(Collider other)
    {
        haybloque = false;
    }
}
