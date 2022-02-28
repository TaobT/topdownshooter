using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SBList
{
    public static Type GetShootingBehaviour(WeaponData.GunShotBehaviour gunShot)
    {
        return gunShot switch
        {
            WeaponData.GunShotBehaviour.gun9mm => typeof(SB9mm),
            WeaponData.GunShotBehaviour.shotgunHomemade => typeof(SBHomemadeShotgun),
            WeaponData.GunShotBehaviour.meeleMachete => typeof(SBMachete),
            _ => null,
        };
    }
}
