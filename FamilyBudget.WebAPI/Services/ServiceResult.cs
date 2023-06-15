namespace FamilyBudget.WebAPI.Services;

public class ServiceResult<T>
{
    public bool IsSuccess { get; }
    public T Data { get; }
    public string Message { get; }
    public IEnumerable<string> Errors { get; }

    private ServiceResult(bool success, T data, string message, IEnumerable<string> errors)
    {
        IsSuccess = success;
        Data = data;
        Message = message;
        Errors = errors;
    }

    public static ServiceResult<T> Success(T data, string message = "")
    {
        return new ServiceResult<T>(true, data, message, Enumerable.Empty<string>());
    }

    public static ServiceResult<T> Failure(string errorMessage)
    {
        return new ServiceResult<T>(false, default(T), string.Empty, new[] { errorMessage });
    }

    public static ServiceResult<T> Failure(IEnumerable<string> errors)
    {
        return new ServiceResult<T>(false, default(T), string.Empty, errors);
    }
}