using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ColorChange : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<ButtonInfo>().IsClicked = !other.gameObject.GetComponent<ButtonInfo>().IsClicked;

        Image image = other.gameObject.transform.GetComponentsInChildren<Image>()[1];
        if (image && other.gameObject.GetComponent <ButtonInfo >().IsClicked)
        {
            image.color = new Color(0, 0, 0, 120);
        }
        else
        {
            image.color = new Color(0,0,0,0);
        }
    }
}
