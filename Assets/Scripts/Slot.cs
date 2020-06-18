#pragma warning disable 0414

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    private int slotNumber;

    private bool isSpinning = false;

    private GameObject[] faces;

    public void Init(int slotNumber)
    {
        this.slotNumber = slotNumber;

        faces = new GameObject[Machine.instance.GetNumFaces()];

        for (int i = 0; i < Machine.instance.GetNumFaces(); i++)
        {
            faces[i] = Instantiate(Machine.instance.GetFace(i).facePrefab) as GameObject;
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
}
