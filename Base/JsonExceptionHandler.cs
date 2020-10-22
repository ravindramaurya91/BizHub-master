using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Base {
    public static class JsonExceptionHandler {

        public static void UseJsonExceptionHandler(this IApplicationBuilder app) {
            var options = new ExceptionHandlerOptions();
            options.ExceptionHandler = Invoke;
            app.UseExceptionHandler(options);

        }

        public static async Task Invoke(HttpContext context) {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null) return;

            var error = new {
                error = ex.Message,
                // stacktrace = ex.StackTrace
            };

            context.Response.ContentType = "application/json";

            using (var writer = new StreamWriter(context.Response.Body)) {
                new JsonSerializer().Serialize(writer, error);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }

    }
}