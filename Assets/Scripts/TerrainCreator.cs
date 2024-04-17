using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCreator : MonoBehaviour
{
    public List<GameObject> Terreno1_prefab;
    public List<GameObject> Terreno1;
    public List<GameObject> Terreno2_prefab;
    public List<GameObject> Terreno2;
    public List<GameObject> Terreno3_prefab;
    public List<GameObject> Terreno3;
    public List<GameObject> Activos;
    float terrenoMedio = 0f;
    
    public GameObject piso;
    bool haybloque = false;

    // Start is called before the first frame update
    void Start()
    {
        CrearTerrenoInicial(Terreno1_prefab, Terreno1);
        CrearTerrenoInicial(Terreno2_prefab, Terreno2);
        CrearTerrenoInicial(Terreno3_prefab, Terreno3);
        ActivarTerreno(Terreno1, Vector3.zero);
    }

    /*public void CrearTerreno()
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
        
        
        
    }*/
    


    public void CrearTerrenoInicial(List<GameObject> listaprefab, List<GameObject> lista)
    {
        foreach (GameObject terreno in listaprefab)
        {

            GameObject instancia = Instantiate(terreno);
            instancia.SetActive(false);
            instancia.transform.parent = piso.transform;
            lista.Add(instancia);
            
        }
    }

    public void ActivarTerreno(List<GameObject> quitardelista, Vector3 lugar)
    {
        int TerrenoRandom = UnityEngine.Random.Range(0, quitardelista.Count);
        GameObject selectedObject = quitardelista[TerrenoRandom];
        selectedObject.SetActive(true);
        selectedObject.transform.position = lugar;
        Activos.Add(selectedObject);
        quitardelista.Remove(selectedObject);

    }

    public void DevolverTerreno(List<GameObject> lista, GameObject objects)
    {
        lista.Add(objects);
        Activos.Remove(objects);
    }

    public void TerrenoInfinito()
    {
        if (terrenoMedio < 6f)
        {
            ActivarTerreno(Terreno2, new Vector3(0, 0, 18));
            terrenoMedio++;
        }
        else
        {
            if (haybloque == false)
            {
                ActivarTerreno(Terreno3, new Vector3(0,0, 18));
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
