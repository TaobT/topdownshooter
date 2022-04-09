using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SBList
{
    public static Type GetShootingBehaviour(WeaponData.WeaponShootBehaviour gunShot)
    {
        return gunShot switch
        {
            WeaponData.WeaponShootBehaviour.gun9mm => typeof(SB9mm),
            WeaponData.WeaponShootBehaviour.shotgunHomemade => typeof(SBHomemadeShotgun),
            WeaponData.WeaponShootBehaviour.meeleMachete => typeof(SBMachete),
            _ => null,
        };
    }
}
