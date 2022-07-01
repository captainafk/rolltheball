using UnityEngine;
using UnityEngine.UI;

namespace RollTheBall
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPopup;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _settingsClose;
        [SerializeField] private Button _baseballBall;
        [SerializeField] private Button _golfBall;
        [SerializeField] private Button _earthGround;
        [SerializeField] private Button _grassGround;

        private void Awake()
        {
            _settingsPopup.SetActive(false);
            _settings.onClick.AddListener(() => _settingsPopup.SetActive(!_settingsPopup.activeInHierarchy));
            _settingsClose.onClick.AddListener(() => _settingsPopup.SetActive(false));

            _baseballBall.onClick.AddListener(() => CommandBallChange(EBallType.Baseball));
            _golfBall.onClick.AddListener(() => CommandBallChange(EBallType.Golf));

            _earthGround.onClick.AddListener(() => CommandGroundChange(EGroundType.Earth));
            _grassGround.onClick.AddListener(() => CommandGroundChange(EGroundType.Grass));
        }

        private void CommandBallChange(EBallType ball)
        {
            MessageBus.Publish(new OnBallSelectCommand(ball));
        }

        private void CommandGroundChange(EGroundType ground)
        {
            MessageBus.Publish(new OnGroundSelectCommand(ground));
        }

        private void OnDestroy()
        {
            _settings.onClick.RemoveAllListeners();
            _settingsClose.onClick.RemoveAllListeners();
            _baseballBall.onClick.RemoveAllListeners();
            _golfBall.onClick.RemoveAllListeners();
            _earthGround.onClick.RemoveAllListeners();
            _grassGround.onClick.RemoveAllListeners();
        }
    }
}