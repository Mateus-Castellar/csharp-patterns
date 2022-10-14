using FactoryMethod;

Console.Title = "Factory Method";

var factories = new List<DescontoFactory>
{
    new CodigoDescontoFactory(Guid.NewGuid()),
    new PaisDescontoFactory("BR"),
};

foreach (var factory in factories)
{
    var descontoService = factory.CriarDiscontoService();

    Console.WriteLine($"Porcentagem {descontoService.PorcentagemDesconto} vindo de {descontoService}");
    Console.WriteLine("===============================================================================");
}

Console.ReadKey();