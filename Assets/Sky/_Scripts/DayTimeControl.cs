
using UnityEngine;

public class DayTimeControl : MonoBehaviour {


    DayTimeControlEngine engine = new DayTimeControlEngine();


    public float dayLenghtInMinutes;
    public int dayCount;

    [SerializeField]
    private float dayTimeHours;
    [SerializeField]
    private float dayTimeMinutes;

    public GameObject moon;
    public GameObject sun;

    private float diffuseSpeedSun = .02f;
    private float diffuseSpeedMoon = .02f;
    private float time = 0f;
    private float offsetSpeed;
    private float textureOffset = 0f;

    public Material material;

    private void Start()
    {
        offsetSpeed = 1f / (dayLenghtInMinutes * 60);
        material.SetTextureOffset("_MainTex", new Vector2(0, 0));
    }

    void Update () {

        CountDays();

        time += Time.deltaTime;

        engine.CycleCompleted(ref time, textureOffset); //texture has completed a cycle so restart it
        
        TextureOffset();

        if (textureOffset >= .7)
        {
            //day
            turnSun();
        } else if (textureOffset >= .2) {
            //night
            turnMoon();
        }
    }

    private void TextureOffset()
    {
        material.SetTextureOffset("_MainTex", new Vector2(engine.ChangeTextureOffset(time, offsetSpeed), 0));
        textureOffset = engine.ChangeTextureOffset(time, offsetSpeed);
    }

    private void turnMoon()
    {
        engine.TurnMoon(sun.transform.localScale.x, moon.transform.localScale.x, ref diffuseSpeedMoon, ref diffuseSpeedSun);
        moon.transform.localScale += new Vector3(diffuseSpeedMoon, diffuseSpeedMoon, diffuseSpeedMoon);
        sun.transform.localScale += new Vector3(diffuseSpeedSun, diffuseSpeedSun, diffuseSpeedSun);
    }

    private void turnSun()
    {
        engine.TurnSun(sun.transform.localScale.x, moon.transform.localScale.x, ref diffuseSpeedMoon, ref diffuseSpeedSun);
        moon.transform.localScale += new Vector3(diffuseSpeedMoon, diffuseSpeedMoon, diffuseSpeedMoon);
        sun.transform.localScale += new Vector3(diffuseSpeedSun, diffuseSpeedSun, diffuseSpeedSun);
    }

    
    private void CountDays()
    {
        AddHours();
        engine.CountDays(ref dayCount, ref dayTimeHours);
    }

    private void AddHours()
    {
        AddMinutesPerSecond();
        engine.AddHours(ref dayTimeHours, ref dayTimeMinutes);
    }

    private void AddMinutesPerSecond()
    {
        dayTimeMinutes = engine.AddMinutesPerSecond(dayLenghtInMinutes, Time.deltaTime, dayTimeMinutes);
    }
}
