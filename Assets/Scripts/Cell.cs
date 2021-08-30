using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _contentRenderer;
    [SerializeField] private Object _particles;
    private ParentForCells _parent;
    private LevelSwitch _level;
    private LevelTask _levelTask;
    public string SpriteName => _spriteName;
    private string _spriteName;
    

    public void SetSprite(AvailableResources resources)
    {
        _contentRenderer.sprite = resources.GetSprite();
        _spriteName = _contentRenderer.sprite.name;
    }
    private void Awake()
    {
        _parent = FindObjectOfType<ParentForCells>();
        transform.SetParent(_parent.transform);

        _levelTask = FindObjectOfType<LevelTask>();
    }

    private void Start()
    {
        _level = FindObjectOfType<LevelSwitch>();
        if(_level.Level == 1)
            Shake(transform, 1.5f, new Vector3(0, 2, 0), 3);
    }
    private async void OnMouseDown() 
    {
        Vector3 position = transform.position;
        
        if(_spriteName == _levelTask.CorrectElement)
        {
            Shake(_contentRenderer.transform, 0.5f, new Vector3(0, 0.5f, 0), 3);
            _contentRenderer.transform.DOScale(new Vector3(1.5f, 1.5f, 0f), 1f);
            Instantiate(_particles, new Vector3(position.x, position.y, -1), Quaternion.identity);

            await Task.Delay(1500);
            _level.NextLevel();
            _parent.ResetData();
        }
        else
        {
            Shake(_contentRenderer.transform, 1f, new Vector3(0.3f, 0 ,0), 10);
            _contentRenderer.transform.DOShakeScale(1f, 1f, 5);
        }
    }

    private void Shake(Transform subject, float duration, Vector3 strenght, int vibrato)
    {
        subject.DOShakePosition(duration, strenght, vibrato, 1, false, true);
    }
   
    
}
