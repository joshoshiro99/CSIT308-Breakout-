using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadzone : MonoBehaviour
{
    void OnTriggerEnter()
    {
        GM.instance.LoseLife();
    }
}
