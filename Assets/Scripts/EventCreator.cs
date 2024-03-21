using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCreator : MonoBehaviour
{
    public delegate void PresionarEnter();
    public event PresionarEnter OnPresionarEnter;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if(OnPresionarEnter != null)
            {
                OnPresionarEnter();
            }
        }

    }
}
