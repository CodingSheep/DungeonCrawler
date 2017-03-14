using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public bool unlocked;
    public double dmgMult;
    public string name;
    public float speedMult;

    public Spell(bool un, double dm, string na, float sm)
    {
        unlocked = un;
        dmgMult = dm;
        name = na;
        speedMult = sm;
    }
}