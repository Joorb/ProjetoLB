using ProjetoLoja.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 1. Configurar os servi�os de sess�o
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo m�ximo de inatividade antes da sess�o expirar
    options.Cookie.HttpOnly = true; // Garante que o cookie s� pode ser acessado pelo servidor (n�o por scripts no navegador)
    options.Cookie.IsEssential = true; // Define o cookie como essencial para o funcionamento da aplica��o
});

// REGISTRAR A CONNECTION STRING COMO UM SERVI�O STRING AQUI
builder.Services.AddSingleton<string>(builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddScoped<ProdutoRepositorio>();
builder.Services.AddScoped<PedidoRepositorio>();
builder.Services.AddScoped<CarrinhoRepositorio>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseRouting();

    // ESTA LINHA � CRUCIAL E DEVE VIR ANTES DE app.UseAuthorization() ou app.MapControllerRoute() <<<
    app.UseSession();

    app.UseAuthorization();

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}