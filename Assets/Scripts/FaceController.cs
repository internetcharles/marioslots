using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour
{

    private bool isSpinning = false;

    private float spinSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        {
            transform.Translate(Vector3.down * Time.deltaTime * spinSpeed, Space.World);


            if (transform.position.y < 0)
            {
                transform.position += new Vector3(0, Machine.instance.GetNumFaces(), 0);
            }
        }
    }

    public void StartSpinning(float slotSpeed)
    {

        isSpinning = true;
        spinSpeed = slotSpeed;
    }

    public void StopSpinning()
    {
        isSpinning = false;
    }

}
