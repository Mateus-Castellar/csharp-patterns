namespace FactoryMethod
{
    /*
    FactoryMethod permite que uma classe tenha diferentes instanciacoes para subclasses,
    O cliente não ira conhecer nenhuma implementação concreta!

    Consequencias:
    -Desacoplamento de classes
    -Permite adicionar novos tipos de produtos sem quebrar o cliente
    -Principio da responsabilidade unica (SOLID)
    */

    public abstract class DescontoService
    {
        public abstract int PorcentagemDesconto { get; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }

    public class PaisDescontoService : DescontoService
    {
        //somente leitura para nao ser modificado apos a construcao
        private readonly string _paisIdentificador;

        public PaisDescontoService(string paisIdentificador)
        {
            _paisIdentificador = paisIdentificador;
        }

        public override int PorcentagemDesconto
        {
            get
            {
                return _paisIdentificador switch
                {
                    "BR" => 20,
                    "FR" => 18,
                    "US" => 21,
                    _ => 10,
                };
            }
        }
    }

    public class CodigoDescontoService : DescontoService
    {
        //somente leitura para nao ser modificado apos a construcao
        private readonly Guid _codigo;

        public CodigoDescontoService(Guid codigo)
        {
            _codigo = codigo;
        }

        public override int PorcentagemDesconto
        {
            //validacoes deve ser feitas aqui...
            //se o código será unico ou se cada código possuira um valor diferente!
            get => 15;
        }
    }

    public abstract class DescontoFactory
    {
        public abstract DescontoService CriarDiscontoService();
    }

    public class PaisDescontoFactory : DescontoFactory
    {
        private readonly string _paisIdentificador;

        public PaisDescontoFactory(string paisIdentificador)
        {
            _paisIdentificador = paisIdentificador;
        }

        public override DescontoService CriarDiscontoService()
        {
            return new PaisDescontoService(_paisIdentificador);
        }
    }

    public class CodigoDescontoFactory : DescontoFactory
    {
        private readonly Guid _codigo;

        public CodigoDescontoFactory(Guid codigo)
        {
            _codigo = codigo;
        }

        public override DescontoService CriarDiscontoService()
        {
            return new CodigoDescontoService(_codigo);
        }
    }
}