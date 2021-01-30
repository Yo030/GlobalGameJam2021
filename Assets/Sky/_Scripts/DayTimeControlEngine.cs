using System.Collections;
using System.Collections.Generic;

public class DayTimeControlEngine
{
    public float AddMinutesPerSecond(float _dayLengthInMinutes,float _deltaTime, float _dayTimeMinutes)
    {
        _dayTimeMinutes += (1440 / (_dayLengthInMinutes * 60)) * _deltaTime;

        return _dayTimeMinutes;
    }

    public void AddHours(ref float _dayTimeHours, ref float _dayTimeMinutes)
    {
        if (_dayTimeMinutes >= 60)
        {
            _dayTimeHours++;
            _dayTimeMinutes -= 60;
        }
    }

    public void CountDays(ref int _dayCount, ref float _dayTimeHours)
    {
        if (_dayTimeHours >= 24)
        {
            _dayCount++;
            _dayTimeHours -= 24;
        }
    }

    public void TurnSun(float _sunScale, float _moonScale, ref float _diffuseSpeedMoon, ref float _diffuseSpeedSun)
    {
        if (_sunScale <= 1)
        {
            _diffuseSpeedSun = .02f;
        }
        else
        {
            _diffuseSpeedSun = 0f;
        }
        if (_moonScale > 0)
        {
            _diffuseSpeedMoon = -.02f;
        }
        else
        {
            _diffuseSpeedMoon = 0f;
        }
    }

    public void TurnMoon(float _sunScale, float _moonScale, ref float _diffuseSpeedMoon, ref float _diffuseSpeedSun)
    {

        if (_sunScale > 0)
        {
            _diffuseSpeedSun = -.02f;
        }
        else
        {
            _diffuseSpeedSun = 0f;
        }
        if (_moonScale <= 1)
        {
            _diffuseSpeedMoon = .02f;
        } else
        {
            _diffuseSpeedMoon = 0f;
        }
        
    }

    public float ChangeTextureOffset(float _time, float _offsetSpeed)
    {
        float offset = _time * _offsetSpeed;
        return offset;
    }
    
    public void CycleCompleted(ref float _time, float _textureOffset)
    {
        if (_textureOffset >= 1)
        {
            _time = 0;
        }
    }
}