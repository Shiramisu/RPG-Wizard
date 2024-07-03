using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public void GoToTitle()
    {

    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}