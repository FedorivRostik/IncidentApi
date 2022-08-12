using Core.Exceptions;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Host.Middleware
{
    public class ExceptionMiddleware
    {
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private readonly RequestDelegate _next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (DivideByZeroException ex)
            {


                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (HttpRequestException ex)
            {


                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }

            catch (DbUpdateConcurrencyException ex)
            {

                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }

            catch (DbUpdateException ex)
            {


                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    $"{ex.Message}. Path:{context.Request.Path}.");
            }

            catch (RouteCreationException ex)
            {


                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }

            catch (KeyNotFoundException ex)
            {

                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (WebException ex)
            {


                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                   $"{ex.Message}. Path:{context.Request.Path}.");

            }
        }



        private Task HandleExceptionAsync(HttpContext context, HttpStatusCode errorCode, string errorMessage)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorCode;
            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = errorMessage
            }.ToString());
        }
    }
}
