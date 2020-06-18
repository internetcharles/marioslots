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

            faces[i].transform.position += new Vector3((float) slotNumber, i, 0);

            faces[i].transform.parent = this.gameObject.transform;
        }

    }

    public void StartSpinning()
    {
        Debug.Log("Slot received spinning message");
    }



}
