#pragma warning disable 0414

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{

    public static Machine instance;

    public int numSlots;
    public float minSlotSpeed;
    public float maxSlotSpeed;

    public GameObject slotPrefab;

    public Face[] faces;

    private bool isSpinning = false;

    private GameObject[] slots;

    private int slotsSpinning;

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
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Init()
    {
        SpawnSlots();
    }

    public int GetNumFaces()
    {
        return faces.Length;
    }

    public Face GetFace(int i)
    {
        return faces[i];
    }

    private void SpawnSlots()
    {
        slots = new GameObject[numSlots];

        for (int i = 0; i < numSlots; i++)
        {
            slots[i] = Instantiate(slotPrefab) as GameObject;


            Slot slotScript = slots[i].GetComponent<Slot>();

            if (slotScript == null)
            {
                Debug.Log("No slot script on object");
            }
            else
            {
                slotScript.Init(i);
            }

        }
    }

    public void StartSpinning()
    {
        for (int i = 0; i < numSlots; i++)
        {
            slots[i].BroadcastMessage("StartSpinning");
        }

        isSpinning = true;
    }

}
