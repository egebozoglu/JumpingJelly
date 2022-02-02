using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        if (GameControl.instance.gameActive)
        {
            transform.position = new Vector3(transform.position.x, CharacterControl.instance.transform.position.y - 5f, transform.position.z);
        }
    }
}
