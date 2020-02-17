using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automaticDoor : MonoBehaviour
{
    Animator door;

    
    void Start()
    {
        door = GetComponent<Animator>();

    }

  

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        door.SetTrigger("DoorOpen");
    }

    void OnTriggerExit(Collider other)
    {
        door.enabled = true;
    }
    void pauseAnimationEvent()
    {
        door.enabled = false;
    }
}
