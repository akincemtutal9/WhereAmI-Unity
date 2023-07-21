using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    private IntReactiveProperty playerCount = new IntReactiveProperty();

    public int PlayerCount => playerCount.Value;
    public int ChooseImpostor => Random.Range(0, playerCount.Value);

    [SerializeField] private Button addPlayerButton;
    [SerializeField] private Button removePlayerButton;
    [SerializeField] private TextMeshProUGUI playerCountText;


    private void Start()
    {
        HandleButtons();
        playerCount.Subscribe(i => playerCountText.text = i.ToString()).AddTo(gameObject);
    }

    private void HandleButtons()
    {
        addPlayerButton.OnClickAsObservable()
            .Subscribe(_ => playerCount.Value++)
            .AddTo(gameObject);

        removePlayerButton.OnClickAsObservable()
            .Subscribe(_ => playerCount.Value--)
            .AddTo(gameObject);
    }
}