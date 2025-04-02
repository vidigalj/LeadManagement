using LeadManagement.Domain.Interfaces;

namespace LeadManagement.Infra.Services;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(string to, string subject, string body)
    {
        Console.WriteLine($"Simulating e-mail to: {to}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Body: {body}");
        return Task.CompletedTask;
    }
}
