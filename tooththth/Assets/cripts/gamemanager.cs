using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class gamemanager : MonoBehaviour
{
    public Text timeTxt;
    public GameObject card;
    float time = 0.0f;

    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
            rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

            GameObject newcard = Instantiate(card);
            newcard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newcard.transform.position = new Vector3(x, y, 0);
            Debug.Log(rtans[i]);
        }
    }



    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }
}
