# Instrucciones para GitHub Copilot

Proyecto: SistemaVeterinaria
Lenguaje: C# .NET
Tipo: Aplicación de escritorio (Windows Forms / WPF)

## Convenciones de código
- Usa PascalCase para clases y métodos
- Usa camelCase para variables locales
- Incluye comentarios XML en métodos públicos
- Valida entradas antes de procesar

## Arquitectura
- Sigue el patrón Repository
- Separa la lógica de negocio de la UI
- Usa el mismo estilo de código que en Proyecto_Veterinaria/

## Base de datos
- Valida siempre antes de hacer INSERT o UPDATE
- Maneja excepciones de conexión
