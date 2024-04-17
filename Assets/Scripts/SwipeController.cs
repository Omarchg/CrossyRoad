using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    Vector3 ClickInicial;
    Vector3 ClickAlSoltar;
    [SerializeField] GameObject cube;
    public float offset = 25f;
    public float distanciaRayo;
    
    public static SwipeController Instance;

    public delegate void Swipe(Vector3 direction);
    public event Swipe OnSwipe;
    public LayerMask capaobstaculos;


    private void Awake()
    {
        if (SwipeController.Instance == null)
        { 
            SwipeController.Instance = this;
        }
        else Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ClickInicial = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ClickAlSoltar = Input.mousePosition;

            Vector3 diferencia = ClickAlSoltar - ClickInicial;
            if (diferencia == new Vector3(0,0,0))
            {
                diferencia.z = 1;
                cube.transform.eulerAngles = new Vector3(0, 0, 0);

                if (Rayo())
                {
                    return;
                }

                OnSwipe(diferencia);
            }

            if (Mathf.Abs(diferencia.magnitude) > offset)
            {
                diferencia = diferencia.normalized;
                diferencia.z = diferencia.y;


                if (Mathf.Abs(diferencia.x) > Mathf.Abs(diferencia.z))
                {
                    diferencia.z = 0.0f;
                    if (diferencia.x>0)
                    {
                        cube.transform.eulerAngles = new Vector3(0, +90, 0);
                    }
                    else
                    {
                        cube.transform.eulerAngles = new Vector3(0, -90, 0);
                    }
                }
                else
                {
                    diferencia.x = 0.0f;
                    if (diferencia.z>0)
                    {
                        cube.transform.eulerAngles = new Vector3(0, 0, 0);
                        

                    }
                    else
                    {
                        cube.transform.eulerAngles = new Vector3(0, 180, 0);
                        
                    }
                    
                }

                diferencia.y = 0f;
                if (Rayo())
                {
                    return;
                }

                if (OnSwipe != null)
                {
                    OnSwipe(diferencia);
                }

            }
        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(cube.transform.position + Vector3.up * 0.5f, cube.transform.position + Vector3.up * 0.5f + cube.transform.forward * distanciaRayo);
    }
    public bool Rayo()
    {
        RaycastHit hit;
        Ray rayo = new Ray(cube.transform.position + Vector3.up * 0.5f, cube.transform.forward);
        if (Physics.Raycast(rayo, out hit, distanciaRayo, capaobstaculos))
        {
            return true;
        }
        return false;
    }



}
