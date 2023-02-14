using System.Net;

namespace ChallengeAlkemy.Middleware
{
    public sealed class ExceptionHandler
    {

        private readonly RequestDelegate nextMiddleware;

        public ExceptionHandler(RequestDelegate nextMiddleware)
        {
            this.nextMiddleware = nextMiddleware;
        }

        /// <summary>
        ///    Procesa el mensaje, atrapando las excepciones generadas.
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await nextMiddleware.Invoke(context);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }

}
