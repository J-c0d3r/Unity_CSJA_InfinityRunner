using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Controller : MonoBehaviour
{
    private int j = 0;
    private float timeCount;
    [SerializeField] private float maxTime;

    public List<Parallax_Controller> listBG = new List<Parallax_Controller>();


    private void Start()
    {
        listBG[j + 1].RepositionBG(listBG[j].posBack, listBG[j].posFront);
    }

    private void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= maxTime)
        {
            timeCount = 0;
            for (int i = 0; i < listBG.Count; i++)
            {
                listBG[i].SwitchBoolBGParallax(false);
            }

            j++;
            if (j >= listBG.Count)
                j = 0;


            if (j + 1 >= listBG.Count)
            {
                listBG[0].RepositionBG(listBG[j].posBack, listBG[j].posFront);
            }
            else
            {
                listBG[j + 1].RepositionBG(listBG[j].posBack, listBG[j].posFront);
            }
            listBG[j].SwitchBoolBGParallax(true);
        }
    }

}
