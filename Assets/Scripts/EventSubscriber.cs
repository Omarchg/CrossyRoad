using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class EventSubscriber : MonoBehaviour
{
    public SwipeController SwipeCon;
    public GameObject cube;
    public GameObject map;
    public TerrainCreator TerrainCreator;
    public float TimeAnim = 0.5f;
    public float distancia = 2f;
    bool OnAnim = false;
    float pasos = 0f;
    float pasosAtras = 0f;
    float record;
    [SerializeField]
    TextMeshProUGUI Record;
    public void Start()
    {
        
        //suscribirse al evento
        SwipeController.Instance.OnSwipe += MoveTarget;
    }

    public void OnDisabled()
    {
        SwipeController.Instance.OnSwipe -= MoveTarget;
    }

    private void Update()
    {
        float current = pasos - pasosAtras;
        if (current > record)
        {
            record = current;
            Record.text = record.ToString("00");
        }

    }

    public void MoveTarget(Vector3 direction)
    {
        if (OnAnim == false)
        {
            OnAnim = true;
            direction.x = Mathf.Round(direction.x);
            direction.z = Mathf.Round(direction.z);

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
            {
                LeanTween.moveLocal(cube, cube.transform.position + distancia * direction / 2 + Vector3.up, TimeAnim / 2).setOnComplete(() =>
                {
                    LeanTween.moveLocal(cube, cube.transform.position + distancia * direction / 2 - Vector3.up, TimeAnim / 2).setOnComplete(() =>
                    {
                        OnAnim = false;
                        
                    });
                });
            }
            else
            {
                if (direction.z > 0)
                {
                    TerrainCreator.TerrenoInfinito();
                    pasos++;
                    
                }
                else
                {
                    pasosAtras++;
                }
                
                LeanTween.moveLocal(cube, cube.transform.position + Vector3.up, TimeAnim / 2).setOnComplete(() =>
                {
                    LeanTween.moveLocal(cube, cube.transform.position  - Vector3.up, TimeAnim / 2).setOnComplete(() =>
                    {
                        OnAnim = false;
                        
                    });
                });

                LeanTween.moveLocal(map, map.transform.position - distancia * direction / 2, TimeAnim / 2).setOnComplete(() =>
                {
                    LeanTween.moveLocal(map, map.transform.position - distancia * direction / 2, TimeAnim / 2).setOnComplete(() =>
                    {
                        OnAnim = false;
                        
                    });
                });


            }
            
        }
    }

    
}
