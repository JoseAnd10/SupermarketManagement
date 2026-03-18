// Esta linea es la que se encarga de configurar y ejecutar la aplicación web.
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Esta línea se encarga de construir la aplicación web utilizando la configuración definida en el builder.
var app = builder.Build();

app.MapStaticAssets();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Iniciamos la aplicación web.
app.Run();

// Esta función se encarga de escribir una respuesta HTML en el contexto HTTP proporcionado.
void WriteHtml(HttpContext context, string html)
{
    // Configuramos el tipo de contenido de la respuesta como HTML y establecemos la longitud del contenido.
    context.Response.ContentType = MediaTypeNames.Text.Html;
    // Calculamos la longitud del contenido HTML en bytes utilizando UTF-8 y la asignamos a la propiedad ContentLength de la respuesta.
    context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
    // Escribimos el contenido HTML en la respuesta utilizando el método WriteAsync del objeto Response.
    context.Response.WriteAsync(html);
}






















/* 
 * Login sin aplicar el modelo MVC y sin usar Razor Pages, lo que hace que el código sea menos organizado y más difícil de mantener
 */
/*

app.MapGet("/", (HttpContext context) =>
{
    WriteHtml(context, $@"
            <!docType html>
            <html>
                <head> <title>miniHTML</title> </head>
                <body>
                    <h1>Simple Framework</h1>
                    <br/>
                    <form action=""/login"" method=""post"">
                        <label for=""username"">Username:</label>
                        <input type=""text"" id=""username"" name=""username"" required>
                        <label for=""password"">Password:</label>
                        <input type=""password"" id=""password"" name=""password"" required>
                        <button type=""submit"" value=""Login"">Login</button>
                    </form>
                </body>
            </html>");
});
  
 
app.MapPost("/login", (HttpContext context) =>
{
    var username = context.Request.Form["username"];
    var password = context.Request.Form["password"];
    if (username == "frank" && password == "password")
    {
        var html = $@"
            <!doctype html>
            <html>
                <head><title>miniHTML</title></head>
                <body>
                    <h1>Simple Framework</h1>
                    <br/>
                    Welcome to our Simple Framework!
                </body>
            </html>";
        WriteHtml(context, html);
    }
    else
    {
        var html = $@"
            <!doctype html>
            <html>
                <head><title>miniHTML</title></head>
                <body>
                    <h1>Simple Framework</h1>
                    <br/>
                    <form action=""/login"" method=""post"">
                        <label for=""username"">Username:</label>
                        <input Type=""text"" id=""username"" name=""username"" required>
                        <label for=""password"">Password:</label>
                        <input type=""text"" id=""password"" name=""password"" required>
                        <button type=""submit"" value=""Login"">Login</button>
                        <br/>
                        <label style=""color:red"">Login failed!</label>
                    </form>       
                </body>
            </html>";
        WriteHtml(context, html);
    }
});
*/

/*
// Esta línea define una ruta para la aplicación web. Cuando se accede a la raíz ("/") de la aplicación, se ejecuta el código dentro del bloque lambda.
app.MapGet("/", (HttpContext context) => {
    // Aquí se define una cadena de texto que contiene el código HTML que se desea enviar como respuesta.
    string html = @"<html><body>
                    <h1>Hello World!</h1>
                    <br/>
                    Welcome to this new world!
                    </body>
                </html>";
    // Llamamos a la función WriteHtml para escribir la respuesta HTML en el contexto HTTP proporcionado.
    WriteHtml(context, html);
});
*/