using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace RollTheBall
{
    public class BallSelectionController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController _movementController;
        [SerializeField] private Cinemachine.CinemachineVirtualCamera _gameCam;
        [SerializeField] private GameObject _baseballBall;
        [SerializeField] private GameObject _golfBall;

        private Dictionary<EBallType, GameObject> _ballModelByType = new Dictionary<EBallType, GameObject>();
        private EBallType _activeBall = EBallType.Baseball;

        public EBallType ActiveBall => _activeBall;

        private void Awake()
        {
            _ballModelByType[EBallType.Baseball] = _baseballBall;
            _ballModelByType[EBallType.Golf] = _golfBall;

            MessageBus.Receive<OnBallSelectCommand>().Subscribe(ge =>
            {
                ChangeActiveBall(ge.BallType);
            });
        }

        private void ChangeActiveBall(EBallType ball)
        {
            if (_activeBall == ball) return;

            var previousBall = _ballModelByType[_activeBall];
            var ballPosition = previousBall.transform.position;
            previousBall.SetActive(false);

            _activeBall = ball;
            var newBall = _ballModelByType[_activeBall];
            newBall.transform.position = ballPosition + Vector3.up;
            newBall.SetActive(true);
            _movementController.Rigidbody = newBall.GetComponent<Rigidbody>();
            _gameCam.Follow = newBall.transform;
        }
    }

    public enum EBallType
    {
        None = 0,
        Baseball = 10,
        Golf = 20,
    }
}