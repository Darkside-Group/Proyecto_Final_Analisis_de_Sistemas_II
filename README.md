
# UNIVERSIDAD MARIANO GÁLVEZ DE GUATEMALA
## INGENIERÍA EN SISTEMAS DE INFORMACIÓN Y CIENCIAS DE LA COMPUTACIÓN
### ANÁLISIS DE SISTEMAS II

---

# PROYECTO FINAL DE CURSO

---

### GRUPO 5
1. **Pedro José Quiñonez López** - 0902-21-4961
2. **Kristian Josué González Barrientos** - 0902-21-5567
3. **Kevin Esteban Casado Cacao** - 0902-21-10228
4. **Christian Aníbal Elí Cabnal Pereira** - 0902-21-8380

---

**Cobán, Alta Verapaz, Octubre 2024**


# Introducción

## Propósito del documento
El propósito del Documento es la descripción detallada del proceso de desarrollo de una solución para una problemática en base a requerimientos, incluyendo la planificación, desarrollo, implementación y mantenimiento de la aplicación. Este documento pretende servir como guía tanto para el equipo de desarrollo como para los interesados en el proyecto, ofreciendo una visión clara de las tecnologías utilizadas, la arquitectura de la solución, los procesos de despliegue en Azure y los procedimientos de optimización y monitorización. Además, documenta el uso de la metodología Scrum para la gestión del proyecto, detalla el sistema de control de versiones y especifica el enfoque de despliegue continuo y contenerización. Servirá como referencia técnica para el sistema, mejorando el entendimiento y mantenimiento de la aplicación a largo plazo.

## Audiencia
Este documento está dirigido a:
- **Desarrolladores y equipos técnicos** que participen en el desarrollo y mantenimiento de la aplicación, proporcionándoles una guía detallada de las tecnologías e infraestructura.
- **Administradores de sistemas y especialistas en DevOps** responsables de la implementación, contenerización, monitoreo y despliegue en Azure.
- **Líderes de proyecto y Scrum Masters**, quienes requieren una comprensión profunda del marco metodológico aplicado y de los avances realizados según las prácticas de Scrum.
- **Stakeholders o interesados en el negocio**, incluyendo gerentes de producto y patrocinadores del proyecto, para que comprendan las decisiones de diseño y tecnología, así como las ventajas de la infraestructura en términos de escalabilidad, seguridad y mantenimiento.
- **Equipos de soporte y usuarios avanzados** que busquen entender el funcionamiento y capacidades de la aplicación para posibles consultas técnicas o futuras mejoras.

## Definición de Términos
- **Control de Versiones (Git/GitHub):** Sistema que permite gestionar y registrar los cambios realizados en el código fuente de un proyecto, facilitando la colaboración y el seguimiento de versiones. Git es la herramienta de control de versiones, y GitHub es una plataforma de alojamiento que permite a los desarrolladores almacenar y colaborar en sus repositorios de Git.
- **Contenerización (Docker):** Técnica que permite encapsular una aplicación y sus dependencias en un "contenedor", asegurando que funcione de manera consistente en cualquier entorno. Docker es una plataforma de contenerización popular que facilita la portabilidad y el despliegue de aplicaciones.
- **Azure App Services:** Servicio en la nube de Microsoft Azure que permite desplegar y gestionar aplicaciones web, API, y servicios móviles de manera escalable y segura. Ideal para el despliegue de aplicaciones en entornos de producción y pruebas.
- **Metodología Scrum:** Metodología ágil para la gestión de proyectos que se enfoca en entregar valor de manera incremental y en iteraciones cortas llamadas "sprints". Incluye prácticas como reuniones diarias, mantenimiento de un backlog de productos y revisiones constantes para mejorar el desarrollo y adaptarse a los cambios.
- **Despliegue en Producción:** Fase en el ciclo de vida de una aplicación en la que se pone a disposición de los usuarios finales. Involucra configurar el entorno final para que la aplicación esté disponible, así como mantener la infraestructura de manera continua.
- **Monitorización y Optimización:** Proceso de observar el rendimiento de la aplicación y de la infraestructura en tiempo real para identificar y resolver problemas de rendimiento o seguridad. La optimización se refiere a realizar ajustes en el código y en los recursos de infraestructura para mejorar la eficiencia de la aplicación.
- **API (Interfaz de Programación de Aplicaciones):** Conjunto de definiciones y protocolos que permiten a las aplicaciones comunicarse entre sí. Las API permiten el consumo de servicios de manera externa, permitiendo que diferentes aplicaciones intercambien datos y funciones.
- **.NET Core:** Framework de desarrollo de código abierto creado por Microsoft, utilizado para construir aplicaciones modernas y escalables. Soporta múltiples plataformas, lo cual facilita el desarrollo de aplicaciones que pueden ejecutarse en Windows, Linux y macOS.
- **ASP.NET Core:** Framework de aplicaciones web multiplataforma desarrollado sobre .NET Core, utilizado para construir aplicaciones web dinámicas y servicios de API. Es una herramienta clave para desarrollar aplicaciones web modernas, de alto rendimiento y escalables.
- **CORS (Cross-Origin Resource Sharing):** Mecanismo de seguridad que permite controlar quién puede acceder a recursos de un servidor desde un dominio diferente al del servidor. Es importante en el desarrollo de aplicaciones web que interactúan con múltiples servicios externos.
- **JWT (JSON Web Token):** Estándar para la autenticación y autorización, que permite a las aplicaciones y API intercambiar información de manera segura en forma de tokens. Es comúnmente usado para la autenticación de usuarios en aplicaciones web y APIs.
- **HttpClient:** Clase en .NET que permite enviar solicitudes HTTP y recibir respuestas de recursos web. Es utilizada comúnmente en ASP.NET Core para consumir APIs de manera eficiente y controlada.
- **Swagger:** Herramienta que facilita la documentación y prueba de APIs. Swagger proporciona una interfaz visual interactiva donde se pueden probar los endpoints de una API y ver sus especificaciones, lo que facilita el desarrollo y la integración.

# Visión general del Proyecto

## Descripción del Proyecto
- **Proyecto:** Sistema de Gestión para Veterinaria “PetCare”
- **Problemática:** La veterinaria "PetCare" es una clínica veterinaria de gran reputación que atiende a una amplia variedad de mascotas, desde perros y gatos hasta aves y reptiles. La clínica busca mejorar su eficiencia operativa y la calidad de atención al cliente mediante la implementación de un sistema de gestión integral.
- **Descripción de Proyecto:** El proyecto es una solución a la problemática de la veterinaria a cerca de la automatización de procesos y optimización de tiempo. Tiene como objetivo mejorar la gestión de la clínica veterinaria, especializada en el cuidado de una amplia variedad de mascotas. Utilizando SQL Server como sistema de base de datos, se ha creado una plataforma sólida y eficiente que permite organizar y gestionar toda la información relacionada con las mascotas, sus dueños, citas, tratamientos y productos.

## Alcance o Limitaciones del Proyecto
### Alcance:
- **Gestión de datos:** El sistema permite el registro y observación de mascotas, dueños, citas, tratamientos, y productos, ofreciendo una vista extensa del funcionamiento de una veterinaria.
- **Interfaz de usuarios:** Un frontend intuitivo y fácil de comprender mejora la eficiencia de atención al cliente.
- **API:** La comunicación entre el frontend y el consumo de servicios es eficiente, permitiendo la actualización y visualización de datos en tiempo real.
### Limitaciones:
- **Dependencia de la Conectividad:** El funcionamiento depende de una conexión a Internet estable.
- **Capacitación del Personal:** El éxito depende de la capacitación adecuada del personal.
- **Integración con Otros Sistemas:** Limitada por la compatibilidad y las APIs disponibles.
- **Escalabilidad:** Futuras expansiones podrían requerir revisiones significativas.

## Metodología de desarrollo
Para la implementación del proyecto "PetCare", se ha seguido una metodología ágil, adaptándose a los cambios y necesidades emergentes a lo largo del proceso. Las fases incluyen:
- **Planificación:** Definición de objetivos y cronograma.
- **Análisis de Requisitos:** Recopilación detallada de requisitos y priorización de funcionalidades críticas.
- **Diseño:** Creación de la arquitectura del sistema, incluyendo API e interfaz de usuario, empleando el modelo MVC.
- **Despliegue:** Pruebas y correcciones necesarias para el despliegue en producción.

# Requerimientos funcionales

## Granularidad del Sistema (Modularidad)
## Casos de Uso

### Caso de Uso 1: Registro
**Descripción:** Permite a un nuevo usuario registrarse. El usuario proporciona información personal, y la aplicación valida y almacena los datos en la base de datos.

**Actores:** Usuario (nuevo)

**Flujo Principal:**
1. El usuario accede a la página de registro.
2. Completa el formulario y lo envía.
3. La aplicación valida los datos y los envía a la API de registro.
4. La API guarda el usuario y la aplicación muestra una confirmación.

### Caso de Uso 2: Login
**Descripción:** Permite a los usuarios registrados iniciar sesión. La aplicación valida las credenciales y crea una sesión si son correctas.

**Actores:** Usuario (registrado)

**Flujo Principal:**
1. El usuario accede a la página de inicio de sesión.
2. Ingresa su correo electrónico y contraseña y envía el formulario.
3. La aplicación valida las credenciales y envía una solicitud a la API de inicio de sesión.
4. La API verifica las credenciales y devuelve un token de sesión.

### Caso de Uso 3: Gestión
**Descripción:** Permite a los usuarios gestionar los perfiles de sus mascotas. Pueden crear, editar y eliminar perfiles, manteniendo la base de datos actualizada.

**Actores:** Usuario (registrado)

**Flujo Principal:**
1. El usuario accede a la sección de perfiles de mascotas.
2. Puede ver, crear, editar o eliminar perfiles, y cada acción se comunica con la API correspondiente.

## Diagramas UML
- **Diagrama de Casos de Uso:** Identifica las funcionalidades principales del sistema desde la perspectiva del usuario.
- **Diagrama de Clases:** Modela las clases del sistema y sus relaciones.
- **Diagrama de Secuencia:** Modela las interacciones en escenarios específicos.
- **Diagrama de Actividad:** Modela el flujo de trabajo dentro del sistema.
- **Diagrama de Estado:** Modela el ciclo de vida de objetos o clases específicos.
- **Diagrama de Componentes:** Representa los componentes físicos y lógicos del sistema.
- **Diagrama de Despliegue:** Muestra cómo se distribuyen los
## Recursos

### Infraestructura en la nube:
- **Azure App Services**: Para el despliegue y hosting de aplicaciones web y servicios API.
- **SQL Database**: Base de datos relacional de Microsoft para el almacenamiento de datos de la aplicación.
- **Azure DevOps**: Herramienta para gestionar el flujo de trabajo de DevOps, incluyendo pipelines de CI/CD (Integración y Entrega Continua) para despliegue automatizado.

### Control de Versiones:
- **Git y GitHub**: Para el control de versiones del código, colaboración en equipo y gestión de ramas y cambios en el desarrollo del proyecto.

### Herramientas de Contenerización:
- **Docker**: Para crear, administrar y ejecutar contenedores que permiten encapsular el entorno de ejecución de la aplicación, facilitando su despliegue en diferentes entornos (desarrollo, pruebas y producción).

### Frameworks y Lenguajes de Programación:
- **ASP.NET Core**: Framework para el desarrollo de aplicaciones web y APIs, construido sobre .NET Core.
- **C#**: Lenguaje de programación para el desarrollo de la lógica de la aplicación en .NET.
- **JavaScript, HTML y CSS**: Para la interfaz de usuario (si es necesario), especialmente en las vistas y funcionalidades del cliente.

### Herramientas de Autenticación y Seguridad:
- **JWT (JSON Web Tokens)**: Para la autenticación y autorización en el acceso a las APIs.
- **CORS Configuration**: Para manejar el acceso a recursos desde diferentes orígenes de manera segura.

### Gestión de Proyectos:
- **Scrum**: Metodología ágil para la gestión del proyecto, incluyendo backlog, sprints, reuniones diarias y revisiones de sprint.
- **Herramienta de Gestión de Scrum**: Como Azure Boards o Trello, para organizar y visualizar las tareas y el avance del proyecto.

### Herramientas de Documentación:
- **Swagger**: Para documentar y probar los endpoints de la API.
- **Markdown o Word**: Para generar documentación técnica y manuales de usuario, almacenados en un repositorio accesible.
- **Diagramas y Herramientas de Modelado**: Herramientas como Draw.io o Lucidchart pueden ser útiles para diagramas de arquitectura y ERD (Entity-Relationship Diagram).

---

## Implementación del Sistema

### Tecnologías de infraestructura a utilizar

1. **Azure App Services**
   - **Propósito**: Hospedar la aplicación web, facilitando el despliegue y administración del entorno de producción y pruebas.
   - **Beneficios**: Administración simplificada, escalabilidad automática, integración con Azure DevOps para CI/CD, y soporte para múltiples lenguajes y frameworks.

2. **Azure SQL Database**
   - **Propósito**: Servir como la base de datos relacional en la nube para la aplicación.
   - **Beneficios**: Alta disponibilidad, recuperación ante desastres integrada, escalabilidad automática y seguridad avanzada con cifrado de datos y autenticación multifactor.

3. **Docker**
   - **Propósito**: Contenerizar la aplicación y sus dependencias, permitiendo portabilidad y consistencia entre entornos.
   - **Beneficios**: Despliegues simplificados, entorno de desarrollo uniforme, y facilidad para migrar entre entornos de pruebas y producción.

4. **Azure DevOps / GitHub Actions**
   - **Propósito**: Implementar pipelines de CI/CD para automatizar la integración y el despliegue de la aplicación.
   - **Beneficios**: Integración continua, control de versiones, y despliegue automático a entornos de Azure App Services, mejorando la eficiencia y disminuyendo los errores humanos.

5. **Control de Versiones con GitHub**
   - Repositorio: [Proyecto_Final_Analisis_de_Sistemas_II](https://github.com/Darkside-Group/Proyecto_Final_Analisis_de_Sistemas_II.git)

---

## Conclusiones

### Conclusiones
1. **Eficiencia en la Gestión de Datos**: El diseño de la base de datos y la estructura general de la aplicación han permitido una gestión eficiente de los datos, mejorando la capacidad para registrar, consultar y administrar la información de manera ágil. Esto ha facilitado el acceso rápido y seguro a los datos de usuarios, ventas y perfiles de mascotas.
2. **Seguridad y Control de Acceso**: La implementación de roles y permisos ha sido fundamental para asegurar que solo usuarios autorizados puedan realizar determinadas acciones en el sistema.
3. **Tecnologías Implementadas en el Sistema**: La selección de tecnologías y la arquitectura de consumo de APIs desempeñaron un papel crucial en la efectividad y escalabilidad del sistema desarrollado. Al utilizar una arquitectura basada en APIs RESTful, el sistema ha sido capaz de gestionar las interacciones de manera eficiente entre el frontend y el backend, promoviendo una comunicación ligera y rápida que facilita la integración y actualización de funcionalidades. El uso de tecnologías modernas como .NET para el backend y frameworks de frontend dinámico permite que el sistema se adapte a las necesidades de los usuarios, brindando una experiencia rápida y confiable. Además, la adopción de JWT para la gestión de autenticación asegura un control seguro de sesiones y accesos.

### Recomendaciones
1. **Optimizar las Consultas de Base de Datos**: Es recomendable analizar y optimizar las consultas SQL para asegurar tiempos de respuesta óptimos, especialmente en tablas con relaciones de datos. Implementar una mejor estructuración de los registros, así como la seguridad y viabilidad de los datos al momento de guardarse.
2. **Implementación de Seguridad**: Mejorar la implementación de seguridad para el sistema, incluyendo formas de control de ataques para no comprometer la integridad y confidencialidad de los usuarios y datos.
3. **Monitoreo y Mantenimiento Regular**: Realizar un monitoreo continuo del sistema permitirá identificar y resolver problemas de rendimiento antes de que afecten a los usuarios. Además, se recomienda programar mantenimientos regulares para depurar y actualizar el sistema.

