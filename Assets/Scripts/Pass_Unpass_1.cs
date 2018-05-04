using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pass_Unpass_1 : MonoBehaviour {
    public InputField field1;
    public Text textfield;
    // Use this for initialization
   public void OnMouseOver() {
        field1.contentType = InputField.ContentType.Standard;
        textfield.text = field1.text;
    }
    public void OnMouseOf() {
        field1.contentType = InputField.ContentType.Password;
        textfield.text = "";
    }
}
