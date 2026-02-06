using UnityEngine;

public class PlayerPresenter
{
    PlayerModel _playerModel;
    PlayerView _playerView;
    public PlayerPresenter(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;
        //プロパティに引き渡す
        _playerView.Presenter = this;
    }
    /// <summary>
    /// Viewからの移動入力を受け取り移動を実行する
    /// </summary>
    /// <param name="Input"></param>
    public void OnMoveInput(Vector2 Input)
    {
        //登録
        _playerModel.CurrentInput = Input;
        //入力を移動量に変換
        Vector3 movement = new Vector3(Input.x, 0f, Input.y) * _playerModel.MoveSpeed;

        _playerView.PerformMove(movement,_playerModel.Gravity);
    }
}