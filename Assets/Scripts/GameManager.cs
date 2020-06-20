using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject machinePrefab;

    public Reward[] rewards;

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

        if (Input.GetKeyDown("m"))
        {
            int[] matches;

            matches = Machine.instance.FindMatches();

            for (int i = 0; i < Machine.instance.GetNumFaces(); i++)
            {
                Debug.Log(matches[i]);
            }

        }
    }

    public void ReadyToMatch()
    {
        Debug.Log("All slots have stopped spinning. Ready to match!");

        StartCoroutine(Rewards());
    }

    IEnumerator Rewards()
    {
        int[] matches;

        int starCount = 0;

        int multiplier = 0;

        matches = Machine.instance.FindMatches();

        yield return new WaitForSeconds(1);

        for (int i = 0; i < Machine.instance.GetNumFaces(); i++)
        {
            foreach (Reward reward in rewards)
            {
                if (reward.faceType == (FACE_TYPE) i && reward.reqMatches == matches[i])
                {
                    if (reward.faceType != FACE_TYPE.Star)
                    {
                        Debug.Log("Matched " + matches[i] + ((FACE_TYPE) i).ToString() + ". " +
                                  reward.rewardType.ToString() + " " + reward.rewardAmount);
                    }
                    else
                    {
                        multiplier = reward.rewardAmount;
                    }
                } 
            }
        }
    }
}
