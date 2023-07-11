using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDelay : MonoBehaviour
{
    [SerializeField]
    private AudioSource menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.time = 2f;
        menu.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
