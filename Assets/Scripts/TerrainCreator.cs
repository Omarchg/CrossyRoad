using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCreator : MonoBehaviour
{
    public List<GameObject> Terreno1;
    public List<GameObject> Terreno2;
    public List<GameObject> Terreno3;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Terreno1[Random.Range(0,Terreno1.Count)], transform);
    }

    public void CrearTerreno()
    {
        GameObject TerrenoCreado = Instantiate(Terreno2[Random.Range(0, Terreno2.Count)]);
        TerrenoCreado.transform.parent = transform;
        
    }
}
