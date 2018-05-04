using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words_Fields_Canvas : MonoBehaviour {
    public GameObject viselitsa;
    private GameObject visetlisa_object;
    public GameObject rotate_around;
	// Use this for initialization
	void Start () {
        //visetlisa_object = Instantiate(viselitsa);
	}
	
	// Update is called once per frame
	void Update () {
        //viselitsa.transform.Rotate(new Vector3(0, (float)0.1, 0));
        // viselitsa.transform.Rotate(Vector3.up, (float)1.2 * Time.deltaTime);
         viselitsa.transform.Rotate(0, 20 * Time.deltaTime, 0);
       // transform.RotateAround(rotate_around.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
