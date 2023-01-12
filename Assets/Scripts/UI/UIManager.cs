using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIManager
    {
        private const float AnimationDuration = 0.25f;
        private const float BounceAmount = 6f;
        
        private readonly TextMeshProUGUI _jumps;
        private readonly TextMeshProUGUI _deaths;
        private readonly TextMeshProUGUI _coins;
        private readonly TextMeshProUGUI _level;
        private readonly TextMeshProUGUI _dashDowns;

        private readonly TextMeshProUGUI _highscore;

        private Vector3 _jumpStartPosition;
        private Vector3 _deathStartPosition;
        private Vector3 _coinsStartPosition;
        private Vector3 _levelStartPosition;
        private Vector3 _dashDownStartPosition;

        public UIManager(
            TextMeshProUGUI highscore,
            TextMeshProUGUI jumps, 
            TextMeshProUGUI deaths, 
            TextMeshProUGUI coins, 
            TextMeshProUGUI level,
            TextMeshProUGUI dashDowns)
        {
            _highscore = highscore;
            _jumps = jumps;
            _deaths = deaths;
            _coins = coins;
            _level = level;
            _dashDowns = dashDowns;

            SetStartPositions();
        }

        public void ShowLatestHighscore()
        {
            //var top10 = LeaderboardsManager.Instance.GetTop10();
            Debug.Log("showing highscore");
            //_highscore.text = "";
            /* foreach (var score in top10.Result)
            {
                _highscore.text += score.PlayerName + ": " + score.Score + "\n";
            }*/
            _highscore.transform.parent.gameObject.SetActive(true);
        }

        public void HideHighscore()
        {
            Debug.Log("hiding highscore");
            _highscore.transform.parent.gameObject.SetActive(false);
        }

        public void UpdateJumps(int i)
        {
            _jumps.text = "" + i;
            //_dashDowns.StartCoroutine(AnimateText(_jumps, _jumpStartPosition));
        }
        
        public void UpdateDeaths(int i)
        {
            _deaths.text = "" + i;
            //_dashDowns.StartCoroutine(AnimateText(_deaths, _deathStartPosition));
        }
        
        public void UpdateCoins(int i)
        {
            _coins.text = "" + i;
            //_dashDowns.StartCoroutine(AnimateText(_coins, _coinsStartPosition));
        }
        
        public void UpdateLevel(int i)
        {
            _level.text = "" + i;
            //_dashDowns.StartCoroutine(AnimateText(_level, _levelStartPosition));
        }
        
        public void UpdateDashDowns(int i)
        {
            _dashDowns.text = "" + i;
            //_dashDowns.StartCoroutine(AnimateText(_dashDowns, _dashDownStartPosition));
        }

        private void SetStartPositions()
        {
            _jumpStartPosition = _jumps.transform.position;
            _deathStartPosition = _deaths.transform.position;
            _coinsStartPosition = _coins.transform.position;
            _levelStartPosition = _level.transform.position;
            _dashDownStartPosition = _dashDowns.transform.position;
        }

        private IEnumerator AnimateText(TextMeshProUGUI textMesh, Vector3 startPosition)
        {
            float elapsedTime = 0f;

            while (elapsedTime < AnimationDuration)
            {
                float yOffset = BounceAmount * Mathf.Sin(Mathf.Clamp01(elapsedTime / AnimationDuration) * Mathf.PI);
                textMesh.transform.position = startPosition + new Vector3(0f, yOffset, 0f);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            textMesh.transform.position = startPosition;
        }
    }
}