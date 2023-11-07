using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Presets.Animation
{
    [Serializable]
    public class ShakeAnimation
    {
        public ShakeRandomnessMode RandomnessMode = ShakeRandomnessMode.Harmonic;
        public Ease Ease = DOTween.defaultEaseType;
        public Vector3 Strength;
        public float Randomness;
        public float Duration;
        public int Vibrato;
        public bool FadeOut;
    }
}
