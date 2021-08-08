using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TaskText : MonoBehaviour
{
    [SerializeField] private Text _task;
    private Tween _tweenFade;

    public void SetTask(string desiredElement)
    {
        _task.text = $"Find {desiredElement}";
        FadeIn();
    }
    private void Fade(float endValue, float duration)
    {
        _tweenFade?.Kill();
        _tweenFade = _task.DOFade(endValue, duration);
    }
    private void FadeIn() => Fade(1, 1.5f);

}
