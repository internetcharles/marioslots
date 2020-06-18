using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FaceController : MonoBehaviour
{

    public FACE_TYPE faceType;

    private bool isSpinning = false;
    private bool isStopping = false;
    private bool isSlowing = false;

    // stop position on y axis
    private float stopPoint = 0;
    private float spinSpeed = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (spinSpeed < Machine.instance.slotSlowestSpinSpeed)
        {
            spinSpeed = Machine.instance.slotSlowestSpinSpeed;
            isSlowing = false;
            isStopping = true;

            stopPoint = Mathf.Floor(transform.position.y);


        }

        if (isSpinning)
        {
            transform.Translate(Vector3.down * Time.deltaTime * spinSpeed, Space.World);

            if (!isStopping)
            {
                if (transform.position.y < 0)
                {
                    transform.position += new Vector3(0, Machine.instance.GetNumFaces(), 0);
                }
            }
        }

        if (isStopping)
        {
            if (transform.position.y <= stopPoint)
            {
                transform.position = new Vector3(transform.position.x, stopPoint, transform.position.z);

                isSpinning = false;
                isStopping = false;
                stopPoint = 0;
            }
        }
    }

    public void StartSpinning(float slotSpeed)
    {
        StopAllCoroutines();
        isSpinning = true;
        isStopping = false;
        isSlowing = false;
        spinSpeed = slotSpeed;
    }

    public void StopSpinning()
    {
        isSlowing = true;

        StartCoroutine(SlowSpinOverTime(Machine.instance.slotSlowdownInterval, Machine.instance.slotSlowdownDelta));
    }

    public FACE_TYPE GetFaceType()
    {
        return (faceType);
    }



    IEnumerator SlowSpinOverTime(float interval, float delta)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            if (isStopping || !isSpinning) yield break;

            spinSpeed -= delta;
        }
    }

}
