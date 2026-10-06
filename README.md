# Laboratorio #5 — Problemas Varios (HPA III)

**Materia:** HPA III

**Semestre:** 2do — 3er Año

**Universidad Tecnológica de Panamá**

Repositorio con los ejercicios realizados en **C# y SQL** correspondientes al Laboratorio #5.

---

## Estructura del repositorio

```text
Lab#5-HPA-III/

├── Problema1/                  # Consultas SQL e inyección SQL
├── Problema2/                  # Generación dinámica de sentencias SQL
├── Problema3/                  # Métodos sobrecargados
├── Problema4/                  # Factorial mediante recursividad
├── Problema5/                  # Simulación de lanzamientos de un dado
│
│
└── README.md
```

---

## 1. Problema #1 — Consultas SQL e Inyección SQL

En este problema se realizan diferentes consultas sobre la tabla `productos` con el propósito de observar el comportamiento de distintas técnicas utilizadas en ejemplos de **inyección SQL** y consultas que pueden afectar el comportamiento normal de una aplicación.

### Consulta 1 — WAITFOR DELAY

Se utiliza `WAITFOR DELAY` para provocar un retraso intencional de 15 segundos en la ejecución de la consulta.

```sql
SELECT * 
FROM productos
WHERE id=1 WAITFOR DELAY '00:00:15';
```

### Consulta 2 — Condición siempre verdadera

Se utilizan operadores lógicos para construir una condición que puede resultar verdadera independientemente de determinados valores introducidos.

```sql
SELECT *
FROM productos
WHERE cantidad = '' 
   OR '1'='1' 
   AND id = '' 
   OR '1' = '1';
```

### Consulta 3 — Bypass de autenticación

Se utiliza un comentario SQL para modificar la interpretación del resto de la consulta.

```sql
SELECT * 
FROM productos 
WHERE nombre = 'root'; -- ' AND password = 'mypassword';
```

### Consulta 4 — Inyección mediante condición OR

Se agrega una condición mediante `OR` que altera la condición original de búsqueda.

```sql
SELECT * 
FROM dbo.productos 
WHERE nombre = 'Lapiz' OR '1' != '@unam.mx';
```

**Conceptos:** SQL Server, `SELECT`, `WHERE`, operadores lógicos, comentarios SQL, `WAITFOR DELAY` e inyección SQL.

### Captura de la ejecución en SQL Server Management Studio

<img width="697" height="712" alt="image" src="https://github.com/user-attachments/assets/215cc6fe-0e28-43f1-b667-29be8304edd6" />


---

## 2. Problema #2 — Generación dinámica de cadenas SQL

En este problema se utiliza un `Dictionary<string, object>` para almacenar información relacionada con un inventario y posteriormente generar dinámicamente diferentes partes de una sentencia SQL.

Los datos utilizados son:

```csharp
Dictionary<string, object> datosInventario = new Dictionary<string, object>
{
    { "Nombre", "Laptop HP Envy" },
    { "Precio", 850.99m },
    { "Cantidad", 15 }
};
```

A partir de las claves del diccionario se genera dinámicamente una cláusula `SET`:

```text
Nombre = @Nombre, Precio = @Precio, Cantidad = @Cantidad
```

También se construye una sentencia `INSERT` utilizando parámetros:

```text
INSERT INTO productos (Nombre, Precio, Cantidad) 
VALUES (@Nombre, @Precio, @Cantidad)
```

**Conceptos:** `Dictionary`, colecciones, `List<string>`, ciclos `foreach`, interpolación de cadenas, `string.Join()` y generación dinámica de SQL.

### Ejecución

```bash
cd Problema2
dotnet run
```

### Salida

```text
Cláusula SET generada: Nombre = @Nombre, Precio = @Precio, Cantidad = @Cantidad

la cadena sql es: INSERT INTO productos (Nombre, Precio, Cantidad) VALUES (@Nombre, @Precio, @Cantidad)
```

### Captura de la corrida
<img width="1040" height="116" alt="image" src="https://github.com/user-attachments/assets/3087a567-c207-47e4-9963-3fa9b2ba633f" />


---

## 3. Problema #3 — Métodos sobrecargados

Este problema demuestra el uso de **sobrecarga de métodos** en C#. La clase `SobreCarga` contiene dos métodos llamados `Cuadrado`, pero cada uno recibe un tipo de dato diferente.

### Método para `int`

```csharp
public int Cuadrado(int valorInt)
{
    Console.WriteLine("Se llamó a Cuadrado con argumento int:{0}", valorInt);
    return valorInt * valorInt;
}
```

### Método para `double`

```csharp
public double Cuadrado(double valorDouble)
{
    Console.WriteLine("Se llamó a Cuadrado con argumento double:{0}", valorDouble);
    return valorDouble * valorDouble;
}
```

El compilador determina automáticamente qué método utilizar dependiendo del tipo de argumento enviado.

### Ejecución

```bash
cd Problema3
dotnet run
```

### Salida

```text
Se llamó a Cuadrado con argumento int:7
El cuadrado del integer 7 es 49

Se llamó a Cuadrado con argumento double:7.5
El Cuadrado del double 7.5 es 56.25

Se llamó a Cuadrado con argumento int:8
El cuadrado de 8 es 64

Se llamó a Cuadrado con argumento int:9
El cuadrado de 9 es 81
```

### Captura de la corrida

<img width="1426" height="477" alt="image" src="https://github.com/user-attachments/assets/cdec9562-4eee-48ef-af77-d008899ec39c" />


---

## 4. Problema #4 — Factorial mediante recursividad

En este problema se implementa un método recursivo para calcular el factorial de los números desde `0` hasta `10`.

El método utiliza un **caso base** cuando el número es menor o igual a `1`:

```csharp
if (numero <= 1)
    return 1;
```

Para los demás valores se realiza la llamada recursiva:

```csharp
else
    return numero * Factorial(numero - 1);
```

### Ejecución

```bash
cd Problema4
dotnet run
```

### Salida

```text
0! =1
1! =1
2! =2
3! =6
4! =24
5! =120
6! =720
7! =5040
8! =40320
9! =362880
10! =3628800
```

**Conceptos:** recursividad, métodos, caso base, llamadas recursivas y tipo de dato `long`.

### Captura de la corrida

<img width="1027" height="447" alt="image" src="https://github.com/user-attachments/assets/3d15c0e7-4676-4b14-977a-08d25b698c2c" />


---

## 5. Problema #5 — Simulación de lanzamientos de un dado

Este problema realiza una simulación de **6000 lanzamientos de un dado de seis caras** utilizando la clase `Random`.

Para cada lanzamiento se genera un número aleatorio entre `1` y `6`:

```csharp
cara = numerosAleatorios.Next(1,7);
```

Posteriormente, mediante una estructura `switch`, se incrementa el contador correspondiente a cada cara.

```csharp
switch(cara)
{
    case 1:
        frecuencia1++;
        break;

    case 2:
        frecuencia2++;
        break;

    case 3:
        frecuencia3++;
        break;

    case 4:
        frecuencia4++;
        break;

    case 5:
        frecuencia5++;
        break;

    case 6:
        frecuencia6++;
        break;
}
```

Al finalizar los 6000 lanzamientos, se muestran las frecuencias obtenidas para cada cara.

### Ejecución

```bash
cd Problema5
dotnet run
```

### Salida

La frecuencia de cada cara puede variar en cada ejecución debido a la generación de números aleatorios.

```text
Cara    Frecuencia
1       XXXX
2       XXXX
3       XXXX
4       XXXX
5       XXXX
6       XXXX
```

Los valores deberían ser aproximadamente cercanos a **1000 lanzamientos por cara**, aunque no necesariamente serán exactamente iguales.

**Conceptos:** `Random`, ciclos `for`, `switch`, variables contador, números aleatorios y simulación.

### Captura de la corrida

<img width="777" height="342" alt="image" src="https://github.com/user-attachments/assets/f4f7b455-23e6-4128-b0c2-03c50a2099e0" />


---

## Tecnologías

* **C#**
* **.NET**
* **SQL Server**
* **SQL Server Management Studio (SSMS)**
* **Visual Studio / Visual Studio Code**
* **Git / GitHub**

---

## Conceptos trabajados

Durante el laboratorio se trabajaron diferentes conceptos de programación y bases de datos:

* Consultas SQL.
* Inyección SQL.
* `WAITFOR DELAY`.
* Diccionarios en C#.
* Generación dinámica de cadenas SQL.
* Métodos sobrecargados.
* Recursividad.
* Métodos.
* Ciclos `for`.
* Estructuras `switch`.
* Generación de números aleatorios con `Random`.
* Contadores y frecuencias.

---

## Cómo clonar y ejecutar

Clonar el repositorio:

```bash
git clone https://github.com/<tu-usuario>/Lab5-HPA-III.git
```

Ingresar al directorio:

```bash
cd Lab5-HPA-III
```

Para ejecutar cada proyecto de C#:

```bash
dotnet run --project Problema2
```

```bash
dotnet run --project Problema3
```

```bash
dotnet run --project Problema4
```

```bash
dotnet run --project Problema5
```

Las consultas del **Problema #1** deben ejecutarse desde **SQL Server Management Studio (SSMS)** sobre la base de datos correspondiente.

---

## Evidencias

Las capturas de las ejecuciones de cada problema se encuentran en la carpeta:

```text
images/
```

Cada imagen corresponde a la corrida del problema indicado en el README.

cd "Lab5-HPA-III/Lab#5 Problemas Varios"
dotnet run --project ConsoleApp1
```
