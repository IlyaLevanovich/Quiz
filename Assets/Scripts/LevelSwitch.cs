using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelSwitch : MonoBehaviour
{
    [SerializeField] private CellsCreator _cellCreator;
    [SerializeField, Range(1,5)] private int _level;
    [SerializeField] private Image _veil;
    [SerializeField] private GameObject _buttonRestart;
    public int Level => _level;
    [SerializeField] private UnityEvent OverrideDataEvent;


    private void Start() => StartLevel();
    public void NextLevel()
    {
        OverrideDataEvent.Invoke();
        if(_level < 3)
        {
            _level++;
            StartLevel();
        }
        else
            GameOver();
    }
    public void Restart()
    {
        _level = 1;
        _buttonRestart.SetActive(false);
        StartLevel();
        Fade(_veil, 0, 1.5f);
    }
    private void StartLevel() =>  _cellCreator.InitializeCount(_level);
    private void GameOver()
    {
        Fade(_veil, 1f, 1f);
        _buttonRestart.SetActive(true);
    }
    private void Fade(Image subject, float endValue, float duration) => subject.DOFade(endValue, duration);

}
