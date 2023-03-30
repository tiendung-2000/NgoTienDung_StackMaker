using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using API.UI;

public class LoadingUI : BaseUIMenu
{
    public Image progress;

    Action OnLoaded;

    public override void Init(object[] initParams)
    {
        base.Init(initParams);
        OnLoaded = null;
        if (initParams != null)
        {
            if (initParams.Length > 0)
            {
                OnLoaded = (Action)initParams[0];
            }
        }
        LoadingRun();
    }
    public void LoadingRun()
    {
        progress.fillAmount = 0;
        progress.DOFillAmount(1f, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            //OnLoaded?.Invoke();
            //OnLoaded = null;
            Close();
            CanvasManager.Ins.OpenUI(UIName.GameplayUI, null);
        });
    }
}
