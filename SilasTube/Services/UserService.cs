using System.Security.Authentication;
using System.Text.Json;
using Flurl;
using SilasTube.Exceptions;
using SilasTube.Models;
using SilasTube.Utils;

namespace SilasTube.Services;

public interface IUserService
{
    Task LoginAsync();
}

public class UserService : IUserService
{
    private readonly HttpClient _httpClient = new();

    public async Task LoginAsync()
    {
        var authResult = await AuthenticateAsync();
    }


    private async Task<Result<WebAuthenticatorResult>> AuthenticateAsync()
    {
        var queryParams = new
        {
            response_type = "code",
            redirect_uri = Constants.Google.RedirectUri,
            client_id = Constants.Google.ClientId,
            scope = "profile",
            state = "state_parameter_passthrough_value"
        };

        try
        {
            var authResult = await WebAuthenticator.Default.AuthenticateAsync(new WebAuthenticatorOptions
            {
                Url = new Url(Constants.Google.AuthUri).SetQueryParams(queryParams).ToUri(),
                CallbackUrl = new Uri(Constants.Google.RedirectUri)

            });


            return authResult.Properties.TryGetValue("code", out var authCode) 
                ? Result<WebAuthenticatorResult>.Success(authResult)
                : Result<WebAuthenticatorResult>.Failure(new AuthenticationException("User Authentication Failed."));
        }
        catch (TaskCanceledException canceledException)
        {
            return Result<WebAuthenticatorResult>.Failure(canceledException);
        }
        catch (Exception ex)
        {
            return Result<WebAuthenticatorResult>.Failure(ex);
        }
    }

    private async Task<Result<LoginResponse>> ExchangeAuthCodeForTokenAsync(string authCode)
    {
       var formParams = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "client_id", Constants.Google.ClientId },
            { "redirect_uri", Constants.Google.RedirectUri },
            { "code", authCode }
        });

        try
        {
            var tokenResult = await _httpClient.PostAsync(Constants.Google.TokenUri, formParams);

            tokenResult.EnsureSuccessStatusCode();

            await using var stream = await tokenResult.Content.ReadAsStreamAsync();
            var loginResponse = await JsonSerializer.DeserializeAsync<LoginResponse>(stream);

            return loginResponse != null 
                ? Result<LoginResponse>.Success(loginResponse)
                : Result<LoginResponse>.Failure(new AccessTokenRequestException("Access Token request failed."));
        }
        catch (JsonException jsonException)
        {
            return Result<LoginResponse>.Failure(jsonException);
        }

        catch (Exception ex)
        {
            return Result<LoginResponse>.Failure(ex);
        }
    }
}