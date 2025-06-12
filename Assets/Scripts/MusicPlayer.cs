using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MusicPlayerVuforia10 : MonoBehaviour
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
    public void musikapayangdimainkan(string namamusik)
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
                isDescribeOn();
                break;
            }
        }
    }
    public void buttonActive()
    {
        foreach (var btn in button)
        {
            btn.SetActive(true);
        }
    }
    public void buttonNonActive()
    {
        foreach (var btn in button)
        {
            btn.SetActive(false);
        }
    }

    public void isMusicOnTrue()
    {
        if (_targetMusic != null)
        {
            _targetMusic.audioClip.Play();
        }
    }

    public void isMusicOnFalse()
    {
        if (_targetMusic != null)
        {
            _targetMusic.audioClip.Stop();
        }
    }

    public void isDescribeOn()
    {
        if (_targetMusic != null)
        {
            _nameMusic.GetComponent<TMP_Text>().text = _targetMusic.name;
            _textDescribe.GetComponent<TMP_Text>().text = _targetMusic.textDescribe;
        }
    }

    public void DescribeCardMiddle()
    {
        _isDescribeInMiddle = true;
        _describeCard.DOAnchorPosY(_middleY, _moveDuration);
        _describeCardBottom.DOAnchorPosY(_bottomY, _moveDuration);
    }
    public void DescribeCardBottom()
    {
        _describeCard.DOAnchorPosY(_bottomY, _moveDuration).SetUpdate(true);
        _describeCardBottom.DOAnchorPosY(-74, _moveDuration);
        _isDescribeInMiddle = false;
    }

    public void TriggerDescribe()
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

