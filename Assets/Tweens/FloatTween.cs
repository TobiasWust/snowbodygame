using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatTween : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
    // transform.DOLocalMove(new Vector3(0, .1f, 0), 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
  }

  private void OnDestroy() {
    DOTween.Kill(transform);
  }
}
