using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace Effects
{
    public class EffectManager
    {
        private static readonly List<Color32> BackgroundColors = new List<Color32>()
        {
            new Color32(0, 180, 255, 255),
            new Color32(0, 100, 200, 255),
            new Color32(0, 50, 255, 255),
            new Color32(0, 0, 255, 255),
            new Color32(100, 0, 255, 255),
            new Color32(150, 0, 255, 255),
            new Color32(100, 0, 100, 255),
        };


        private readonly ParticleSystem _landingParticleEffect;
        private readonly GameObject _camera;
        private MonoBehaviour _game;

        public EffectManager(ParticleSystem landingParticleEffect, GameObject camera, MonoBehaviour game)
        {
            _landingParticleEffect = landingParticleEffect;
            _camera = camera;
            _game = game;
        }

        public void SetBackgroundColor(GameSession gameSession)
        {
            if (gameSession.Level < BackgroundColors.Count)
            { 
                SetBackgroundColor(BackgroundColors[gameSession.Level-1]);
            }
            else
            {
                SetBackgroundColor(Color.black);
            }
        }

        private void SetBackgroundColor(Color color)
        {
            Camera.main.backgroundColor = color;
        }

        public void PlayLandingEffect()
        {
            _landingParticleEffect.Play();
        }

        public void PlayDashDownLandingEffect()
        {
            _landingParticleEffect.Play();
            _game.StartCoroutine(ShakeCamera(0.1f, 0.3f));
        }

        public void PlayDieEffect()
        {
            _game.StartCoroutine(ShakeCamera(1f, 0.3f));
        }

        public IEnumerator ShakeCamera(float duration, float magnitude)
        {
            var cameraTransform = _camera.transform;
            Vector3 originalPos = cameraTransform.localPosition;

            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = originalPos.x + (Random.Range(-1f, 1f) * magnitude);
                float y = originalPos.y + (Random.Range(-1f, 1f) * magnitude);

                cameraTransform.localPosition = new Vector3(x, y, originalPos.z);
                elapsed += Time.deltaTime;
                yield return null;
            }

            cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, originalPos.y, originalPos.z);
        }
    }
}