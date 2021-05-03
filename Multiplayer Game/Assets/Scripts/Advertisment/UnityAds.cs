using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    private string gameID = "4114667";
    private string bannerID = "Banner_Android";
    private string interstitialID = "Interstitial_Android";
    private string rewardedVideoID = "Rewarded_Android";
    public bool TestMode;
    public Button showInterstitial;
    public Button watchRewardAd;
    public Text gemsAmt;

    void Start()
    {
        Advertisement.Initialize(gameID, TestMode);
        showInterstitial.interactable = Advertisement.IsReady(interstitialID);
        watchRewardAd.interactable = Advertisement.IsReady(rewardedVideoID);
        Advertisement.AddListener(this);
    }

    public void ShowInterstitial()
    {
        if (Advertisement.IsReady(interstitialID))
        {
            Advertisement.Show(interstitialID);
        }
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(rewardedVideoID);
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsReady(string placementID)
    {
        if (placementID == rewardedVideoID)
        {
            watchRewardAd.interactable = true;
        }

        if (placementID == interstitialID)
        {
            showInterstitial.interactable = true;
        }

        if (placementID == bannerID)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerID);
        }
    }

    public void OnUnityAdsDidFinish(string placementID, ShowResult showResult)
    {
        if (placementID == rewardedVideoID)
        {
            if (showResult == ShowResult.Finished)
            {
                GetReward();
            }
            else if (showResult == ShowResult.Skipped)
            {
                //Do nothing
            }
            else if (showResult == ShowResult.Failed)
            {
                //tell player ads failed
            }
        }
    }


    public void OnUnityAdsDidError(string message)
    {
        //Show or log the error here
    }

    public void OnUnityAdsDidStart(string placementID)
    {
        //Do this if ads starts
    }

    public void GetReward()
    {
        if (PlayerPrefs.HasKey("gems"))
        {
            int gemAmount = PlayerPrefs.GetInt("gems");
            PlayerPrefs.SetInt("gems", gemAmount + 50);
        }
        else
        {
            PlayerPrefs.SetInt("gems", 50);
        }

        gemsAmt.text =  PlayerPrefs.GetInt("gems").ToString();
    }
}