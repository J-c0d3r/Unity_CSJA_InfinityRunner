using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Controller : MonoBehaviour
{
    public Parallax p1;
    public Parallax p2;

    public Transform posBack;
    public Transform posFront;


    public void SwitchBoolBGParallax(bool canMove)
    {
        p1.canMove = canMove;
        p2.canMove = canMove;
    }

    public void RepositionBG(Transform posBackNext, Transform posFrontNext)
    {
        p1.Reposition(posBackNext, posFrontNext);
        p2.Reposition(posBackNext, posFrontNext);
    }

}
