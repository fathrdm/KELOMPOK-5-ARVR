using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
public class MainSceneManager: MonoBehaviour
{
    [SerializeField] List<AlatMusik> listAudioAlatMusik;
    [SerializeField] List<GameObject> button;
    [SerializeField] GameObject _nameMusic, _textDescribe;
    [SerializeField] float _moveDuration;
    [SerializeField] float _middleY, _bottomY;
    [SerializeField] RectTransform _describeCard, _describeCardBottom;
    private AlatMusik _targetMusic;
    private AlatMusik _targetText;
    private bool _isDescribeInMiddle = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void ActiveMusic(string namamusik)
    {
        foreach (var namaAlat in listAudioAlatMusik)
        {
            namaAlat.audioClip.Stop();
        }

        foreach (var namaAlat in listAudioAlatMusik)
        {
            if (namaAlat.name == namamusik)
            {
                _targetMusic = namaAlat;
                IsDescribeOn();
                break;
            }
        }
    }
    public void UIActive()
    {
        foreach (var btn in button)
        {
            btn.SetActive(true);
        }
    }
    public void UINonActive()
    {
        foreach (var btn in button)
        {
            btn.SetActive(false);
        }
    }

    public void MusicOnTrue()
    {
        if (_targetMusic != null)
        {
            _targetMusic.audioClip.Play();
        }
    }

    public void MusicOnFalse()
    {
        if (_targetMusic != null)
        {
            _targetMusic.audioClip.Stop();
        }
    }

    public void IsDescribeOn()
    {
        if (_targetMusic != null)
        {
            _nameMusic.GetComponent<TMP_Text>().text = _targetMusic.name;
            _textDescribe.GetComponent<TMP_Text>().text = _targetMusic.textDescribe;
        }
    }

    private void DescribeCardMiddle()
    {
        _isDescribeInMiddle = true;
        _describeCard.DOAnchorPosY(_middleY, _moveDuration);
        _describeCardBottom.DOAnchorPosY(_bottomY, _moveDuration);
    }
    private void DescribeCardBottom()
    {
        _describeCard.DOAnchorPosY(_bottomY, _moveDuration).SetUpdate(true);
        _describeCardBottom.DOAnchorPosY(-74, _moveDuration);
        _isDescribeInMiddle = false;
    }

    private void TriggerDescribe()
    {
        if (_describeCard && _describeCardBottom != null && _isDescribeInMiddle)
        {
            DescribeCardBottom();
        }else
            DescribeCardMiddle();
    }

}

[System.Serializable]
public class AlatMusik
{
    public string name;
    public AudioSource audioClip;
    public string textDescribe;
}

