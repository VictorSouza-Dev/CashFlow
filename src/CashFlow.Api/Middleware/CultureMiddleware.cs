using System.Globalization;

namespace CashFlow.Api.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    public CultureMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context)
    {

        var suppotedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureInfo = new CultureInfo("pt-BR");

        if (!string.IsNullOrEmpty(requestCulture) 
            && suppotedLanguages.Exists(L => L.Name.Equals(requestCulture)))
        {
            cultureInfo = new CultureInfo(requestCulture);
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}
