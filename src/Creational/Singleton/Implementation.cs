namespace Singleton
{
    /* 
    Singleton Pattern tem como objetivo garantir que apenas 1 instancia do objeto estaja sendo executada,

    Consequencias:
    -Encapsula sua unica instancia
    -Controle sobre quando/como os clientes acessam a instancia
    -Alternativa melhor a váriaveis globais
    -Viola o padrão de responsabilidade única, o objeto é responsavel pela criacao e por
    gerenciar o seu ciclo de vida (desvantagem) 
    */

    public class Logger
    {
        //sempre recomendado inicializacao com LazyLoad para garantir Thread-safe
        private static readonly Lazy<Logger> _lazyLogger =
            new Lazy<Logger>(() => new Logger());

        //private static Logger? _instance;

        public static Logger Instance
        {
            get
            {
                return _lazyLogger.Value;

                //if (_instance is null)
                //    _instance = new Logger();

                //return _instance;
            }
        }

        protected Logger() { }

        //SingletonOperation
        public void Log(string mensagem)
        {
            Console.WriteLine($"Mensagem do log: {mensagem}");
        }
    }
}
