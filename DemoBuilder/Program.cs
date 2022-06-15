using DemoBuilder.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var toyACreator = new ToyCreator(new ToyABuilder());
    toyACreator.CreateToy();
    var toyA = toyACreator.GetToy();
    Console.WriteLine($"{toyA.Head} {toyA.Body} {toyA.Model} {toyA.Limbs} {toyA.Legs}");
    var toyBCreator = new ToyCreator(new ToyBBuilder());
    toyBCreator.CreateToy();
    var toyB = toyBCreator.GetToy();
    Console.WriteLine($"{toyB.Head} {toyB.Body} {toyB.Model} {toyB.Limbs} {toyB.Legs}");
});

app.Run();
