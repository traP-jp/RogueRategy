using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardEffect
{
    public interface ICardEffectProcessor
    {
        void Process(StatusBase usersStatus,Vector2 usersPos);
    }
}
