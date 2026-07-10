using CodeWorldEducation.Application.Abstraction.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Text;

namespace CodeWorldEducation.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var clientId = _configuration["Gmail:ClientId"]!;
        var clientSecret = _configuration["Gmail:ClientSecret"]!;
        var refreshToken = _configuration["Gmail:RefreshToken"]!;
        var senderEmail = _configuration["Gmail:SenderEmail"]!;

        var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
        {
            ClientSecrets = new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            },
            Scopes = new[] { GmailService.Scope.GmailSend }
        });

        var credential = new UserCredential(flow, "user", new TokenResponse
        {
            RefreshToken = refreshToken
        });

        var gmailService = new GmailService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "CodeWorldEducation"
        });

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("CodeWorldEducation", senderEmail));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;
        message.Body = new TextPart("html") { Text = body };

        var rawMessage = new MemoryStream();
        await message.WriteToAsync(rawMessage);
        var encodedMessage = Convert.ToBase64String(rawMessage.ToArray())
            .Replace('+', '-').Replace('/', '_').Replace("=", "");

        var gmailMessage = new Message { Raw = encodedMessage };
        await gmailService.Users.Messages.Send(gmailMessage, "me").ExecuteAsync();
    }
}