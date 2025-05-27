using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafeOfFear
{
    public interface IFillinable
    {
        PapperCup.PapperCupState CupState { get; set; }
        void StartFilling();
    }
}
