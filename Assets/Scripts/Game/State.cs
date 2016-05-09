public enum CharacterState
{
    Idle = 0,
    Run = 1,
    BeHit = 2,


    //상태이상
    KnockBack = 3,
    Freeze = 4,
    Poison = 5,
    Burn = 6,
    Stun = 7,
    Shock = 8,
    Immune = 9,

    Dead = 10,


    Max
}
public enum WeaponState
{
    /*
        0. can't use alone
        1. one handed
        2. two handed
        3. range

    */
    arrow = 0,
    star = 1,
    shield = 2,

    axe = 3,
    bow = 4,
    claw = 5,
    dagger = 6,
    katar = 7,
    mace = 8,
    spear = 9,
    staff = 10,
    sword = 11,
    wand = 12,

    Max

}