using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetImageInSlot : MonoBehaviour
{
    private Color Transparent = new Color(1, 1, 1, 0);
    private Color White = new Color(1, 1, 1, 1);

    public void SetImage(Sprite _imagetoplace)
    {
        Image _thisimage = this.GetComponent<Image>();
        _thisimage.sprite = _imagetoplace;
       
        if(_thisimage.sprite == null)
        {
            _thisimage.color = Transparent;
        }
        else
        {
            _thisimage.color = White;
        }
    }
    public void SetColor(Sprite _imagetoplace)
    {
        Image _thisimage = this.GetComponent<Image>();
        _thisimage.color = Transparent;
    }
}
