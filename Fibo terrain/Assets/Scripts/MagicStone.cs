using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class MagicStone : MonoBehaviour
{   
    public Transform playerT;
    public GameObject clickTo;
    public TextMeshProUGUI textDisplay;
    public AudioClip stoneClicked;

    AudioSource audioSource;

    private int nthNumber = 0;
    private bool isCloseEnough;   


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Display canvas when close enough
        float distance = Vector3.Distance(playerT.position, transform.position);

        if (distance < 10)
        {
            clickTo.SetActive(true);
            isCloseEnough = true;
        }
        else
        {
            clickTo.SetActive(false);
            isCloseEnough = false;
        }

        //Get input
        if (isCloseEnough && Input.GetMouseButtonDown(0))
        {
            printFib(nthNumber); //Pass in the next number
            nthNumber++; //Add 1 to get next in sequence
            audioSource.PlayOneShot(stoneClicked, 1f); //Play sound once clicked            
        }
    }

    //Fibonacci logic
    void printFib(int x)    
    {
        int a = 0, b = 1, fibonacci = 0;

        if (x == 0)
        {
            textDisplay.SetText("" + a); //Print 1st number on canvas
        }

        if (x == 1)
        {
            textDisplay.SetText("" + b); //Print 2nd number on canvas            
        }


        //Calculate next number
        for (int i = 1; i < x; i++)
        {
            fibonacci = a + b;
            textDisplay.SetText("" + fibonacci); //Print next in sequence on canvas
            a = b;
            b = fibonacci;
        }
    }
}
