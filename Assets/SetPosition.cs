using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SetPosition : MonoBehaviour {



    public void SetP(float y)
    {
        Debug.Log("kaishi zhixing");

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y-y , this.transform.position.z);
    }
}
