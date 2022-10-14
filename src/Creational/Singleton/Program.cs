using Singleton;

Console.Title = "Singleton Pattern";

//Não é possivel iniciar um nova instancia a qualquer momente devido o ctor protected
//var teste = new Logger();

var instancia1 = Logger.Instance;
var instancia2 = Logger.Instance;

if (instancia1 == instancia2 && instancia2 == Logger.Instance)
{
    Console.WriteLine("As instancias sao identicas!");
}

instancia1.Log($"Mensagem de {nameof(instancia1)}");
instancia1.Log($"Mensagem de {nameof(instancia2)}");
Logger.Instance.Log($"Mensagem de {nameof(Logger.Instance)}");

Console.ReadLine();