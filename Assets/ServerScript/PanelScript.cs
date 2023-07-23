using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(this.gameObject.activeInHierarchy)
        {
            BackendLogin.Instance.PanelActived();
        }
    }
}
