# Ejemplo Reflection

Este programa está basado en el [Laboratorio-5](https://github.com/ICC3101-201820/Laboratorio-5).

Tal y como vimos en clases, gracias a reflection ahora podemos agregar "plug-ins" al programa lo que permite agregar figuras adicionales.

Por ejemplo, en [este repositorio](https://github.com/ICC3101-201820/ejemplo-reflection-rectangulo) está el código de una solución (librería) que tiene un rectángulo que podemos agregar a las figuras de este programa.

## Cómo probar

### Paso 1) genera archivo .dll con el rectángulo

1. Clona el código del rectángulo ([este repositorio](https://github.com/ICC3101-201820/ejemplo-reflection-rectangulo))
2. Abre la solución en Visual Studio
3. Selecciona la opción "build"

### Paso 2) ejecuta este programa

1. Clona este repositorio y ejecuta el programa
2. Selecciona la opción 2 para importar un plugin
3. Ingresa la ruta del archivo .dll generado en el paso 3 de la sección anterior.

## Cómo agregar un plugin propio

1. Descarga la librería [FiguraBase.dll](https://github.com/ICC3101-201820/ejemplo-reflection/raw/master/Libraries/FiguraBase.dll)
2. Crea un nuevo proyecto
3. Click derecho en "Dependencies", y click en "Add Reference"
4. Busca el archivo FiguraBase.dll recién importado
5. Crea una clase que herede de FiguraBase.Figura
6. Tendrás que implementar el método que Visual Studio te sugiere que implementes
