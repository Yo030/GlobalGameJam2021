using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour 
{
	public Sound[] sonidos;
	public static AudioManager instancia;

	void Awake()
	{
		if(instancia==null)
		{
			instancia = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach(Sound s in sonidos)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip=s.clip;

			s.source.volume = s.volumen;
			s.source.pitch = s.pitch;

			s.source.loop = s.loop;
		}
	}

	void Start()
	{
		
		play("Olas", 1);
		play("Gaviotas", 1);
		Invoke("RandomSoundReplay", 5.56f);
	}

	private void RandomSoundReplay()
    {
		int _everyxsec = UnityEngine.Random.Range(9, 17);
		play("Gaviotas", 1);
		Invoke("RandomSoundReplay", _everyxsec);
	}

	public void play(string _nombre, float _pitch)
	{
		Sound s = Array.Find(sonidos, sonido => sonido.name == _nombre);

		if(s == null)
		{
			Debug.LogWarning("sonido: "+ _nombre + " No Encontrado!");
			return;
		}
		s.source.pitch = _pitch;
		s.source.Play();
	}
}