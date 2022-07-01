using UnityEngine;

namespace RollTheBall
{
    [CreateAssetMenu(fileName = "GroundConfig", menuName = "ScriptableObjects/GroundConfig")]
    public class GroundConfigSO : ScriptableObject
    {
        public EGroundType GroundType;
        public PhysicMaterial PhysicMaterial;
        public Material Material;
    }
}