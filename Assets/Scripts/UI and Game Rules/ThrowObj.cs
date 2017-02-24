using UnityEngine;
using System.Collections;

public class ThrowObj {
    private GameObject thrower;
    private GameObject hit;
    public ThrowObj(GameObject throwerIn, GameObject hitIn)
    {
        thrower = throwerIn;
        hit = hitIn;
    }
    public GameObject getThrower()
    {
        return thrower;
    }
    public GameObject getHit()
    {
        return hit;
    }
}
