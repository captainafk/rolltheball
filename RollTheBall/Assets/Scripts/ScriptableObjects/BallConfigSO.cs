using UnityEngine;

namespace RollTheBall
{
    [CreateAssetMenu(fileName = "BallConfig", menuName = "ScriptableObjects/BallConfig")]
    public class BallConfigSO : ScriptableObject
    {
        public EBallType BallType;
        public PhysicMaterial PhysicMaterial;
    }
}