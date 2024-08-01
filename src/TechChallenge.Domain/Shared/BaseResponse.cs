using TechChallenge.Domain.Contracts;
using Flunt.Notifications;

namespace TechChallenge.Domain.Shared;
public class BaseResponse : IResponse

{
  public bool Success { get; set; }
  public string Message { get; set; } = string.Empty;
  public object? Data { get; set; } 
  public IReadOnlyCollection<Notification>? Errors { get; set; }
  public BaseResponse() { }
  public BaseResponse(bool success, string message, object? data)
  {
    Success = success;
    Message = message;
    Data = data;
  }

  public BaseResponse(bool success, IReadOnlyCollection<Notification> errors )
  {
    Success = success;
    Errors = errors;
  }
}
