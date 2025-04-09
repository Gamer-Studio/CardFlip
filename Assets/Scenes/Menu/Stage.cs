using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardFlip
{
    [CreateAssetMenu(fileName = "Stage", menuName = "CardFlip/StageInfo")]
    public class Stage : ScriptableObject
    {
        // 시간제한
        public int stageNum;

        public float timeLimit;
        // 최대 시도횟수
        public int remainAttempt;
        [Range(1, 8)]
        public int pair;
    }
}
