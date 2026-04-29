using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UGSEntry = Unity.Services.Leaderboards.Models.LeaderboardEntry;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Unity.Services.Leaderboards.Models;

public class LeaderboardManager : MonoBehaviour
{
    [Header("Leaderboard Settings")]
    [SerializeField] private string leaderboardId = "leaderboard";

    [Header("UI References")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject entryPrefab;
    [SerializeField] private Button submitButton;

    private List<LeaderBoardEntry> _spawnedEntries = new();

    private async void Start()
    {
        submitButton.interactable = false;

        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

        submitButton.interactable = true;
        await LoadLeaderboard();
    }

    public async void OnSubmitScore()
    {
        string playerName = PlayerPrefs.GetString("PlayerName","").Trim();
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Player name is empty.");
            return;
        }

        int score = PlayerPrefs.GetInt("Score", 0);
        
        submitButton.interactable = false;

        try
        {
            await AuthenticationService.Instance.UpdatePlayerNameAsync(playerName);
            await LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboardId, score);

            Debug.Log($"Score {score} submitted for {playerName}");
            await LoadLeaderboard();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to submit score: {e.Message}");
        }
        finally
        {
            submitButton.interactable = true;
        }
    }

    private async Task LoadLeaderboard()
    {
        try
        {
            var options = new GetScoresOptions { Limit = 100 };
            LeaderboardScoresPage result =
                await LeaderboardsService.Instance.GetScoresAsync(leaderboardId, options);

            DisplayEntries(result.Results); 
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to load leaderboard: {e.Message}");
        }
    }

    private void DisplayEntries(List<UGSEntry> entries)
    {
        foreach (var entry in _spawnedEntries)
            Destroy(entry.gameObject);
        _spawnedEntries.Clear();

        int rank = 1;
        foreach (var data in entries)
        {
            GameObject entry = Instantiate(entryPrefab, contentParent);
            LeaderBoardEntry localLeaderboardEntry = entry.GetComponent<LeaderBoardEntry>();
            localLeaderboardEntry.SetEntry(rank, data.PlayerName, (int)data.Score);
            _spawnedEntries.Add(localLeaderboardEntry);
            rank++;
        }
    }
}
