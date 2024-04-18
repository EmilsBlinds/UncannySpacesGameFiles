using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public GameObject inticon, flashlight_ground, flashlight_hand, Flashlight_held, FlashlightInHand;
    private bool PickedUp = false;
    public AudioSource pickup;



    void Update() //Allows the player to pick up the flashlight by pressing E, if the inticon is active and the flashlight has not been picked up
    {
        if (inticon.activeSelf && Input.GetKeyDown(KeyCode.E) && !PickedUp)
        {
            PickUpFlashlight();
        }


    }


    void OnTriggerStay(Collider other) //If looking at flashlight, show inticon
    {
        if (other.CompareTag("MainCamera"))
        {
            inticon.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) //If not looking at flashlight, hide inticon
    {
        if (other.CompareTag("MainCamera"))
        {
            inticon.SetActive(false);
        }
    }

    void PickUpFlashlight() //Pick up flashlight function
    {
        flashlight_ground.SetActive(false);
        inticon.SetActive(false);
        flashlight_hand.SetActive(true);
        Flashlight_held.SetActive(true);
        PickedUp = true;
        pickup.Play();
        Debug.Log("Flashlight picked up");

    }

 



}
