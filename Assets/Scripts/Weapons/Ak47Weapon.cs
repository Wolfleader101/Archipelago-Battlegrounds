using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47Weapon : BaseWeapon
{
   
    // Start is called before the first frame update
    void Start()
    {
        base.shootCooldown = 0.5f;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
