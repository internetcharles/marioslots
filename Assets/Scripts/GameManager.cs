using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject machinePrefab;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Machine singleton is already initialized.");
            Destroy(this.gameObject);
        }
        else if (instance != this)
        {
            instance = this;
        }

        Instantiate(machinePrefab);
        Machine.instance.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Machine.instance.StartSpinning();
        }
    }
}
