using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class GamePresenter : MonoBehaviour
    {
        private NPC_Main _NPC_Main;

        [Inject]
        public void Counstruct(NPC_Main npc_Main)
        {
            _NPC_Main = npc_Main;
        }

        public void Init()
        {

        }
    }
}
