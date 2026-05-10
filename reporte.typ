// ========================================
// TEMPLATE DOCUMENTO ACADÉMICO EN TYPST
// ========================================

#set text(lang: "es", region: "es")

#set page(
  paper: "a4",
  margin: (x: 3cm, y: 2.5cm),
)

#set text(
  font: "Times New Roman",
  size: 12pt,
)

#set par(
  justify: true,
  leading: 0.8em,
)

#set heading(
  numbering: "1.",
)

#show heading.where(level: 1): it => {
  pagebreak(weak: true)
  set align(left)
  text(weight: "bold", size: 16pt)[#it.body]
  linebreak()
}

// ========================================
// PORTADA (SIN NUMERACIÓN)
// ========================================

#set page(numbering: none)

#align(center)[
  #v(2cm)

  #text(size: 26pt, weight: "bold")[ Arquitectura Software ]

  #v(2cm)

  #text(size: 22pt, weight: "bold")[ Laboratorio 01]

  #v(4cm)

  #text(size: 16pt)[
    Augusto Pedicino Florez \
    Erick Salazar Suarez \
    Felipe Garrido Flores
  ]

  #v(8cm)

  #text(size: 15pt)[
    Pontificia Universidad Javeriana \
    #datetime.today().display()
  ]
]

// ========================================
// INICIO DE NUMERACIÓN
// ========================================

#pagebreak()

#set page(
  numbering: "1",
  number-align: center,
)
// ========================================
// MARCO CONCEPTUAL
// ========================================

= Marco conceptual

El desarrollo de aplicaciones modernas requiere el uso de herramientas y tecnologías que permitan construir sistemas organizados, mantenibles y conectados
con bases de datos. En este laboratorio se implementa una aplicación web utilizando el ecosistema de Microsoft basado en .NET, SQL Server y Entity
Framework Core.

== Tecnologías

=== ASP.NET Core

ASP.NET Core es un framework de desarrollo de aplicaciones web multiplataforma desarrollado por Microsoft. Permite construir aplicaciones web, APIs y
servicios utilizando el lenguaje C\# y el framework .NET.

Entre las principales características de ASP.NET Core se encuentran:

- Desarrollo de aplicaciones web y APIs REST.
- Integración con bases de datos mediante Entity Framework Core.
- Compatibilidad multiplataforma.
- Manejo de rutas, controladores y vistas.

=== Motor de plantillas Razor

Razor es el motor de plantillas (template engine) que usa ASP.NET para generar HTML dinámico desde código C\#. La idea principal de Razor es que en un
mismo archivo *.cshtml* se pueda mezclar:

- HTML
- código C\#
- datos del servidor

Un ejemplo de esto es:

```html
<h1>Hola @Model.Nombre</h1>

@if(Model.Edad >= 18) {
    <p>Es mayor de edad</p>
}
```

=== Entity Framework Core

Entity Framework Core es un ORM (Object Relational Mapper) para .NET. Un ORM permite mapear tablas de bases de datos a clases de programación, facilitando
la interacción entre la aplicación y la base de datos. En lugar de escribir consultas SQL manualmente para todas las operaciones, Entity Framework Core
permite trabajar utilizando objetos y clases en C\#. Las entidades representan las tablas de la base de datos, mientras que el contexto administra la
conexión y las operaciones realizadas sobre dichas entidades.

=== Visual Studio Community 2022

Visual Studio Community 2022 es el entorno de desarrollo (IDE) utilizado para construir la aplicación.

El IDE proporciona herramientas para:

- Edición de código.
- Compilación.
- Depuración.
- Administración de paquetes.
- Integración con Git.
- Diseño y ejecución de proyectos ASP.NET Core.

También permite administrar dependencias mediante *NuGet*.

=== NuGet

NuGet es el administrador de paquetes utilizado en el ecosistema .NET. Permite instalar librerías externas necesarias para el desarrollo de aplicaciones.

Se listan los principales paquetes que se utilizaran para el *laboratorio*:

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

Estos paquetes permiten la integración entre ASP.NET Core y SQL Server mediante *Entity Framework Core*.

// TODO: revisar si falta informacion
=== SQL Server Express

Microsoft SQL Server Express es un sistema de gestión de bases de datos relacional (RDBMS) desarrollado por Microsoft. Se utiliza para almacenar y
administrar la información persistente de la aplicación. Las bases de datos relacionales organizan la información en tablas compuestas por filas y
columnas, permitiendo establecer relaciones entre diferentes conjuntos de datos mediante claves primarias y foráneas.

=== SQL Server Management Studio (SSMS)

SQL Server Management Studio es una herramienta gráfica utilizada para administrar servidores SQL Server. Permite:

- Crear bases de datos.
- Ejecutar scripts SQL.
- Consultar información.
- Administrar usuarios y permisos.
- Diseñar tablas y relaciones.

=== DDL y DML

En bases de datos relacionales, el lenguaje SQL se divide en diferentes categorías según el tipo de operación realizada.

==== DDL (Data Definition Language)

El DDL corresponde a las instrucciones encargadas de definir la estructura de la base de datos. Algunas operaciones comunes son:

- `CREATE`
- `ALTER`
- `DROP`

Estas instrucciones permiten crear tablas, modificar estructuras y eliminar objetos de la base de datos.

==== DML (Data Manipulation Language)

El DML corresponde a las instrucciones utilizadas para manipular la información almacenada. Algunas operaciones comunes son:

- `INSERT`
- `UPDATE`
- `DELETE`
- `SELECT`

Estas instrucciones permiten insertar, consultar y modificar datos dentro de las tablas.

== Patrón Arquitectónico

=== Arquitectura MVC (Modelo-Vista-Controlador)

El laboratorio utiliza el patrón arquitectónico MVC (Model-View-Controller), ampliamente utilizado en aplicaciones web.

Este patrón divide la aplicación en tres componentes principales:

==== Modelo (Model)

El modelo representa la lógica de negocio y el acceso a los datos. El modelo se encarga de interactuar con la base de datos y representar la información
del sistema.

Para el laboratorio se manejaron:

- Entidades generadas con Entity Framework Core.
- Contexto de base de datos.
- Repositorios.
- Interfaces.

==== Vista (View)

La vista corresponde a la interfaz de usuario presentada al usuario final. Su función es mostrar la información proveniente del modelo de manera
organizada.

En aplicaciones ASP.NET Core MVC, las vistas suelen desarrollarse utilizando *Razor*.

==== Controlador (Controller)

El controlador actúa como intermediario entre las vistas y el modelo. El controlador coordina el flujo de la aplicación.

Sus funciones principales son:

- Recibir solicitudes HTTP.
- Procesar peticiones.
- Invocar lógica de negocio.
- Retornar respuestas o vistas.


=== Patrón Repositorio

El laboratorio también utiliza el patrón repositorio, el cual abstrae el acceso a los datos mediante clases especializadas. El objetivo principal es
desacoplar la lógica de negocio de las operaciones de persistencia.

Entre sus ventajas se encuentran:

- Mayor organización del código.
- Reutilización de lógica.
- Facilidad de mantenimiento.
- Separación de responsabilidades.

=== Arquitectura por capas

La aplicación desarrollada utilizando el patrón *MVC* puede entenderse también como un subconjunto o *caso particular* de la *arquitectura por capas*,
donde cada componente cumple responsabilidades especificas y se genera comunicación entre capas adyacentes.

Extrapolando a una arquitectura de capas para el caso especifico del laboratorio, se tiene lo siguiente:

- *Capa de presentación:* Encargada de las vistas y controladores.
- *Capa lógica:* Contiene reglas de negocio y procesamiento.
- *Capa de acceso a datos:* Encargada de la interacción con _SQL Server_ mediante _Entity Framework Core_.
- *Capa de persistencia:* Corresponde a la base de datos _persona_db_.

La separación en capas facilita el mantenimiento y evolución del sistema


// ========================================
// DISEÑO
// ========================================

= Diseño

== Arquitectura

== C4 model

=== Diagrama de contexto

=== Diagrama de contenedores

=== Diagrama de componentes

== Decisiones de diseño


// ========================================
// PROCEDIMIENTO
// ========================================

= Procedimiento

== Repositorio Git/GitHub


- Acceder a la plataforma web GitHub.
#image("01_git_github/01_git_github.png")

- En el dashboard, dar clic en crear un nuevo repositorio.
#image("01_git_github/02_git_github.png")

- En los campos, llenar únicamente el nombre del repositorio con \"personaapi-dotnet\", el resto son opcionales así que se dejan en blanco de momento.
#image("01_git_github/03_git_github.png")

== Instalacion SQL Server 2022 express

*Nota:* Para la instalación de *SQL Server 2022 express* en este laboratorio, se asume que se esta trabajando con un *sistema operativo* Windows 11, si se
tiene una plataforma diferente, los pasos para la instalación pueden llegar a variar.


- Acceder a la plataforma web de SQL Server 2022 express.
#image("02_sql_server_2022_express/01_sql_server_2022_express.png")

- Ejecutar el archivo instalador en Windows.
#image("02_sql_server_2022_express/02_sql_server_2022_express.png")

- Elegir la *opcion \"Basic\"*.
#image("02_sql_server_2022_express/03_sql_server_2022_express.png")

- Aceptar términos y condiciones.
#image("02_sql_server_2022_express/04_sql_server_2022_express.png")

- Usar la *ruta por defecto* para la *instalación* de SQL Server.
#image("02_sql_server_2022_express/05_sql_server_2022_express.png")

- Una vez terminada la instalación dar clic en el *botón \"Close\"*.
#image("02_sql_server_2022_express/06_sql_server_2022_express.png")

== Instalacion SQL Server Management Studio 18

*Nota:* Para la instalación de *SQL Server Management Studio 18* en este laboratorio, se asume que se esta trabajando con un *sistema operativo* Windows
11, si se tiene una plataforma diferente, los pasos para la instalación pueden llegar a variar.

- Acceder a la plataforma web de SQL Server Management Studio 18.
#image("03_sql_server_managment_studio_18/01_sql_server_managment_studio_18.png")

- Ejecutar el archivo instalador en Windows.
#image("03_sql_server_managment_studio_18/02_sql_server_managment_studio_18.png")

- Usar la *ruta por defecto* para la *instalación* de SQL Server Management y dar clic en el *botón \"Install\"*.
#image("03_sql_server_managment_studio_18/03_sql_server_managment_studio_18.png")

- Una vez terminada la instalación dar clic en el *botón \"Close\"*.
#image("03_sql_server_managment_studio_18/04_sql_server_managment_studio_18.png")

== Configuracion de la base de datos y creacion de entidades y relaciones

*Nota:* Una vez completado los pasos anteriores, use el buscador de Windows, pude utilizar las teclas *Win* + *s* y escriba *\"SQL Server Management\"*.
Posteriormente *presione la tecla Enter*. Si tiene otra plataforma, investigue como buscar y ejecutar el programa SQL Server Management Studio.

- Una vez iniciado el programa, generar una conexión y dar *clic derecho en \"Databases\"* y dar *clic en la opción \"New Database\"*.
#image("04_configuracion_db/01_configuracion_db.png")

- En el formulario que se muestra, llenar los campos *Database name* con *\"persona_db\"* y *Owner* con nombre usuario *\"sa\"*. Por ultimo dar clic en
  *botón \"OK\"*.
#image("04_configuracion_db/02_configuracion_db.png")

- Una vez creada la *base de datos \"persona_db\"*, se da *clic derecho sobre \"persona_db\"* en la parte izquierda del *panel \"Object Explorer\"* y se
  selecciona la *opción \"New Query\"*.
#image("04_configuracion_db/03_configuracion_db.png")

- Se va a desplegar una hoja en blanco. En dicha hoja se debe *cargar o pegar* el *contendió del DDL*, todo esto en *sintaxis valida para SQL Server*.
#image("04_configuracion_db/04_configuracion_db.png")

- En la *cinta de opciones*, buscar el botón con *icono* #text(fill: green)[ #sym.gt.tri ] y *texto \"Execute\"*. Una vez encontrado, hacer clic sobre
  dicho botón para *ejecutar el script del DDL*. En la terminal inferior, aparecerá un *mensaje \"Commands completed successfully.\"* el cual confirmara el
  *éxito* de la ejecución *del DDL*.
#image("04_configuracion_db/05_configuracion_db.png")

- Ademas en el *panel \"Object Explorer\"* se puede verificar la *creación de las tablas/entidades* al hacer *clic izquierdo sobre \"persona_db\"* y
  posteriormente hacer *clic izquierdo sobre \"Tables\"*.
#image("04_configuracion_db/06_configuracion_db.png")

== Instalar Visual Studio Community 2022

*Nota:* Para la instalación de *Visual Studio Community 2022* en este laboratorio, se asume que se esta trabajando con un *sistema operativo* Windows 11,
si se tiene una plataforma diferente, los pasos para la instalación pueden llegar a variar.

- Acceder a la plataforma web de Visual Studio Community 2022.
#image("05_instalar_visual_studio_community_2022/01_instalar_visual_studio_community.png")

- Ejecutar el archivo instalador en Windows.
#image("05_instalar_visual_studio_community_2022/02_instalar_visual_studio_community.png")

- Se abrirá el instalador de características.
#image("05_instalar_visual_studio_community_2022/03_instalar_visual_studio_community.png")

- Sobre la pestaña *\"Cargas de trabajo\"*, dentro del apartado *\"Web y nube\"*, buscar y seleccionar la opción *\"Desarrollo de ASP.NET y web\"*.
#image("05_instalar_visual_studio_community_2022/04_instalar_visual_studio_community.png")

- Sobre la pestaña *\"Cargas de trabajo\"*, dentro del apartado *\"Otros conjuntos de herramientas\"*, buscar y seleccionar la opción *\"Almacenamiento y
  procesamiento de datos\"*.
#image("05_instalar_visual_studio_community_2022/05_instalar_visual_studio_community.png")

- Sobre la pestaña *\"Componentes individuales\"*, escribir en el *buscador la palabra \"Caracte\"*, y con el resultado de esta búsqueda, seleccionar
  *\"Características avanzadas de ASP.NET\"* y *\"Plantillas de proyecto y de elemento de .NET Framework\"*. Una vez realizado lo anterior, dar clic en el
  *botón \"Instalar\"*.
#image("05_instalar_visual_studio_community_2022/06_instalar_visual_studio_community.png")

- Esperar a que *termine la instalación*.
#image("05_instalar_visual_studio_community_2022/07_instalar_visual_studio_community.png")

== Proyecto web MVC en .NET con Visual Studio

*Nota:* Una vez completada la instalación de *Visual Studio*, use el buscador de Windows, pude utilizar las teclas *Win* + *s* y escriba *\"Visual
Studio\"*. Posteriormente *presione la tecla Enter*. Si tiene otra plataforma, investigue como buscar y ejecutar el programa Visual Studio.

- Procesa a dar clic izquierdo en el *botón \"Crear un proyecto\"*.
- #text(fill: red)[ *Nota importante:* ] Al configurar el proyecto se debe *deshabilitar configurar HTTPS* y también se debe *deshabilitar autenticación*.
#image("06_visual_studio_proyecto/01_visual_studio_proyecto.png")

- De clic izquierdo en el buscador, y *escriba \"MVC\"*. Seleccione la *opción \"Aplicación web de ASP.NET Core (Modelo-Vista-Controlador)\"*.
#image("06_visual_studio_proyecto/02_visual_studio_proyecto.png")

- Una vez se haya creado el proyecto. En la cinta de opciones dar clic izquierdo en el *apartado \"Ver\"* y posteriormente de clic izquierdo en la *opción
  \"Explorador de objetos de SQL Server\"*.
#image("06_visual_studio_proyecto/03_visual_studio_proyecto.png")

- Conectarse con el *nombre del servidor*, y con el *nombre de la base de datos* que para este laboratorio es *\"persona_db\"*.
#image("06_visual_studio_proyecto/04_visual_studio_proyecto.png")

- En la parte izquierda, dentro del *panel \"Explorador de objetos de SQL Server\"*, se podrá corroborar que se agrego la *nueva conexión de SQL Server*.
#image("06_visual_studio_proyecto/05_visual_studio_proyecto.png")

- Una vez realizada la conexión. En la cinta de opciones dar clic izquierdo en el *apartado \"Herramientas\"*,  posteriormente de clic izquierdo en la
  *opción \"Administrador de paquetes NuGet\"* y por ultimo de clic izquierdo en la *sub-opción \"Consola del Administrador de paquetes\"*.
#image("06_visual_studio_proyecto/06_visual_studio_proyecto.png")

- Se abrirá una *consola* la cual se utiliza para *administrar los paquetes del proyecto*. Si se requiere obtener algo de *documentación* sobre los
  *comandos* disponibles y su manejo, *corra el siguiente comando* en la *consola:*

  #box(
    stroke: 1pt + gray,
    inset: 10pt,
    radius: 2pt,
    fill: rgb("#f5f5f5"),
    [ ```sh get-help NuGet ``` ]
  )
#image("06_visual_studio_proyecto/07_visual_studio_proyecto.png")

- Una vez familiarizado con los comandos básicos, el *comando* que se utilizara para *instalar* los *diferentes paquetes* se *muestra a continuación*
  junto con el *primer paquete a instalar:*

  #box(
    stroke: 1pt + gray,
    inset: 10pt,
    radius: 2pt,
    fill: rgb("#f5f5f5"),
    [ ```sh Install-Package Microsoft.EntityFrameworkCore ``` ]
  )
#image("06_visual_studio_proyecto/08_visual_studio_proyecto.png")

- El *comando* para *instalar* el *segundo paquete* a usar se *muestra a continuación:*

  #box(
    stroke: 1pt + gray,
    inset: 10pt,
    radius: 2pt,
    fill: rgb("#f5f5f5"),
    [ ```sh Install-Package Microsoft.EntityFrameworkCore.SqlServer ``` ]
  )
#image("06_visual_studio_proyecto/09_visual_studio_proyecto.png")

- El *comando* para *instalar* el *tercer paquete* a usar se *muestra a continuación:*

  #box(
    stroke: 1pt + gray,
    inset: 10pt,
    radius: 2pt,
    fill: rgb("#f5f5f5"),
    [ ```sh Install-Package Microsoft.EntityFrameworkCore.Tools ``` ]
  )
#image("06_visual_studio_proyecto/10_visual_studio_proyecto.png")

- Una vez realizada todo la configuración anterior. Ya se puede proceder a *correr el proyecto*. Una vez se de clic izquierdo en el *botón de ejecutar sin
  depurar*, el servicio se podrá *acceder* a través de _#text(fill: blue)[ http://localhost:5097 ]_
#image("06_visual_studio_proyecto/11_visual_studio_proyecto.png")

// ========================================
// CONCLUSIONES
// ========================================

= Conclusiones y lecciones aprendidas


// ========================================
// REFERENCIAS
// ========================================

= Referencias

