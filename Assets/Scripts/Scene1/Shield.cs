using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public void Activate(bool active)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(active);   
    }
}
