namespace Gym.MiddleWares
{
    public class ShabatMiddleware
    {
        private readonly RequestDelegate _next;
        public ShabatMiddleware(RequestDelegate next)
        {
            _next = next;
        }

         public async Task InvokeAsync(HttpContext context)
        {
            DateTime today = DateTime.Today;
            bool shabat;

            if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                Console.WriteLine("shabat");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                await _next(context);
                Console.WriteLine("no shabat");
                Console.WriteLine(DateTime.Now);
            }
            //if (shabat)
            //{
            //    Console.WriteLine("shabat");
            //    context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //}
            //else
            //{
            //    await _next(context);
            //    Console.WriteLine("no shabat");
            //}
        }
    }
}
