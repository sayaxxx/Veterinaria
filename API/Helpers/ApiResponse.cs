namespace API.Helpers;

public class ApiResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessage(statusCode);
    }

    public ApiResponse()
    {
    }

    private string GetDefaultMessage(int statusCode)
    {
        return statusCode switch
        {
            400 => "PETICION INCORRECTA",
            401 => "USUARIO NO AUTORIZADO",
            404 => "RECURSO INEXISTENTE",
            405 => "METODO NO PERMITIDO",
            500 => "ERROR",
            _ => throw new NotImplementedException()
        };
    }
}
