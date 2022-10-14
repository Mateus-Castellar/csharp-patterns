using AbstractFactory;

Console.Title = "Abstract Factory";

var brasilCarrinhoComprasFactory = new BrasilCarrinhoComprasFactory();
var carrinhoComprasBrasil = new CarrinhoCompras(brasilCarrinhoComprasFactory);
carrinhoComprasBrasil.CalcularCustos();


var alemanhaCarrinhoComprasFactory = new AlemanhaCarrinhoComprasFactory();
var carrinhoComprasAlemanha = new CarrinhoCompras(alemanhaCarrinhoComprasFactory);
carrinhoComprasAlemanha.CalcularCustos();

Console.ReadKey();