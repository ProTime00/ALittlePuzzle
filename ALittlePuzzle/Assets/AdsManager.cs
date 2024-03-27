using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener, IUnityAdsInitializationListener
    {
#if UNITY_IOS
        private const string GameId = "5430640";
        private const string Ad = "Interstitial_iOS";
        private const string RewardAd = "Rewarded_iOS";
        private const bool TestMode = true;

#elif UNITY_ANDROID
    private const string GameId = "5430641";
    private const string Ad = "Interstitial_Android";
    private const string RewardAd = "Rewarded_Android";
#endif
        public static AdsManager i;
        private void Awake()
        {
            if (i is not null)
            {
                Destroy(gameObject);
            }

            i = this;
            Advertisement.Initialize(GameId, TestMode, this);
            DontDestroyOnLoad(gameObject);
        }
    
        public void LoadAd()
        {
            if (!Advertisement.isInitialized)
            {
                Advertisement.Initialize(GameId, TestMode, this);
                return;
            }
            Advertisement.Load(Ad, this);
        }
        
        
        // This function is intended to be une on a button
        public void LoadRewardedAd(string rewardType)
        {
            if (!Advertisement.isInitialized)
            {
                Advertisement.Initialize(GameId, TestMode, this);
                return;
            }
            if (Advertisement.isInitialized)
            {
                Advertisement.Load(RewardAd, this);
                RewardType = rewardType;
            }
            //launch load animation on button
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Debug.Log("Failed to show" + $"[[{placementId} | {error} | {message}]]");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            //remove the load animation
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            Debug.Log("clicked on the ad");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (showCompletionState == UnityAdsShowCompletionState.COMPLETED && placementId == RewardAd)
            {
                HandleReward(RewardType);
            }
        }

        private string RewardType { get; set; }

        private void HandleReward(string rewardType)
        {
            if (rewardType == "hint")
            {
                PlayerMovement.i.ShowHint();
            }
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            Advertisement.Show(placementId, this);
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
        
            Debug.Log("Failed to load" + $"[[{placementId} | {error} | {message}]]");
        }

        public void OnInitializationComplete()
        {
            Debug.Log("initialization complete");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
        
            Debug.Log("Failed to initialize" + $"[[{error} | {message}]]");
        }
    }
