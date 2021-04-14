using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{
    public static PlayfabManager Instance { get;private set;}
    [Header("UI")]
    public TMP_Text messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void RegistorButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password to short";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, RegistorOnSuccess, OnError);
    }
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password= passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest {
            Email = emailInput.text,
            TitleId = "41D4B"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request,OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password Reset";
    }
    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged In";
        SceneManager.LoadScene(1);
    }
    void RegistorOnSuccess(RegisterPlayFabUserResult result) 
    {
        messageText.text = "Register And Login";
        SceneManager.LoadScene(1);
    }
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
    }
}
