using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background_Controller : MonoBehaviour
{
    private float timeCount;
    [SerializeField] private float maxTime;
    private int i;
    private float transitionTime;
    public float transitionMaxTime;
    private bool canTransit;
    private float percentageComplete;

    public List<GameObject> bgsBack = new List<GameObject>();
    public List<GameObject> bgsFront = new List<GameObject>();


    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= maxTime)
        {
            timeCount = 0;

            i++;
            transitionTime = 0;
            canTransit = true;
        }

        if (canTransit)
            transitionBG();
    }

    private void transitionBG()
    {
        if (i >= bgsBack.Count)
            i = 0;

        if (transitionTime < transitionMaxTime)
        {
            transitionTime += Time.deltaTime;
            percentageComplete = transitionTime / transitionMaxTime;

            if ((i - 1) < 0)
            {
                bgsBack[bgsBack.Count - 1].gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, (byte)Mathf.Lerp(255, 0, percentageComplete));
                bgsFront[bgsFront.Count - 1].gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, (byte)Mathf.Lerp(255, 0, percentageComplete));
            }
            else
            {
                bgsBack[i - 1].gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, (byte)Mathf.Lerp(255, 0, percentageComplete));
                bgsFront[i - 1].gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, (byte)Mathf.Lerp(255, 0, percentageComplete));
            }

            bgsBack[i].gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, (byte)Mathf.Lerp(0, 255, percentageComplete));
            bgsFront[i].gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, (byte)Mathf.Lerp(0, 255, percentageComplete));
        }
        else
        {
            canTransit = false;
        }
    }
}
