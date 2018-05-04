using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_viselitsa : MonoBehaviour
{
    public GameObject Viselitsa0;
    public GameObject Viselitsa1;
    public GameObject Viselitsa2;
    public GameObject Viselitsa3;
    public GameObject Viselitsa4;
    public GameObject Viselitsa5;
    public GameObject Viselitsa6; //Програшна

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateToOneMistake()
    {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_0_mistake");

        Instantiate(Viselitsa1);
        Destroy(whatToDelete);
    }
    public void UpdateToTwoMistakes()
    {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_1_mistake(Clone)");
        Instantiate(Viselitsa2);
        Destroy(whatToDelete);
    }
    public void UpdateToThreeMistakes() {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_2_mistake(Clone)");
        Instantiate(Viselitsa3);
        Destroy(whatToDelete);
    }
    public void UpdateToFourMistakes() {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_3_mistake(Clone)");
        Instantiate(Viselitsa4);
        Destroy(whatToDelete);
    }
    public void UpdateToFiveMistakes()
    {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_4_mistake(Clone)");
        Instantiate(Viselitsa5);
        Destroy(whatToDelete);
    }
    public void UpdateToSixMistakes() {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_5_mistake(Clone)");
        Instantiate(Viselitsa6);
        Destroy(whatToDelete);
    }

}
