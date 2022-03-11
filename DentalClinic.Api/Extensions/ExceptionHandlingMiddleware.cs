using Microsoft.AspNetCore.Diagnostics;
namespace DentalClinic.Api.Extensions {
    public static class ExceptionHandlingMiddleware {
        public static void UseExceptionHandling(this IApplicationBuilder app) {
            app.UseExceptionHandler(o => o.Run(async context => {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
                using (StreamWriter sw = System.IO.File.AppendText("DetalClinic_LogFile.txt")) {
                    await sw.WriteLineAsync("-----------------------------------| Exception Log Start |-----------------------------------");
                    await sw.WriteLineAsync($"Exception Occured at : {DateTime.Now.ToString()}");
                    await sw.WriteLineAsync($"Exception Message: {exception?.Message}");
                    await sw.WriteLineAsync($"Inner Exception: {exception?.InnerException}");
                    await sw.WriteLineAsync($"Stack Trace: {exception?.StackTrace}");
                    await sw.WriteLineAsync("------------------------------------| Exception Log End |------------------------------------");
                }
            }));
        }
    }
}
