namespace AbstractFactory
{
    //Abstract Factory
    public interface ICarrinhoDeCompraFactory
    {
        IDescontoService CriarDescontoService();
        IFreteService CriarFreteService();
    }

    //Abstract Product
    public interface IDescontoService
    {
        int DescontoPorcentagem { get; }
    }

    //Concret Product
    public class BrasilDescontoService : IDescontoService
    {
        public int DescontoPorcentagem => 20;
    }

    //Concret Product
    public class AlemanhaDescontoService : IDescontoService
    {
        public int DescontoPorcentagem => 10;
    }

    //Abstract Product
    public interface IFreteService
    {
        decimal CustosEnvio { get; }
    }

    //Concret Product
    public class BrasilFreteService : IFreteService
    {
        public decimal CustosEnvio => 45;
    }

    //Concret Product
    public class AlemanhaFreteService : IFreteService
    {
        public decimal CustosEnvio => 98;
    }

    //Concret Factory
    public class BrasilCarrinhoComprasFactory : ICarrinhoDeCompraFactory
    {
        public IDescontoService CriarDescontoService()
        {
            return new BrasilDescontoService();
        }

        public IFreteService CriarFreteService()
        {
            return new BrasilFreteService();
        }
    }

    //Concret Factory
    public class AlemanhaCarrinhoComprasFactory : ICarrinhoDeCompraFactory
    {
        public IDescontoService CriarDescontoService()
        {
            return new AlemanhaDescontoService();
        }

        public IFreteService CriarFreteService()
        {
            return new AlemanhaFreteService();
        }
    }

    //Client class
    public class CarrinhoCompras
    {
        private readonly IDescontoService _descontoService;
        private readonly IFreteService _freteService;
        private int _custosPedido;

        public CarrinhoCompras(ICarrinhoDeCompraFactory factory)
        {
            _descontoService = factory.CriarDescontoService();
            _freteService = factory.CriarFreteService();
            _custosPedido = 200;
        }

        public void CalcularCustos()
        {
            Console.WriteLine($"Total = {_custosPedido - (_custosPedido / 100 * _descontoService.DescontoPorcentagem)
                + _freteService.CustosEnvio}");
        }
    }
}