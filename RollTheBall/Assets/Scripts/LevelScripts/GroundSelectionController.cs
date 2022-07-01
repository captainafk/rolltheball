using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace RollTheBall
{
    public class GroundSelectionController : MonoBehaviour
    {
        [SerializeField] private GameObject _ground;
        [SerializeField] private GroundConfigSO _grassConfig;
        [SerializeField] private GroundConfigSO _earthConfig;

        private List<GroundConfigSO> _groundTypes = new List<GroundConfigSO>();
        private EGroundType _activeGround = EGroundType.None;

        private void Awake()
        {
            _groundTypes.Add(_grassConfig);
            _groundTypes.Add(_earthConfig);

            MessageBus.Receive<OnGroundSelectCommand>().Subscribe(ge =>
            {
                ChangeActiveGround(ge.GroundType);
            });
        }

        private void ChangeActiveGround(EGroundType groundType)
        {
            if (_activeGround == groundType) return;

            var ground = _groundTypes.Where(g => g.GroundType == groundType)
                                     .FirstOrDefault();

            _ground.GetComponent<MeshRenderer>().sharedMaterial = ground.Material;
            _ground.GetComponent<Collider>().sharedMaterial = ground.PhysicMaterial;
        }
    }

    public enum EGroundType
    {
        None = 0,
        Grass = 10,
        Earth = 20,
    }
}