using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmAnim : MonoBehaviour
{
    public ChikenAttack_anims chikenAttack_Anims;

    public void TriggerChicken()
    {
        chikenAttack_Anims.ThrowEgg();
    }
}
