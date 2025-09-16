using ProjetoLoja.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 1. Configurar os serviços de sessão
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo máximo de inatividade antes da sessão expirar
    options.Cookie.HttpOnly = true; // Garante que o cookie só pode ser acessado pelo servidor (não por scripts no navegador)
    options.Cookie.IsEssential = true; // Define o cookie como essencial para o funcionamento da aplicação
});

// REGISTRAR A CONNECTION STRING COMO UM SERVIÇO STRING AQUI
builder.Services.AddSingleton<string>(builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddScoped<ProdutoRepositorio>();
builder.Services.AddScoped<PedidoRepositorio>();
builder.Services.AddScoped<CarrinhoRepositorio>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseRouting();

    // ESTA LINHA É CRUCIAL E DEVE VIR ANTES DE app.UseAuthorization() ou app.MapControllerRoute() <<<
    app.UseSession();

    app.UseAuthorization();

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}