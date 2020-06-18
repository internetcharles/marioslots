#pragma warning disable 0414

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public FACE_TYPE faceType;
    private const float CENTER = 3.0f;

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

    // returns face type of center image in slot
    public FACE_TYPE GetFaceType()
    {

        FACE_TYPE faceType = 0;

        for(int i = 0; i < Machine.instance.GetNumFaces(); i++)
        {
            if (faces[i].transform.position.y == CENTER)
            {
                faceType = faces[i].GetComponent<FaceController>().GetFaceType();
                return faceType;
            }
        }

        Debug.LogError("Error! Returned default facetype.");
        return faceType;
    }

    public void StartSpinning()
    {
        Debug.Log("Slot received spinning message");
    }



}
