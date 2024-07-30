﻿namespace TechChallenge.Application.Response;
public class BaseResponse
{
  public bool Status { get; private set; }
  public object? Data { get; private set; }
  public IEnumerable<string>? Errors { get; private set; } = new List<string>();

  public static BaseResponse Error(IEnumerable<string>? errors = null)
  {
    return new BaseResponse()
    {
      Errors = errors,
      Status = false
    };
  }

  public static BaseResponse Sucsess(object? data = null)
  {
    return new BaseResponse()
    {
      Data = data,
      Status = true
    };
  }
}
