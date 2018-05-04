using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeViselitsaByCanvas : MonoBehaviour
{

    public GameObject Viselitsa0;
    public GameObject Viselitsa1;
    public GameObject Viselitsa2;
    public GameObject Viselitsa3;
    public GameObject Viselitsa4;
    public GameObject Viselitsa5;
    public GameObject Viselitsa6; //Програшна
    public Canvas canvas;
    public void UpdateToOneMistake()
    {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_0_mistake");
        var temp = Instantiate(Viselitsa1);
        temp.transform.SetParent(canvas.transform, false);
        Destroy(whatToDelete);
    }
    public void UpdateToTwoMistakes()
    {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_1_mistake(Clone)");

        var temp = Instantiate(Viselitsa2);
        temp.transform.SetParent(canvas.transform, false);
        Destroy(whatToDelete);
    }
    public void UpdateToThreeMistakes()
    {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_2_mistake(Clone)");
        var temp = Instantiate(Viselitsa3);
        temp.transform.SetParent(canvas.transform, false);
        Destroy(whatToDelete);
    }
    public void UpdateToFourMistakes()
    {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_3_mistake(Clone)");
        var temp = Instantiate(Viselitsa4);
        temp.transform.SetParent(canvas.transform, false);
        Destroy(whatToDelete);
    }
    public void UpdateToFiveMistakes()
    {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_4_mistake(Clone)");
        var temp = Instantiate(Viselitsa5);
        temp.transform.SetParent(canvas.transform, false);
        Destroy(whatToDelete);
    }
    public void UpdateToSixMistakes()
    {
        GameObject whatToDelete;
        whatToDelete = GameObject.Find("Viselitsa_5_mistake(Clone)");
        var temp = Instantiate(Viselitsa6);
        temp.transform.SetParent(canvas.transform, false);
        Destroy(whatToDelete);
    }
}
