using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{
    public TerrainCreator creator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terreno1"))
        {
            other.gameObject.SetActive(false);
            creator.DevolverTerreno(creator.Terreno1, other.gameObject);
            

        }
        if (other.CompareTag("Terreno2"))
        {
            other.gameObject.SetActive(false);
            creator.DevolverTerreno(creator.Terreno2, other.gameObject);
            

        }
        if (other.CompareTag("Terreno3"))
        {
            other.gameObject.SetActive(false);
            creator.DevolverTerreno(creator.Terreno3, other.gameObject);
            

        }
    }





}
