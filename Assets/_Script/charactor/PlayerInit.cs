using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    [SerializeField, Header("プレイヤー移動速度")] private float _playerMoveSpeed = 5f;
    [SerializeField, Header("プレイヤーの重力")] private float _playerGravity = 1f;
    private PlayerView _playerView;
    private PlayerModel _playerModel;
    private PlayerPresenter _playerPresenter;
    private void Awake()
    {
        // プレイヤーモデルの初期化
        _playerView = GetComponent<PlayerView>();
        _playerModel = new PlayerModel(_playerMoveSpeed,_playerGravity);
        _playerPresenter = new PlayerPresenter(_playerModel, _playerView);
    }
}
