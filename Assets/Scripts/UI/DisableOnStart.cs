using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    [SerializeField] private bool StartDisable = true;
    private void Awake()
    {
        if (StartDisable) this.gameObject.SetActive(false);
    }
}
