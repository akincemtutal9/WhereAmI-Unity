using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class GamaManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Place place;
    [SerializeField] private Button playButton;
    [SerializeField] private Button showButton;
    [SerializeField] private float showDuration;
    [SerializeField] private TextMeshProUGUI placeText;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private GameObject menuCanvasGO, gameCanvasGO;
    private string currentPlace;

    private FloatReactiveProperty timer = new FloatReactiveProperty();

    private IntReactiveProperty currentPlayerIndex = new IntReactiveProperty(-1);

    private int impostorIndex;


    private void Start()
    {
        HandlePlayButton();

        HandleShowButton();
        ShowPlaceOrImpostorText();
    }


    private void HandlePlayButton()
    {
        playButton.OnClickAsObservable()
            .Do(_ =>
            {
                menuCanvasGO.SetActive(false);
                gameCanvasGO.SetActive(true);
            })
            .Subscribe(_ =>
            {
                impostorIndex = gameSettings.ChooseImpostor;
                currentPlace = place.GetRandomPlace;
            })
            .AddTo(gameObject);
    }


    private void ShowPlaceOrImpostorText()
    {
        currentPlayerIndex
            .Do(index =>
            {
                if (index == impostorIndex)
                {
                    placeText.text = "Impostor";
                    return;
                }

                placeText.text = currentPlace;
                timer.Value = showDuration;
            })
            .Select(_ => this.UpdateAsObservable())
            .Switch()
            .Subscribe(_ =>
            {
                timer.Value -= Time.deltaTime;
                timerText.text = $"{timer.Value:F1}";
            })
            .AddTo(gameObject);
    }

    private void HandleShowButton()
    {
        showButton.OnClickAsObservable().Subscribe(_ => { currentPlayerIndex.Value++; }).AddTo(gameObject);
    }
}