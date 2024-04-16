using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Troupe
{
    State spawn = new State();
    private void onSpawnEnter()
    {
       
    }
    private void onSpawnUpdate()
    {
        if (active)
            ChangeState(move);
    }

    private void onSpawnExit()
    {

    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}