using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AvailableResources : MonoBehaviour
{
    [SerializeField] private List<Storage> _storage;
    private List<Sprite> _availableSprite;
 
    
    private void Start() => OverwriteData();
    public Sprite GetSprite()
    {
        Sprite currentSprite = _availableSprite.ElementAt(SetRandomNumber());
        _availableSprite.Remove(currentSprite);
        return currentSprite;
    }
    public void OverwriteData() => _availableSprite = new List<Sprite>(_storage.ElementAt(Random.Range(0, _storage.Count)).Content);
    private int SetRandomNumber()
    {
        int random = Random.Range(0, _availableSprite.Count);
        return random;
    }
}
