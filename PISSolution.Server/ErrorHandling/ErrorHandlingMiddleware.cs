using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Net;

//middleware to catch all error thrown or not caught

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var statusCode = HttpStatusCode.InternalServerError; 
        var message = "An error occurred while processing your request.";

        switch (exception)
        {
            case ArgumentException argumentException:
                statusCode = HttpStatusCode.BadRequest;
                message = argumentException.Message;
                break;
            case SqlException sqlException:
                statusCode = HttpStatusCode.ServiceUnavailable;
                message = sqlException.Message;
                break; 
                

                // Other specific exceptions can be handled here
        }

        context.Response.StatusCode = (int)statusCode;

        var result = JsonConvert.SerializeObject(new
        {
            status = context.Response.StatusCode,
            error = message
        });

        return context.Response.WriteAsync(result);
    }
}

