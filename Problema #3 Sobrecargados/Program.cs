using System;
using SobreCargaMetodos;

// Instancias la clase y ejecutas el método
SobreCarga varSobreCarga = new SobreCarga();
varSobreCarga.ProbarMetodosSobreCargados();

// Imprime pasando '8' como primer parámetro ({0}) y el resultado como segundo ({1})
Console.WriteLine("El cuadrado de {0} es {1}", 8, varSobreCarga.Cuadrado(8));

// Imprime pasando '9' como primer parámetro ({0}) y el resultado como segundo ({1})
Console.WriteLine("El cuadrado de {0} es {1}", 9, varSobreCarga.Cuadrado(9));
