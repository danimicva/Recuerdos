# Recuerdos

El proyecto está empezado un poco pero realmente lo que hay no sirve mucho.

La idea es partir de una carpeta del ordenador y registrar en una BBDD de SQLite todos los ficheros que haya (recuerdos).

## Funcionalidades

El programa debe ejecutarse sobre una carpeta. En esa carpeta creará (si no existe) una base de datos SQLite donde almacenará toda la información.

Funcionalidades básicas:
 - Escanear la carpeta para buscar recuerdos: Debe mirar recursivamente dentro de todas las carpetas en busca de recuerdos que no estén registrados.
 - Revisar los recuerdos que ya existan: Debe recorrer todos los recuerdos registrados para ver si siguen estando en la ruta que indica.
 - Revisar recuerdos pendientes.
 - Consultar respecto a la información: Para esto no sé si directamente SQL o consultas prefabricadas para los asistentes y así.
 - Exportación de la selección: Para poder enviar a la gente sus fotos, se tiene que poder exportar de alguna manera una selección de fotos.
 - Modificar la información sobre los recuerdos
 - Etiquetar a gente desconocida o pendiente de reconocer

## Modelo de datos

Recuerdo: Es la clase que representa una foto, vídeo o lo que sea.

 - Fecha: Puede ser un día concreto, un mes, un año... para poder adaptarse lo mejor posible a la información que se tenga
 - Evento al que pertenece: El evento al que pertenece esa foto. Por ejemplo, si fuera el cumpleaños de alguien. Puede no pertenecer a ningún evento.
 - Personas de la foto: Como las etiquetas de facebook, algo de ese estilo.
 - Lugar: Podrían ser unas coordenadas, el nombre del pueblo, hay que ver opciones para esto.
 - Origen de la foto: Si la foto viene de un álbum, o de quién me la pasó o si es mía del móvil o algo así.
 - Tipo: Imagen, vídeo, otros?
 - Ruta: Ruta relativa a la base de datos donde se encuentra la foto.
 - Pendiente de revisión: Siempre se inicializará a true. Así se puede usar para ir marcando las que ya estén completamente revisadas.
 - Histórico de revisiones: Estaría bien guardar los cambios que se hacen y cuando, así se puede saber qué foto lleva más tiempo sin tocarse aunque esté con algunos datos.
 - Hashtags: Podrá tener varios hastags, como "Para meme", "graciosa", "Foto carnet", etc.
 - Comentarios: 
 - Todos estos atributos tienen que poder guardarse como confirmados o no, para poder indicar cuando algo es intuido o está asegurado.

Evento: Representa un evento en el que hay una o varias fotos
 - Fecha: Igual que en el recuerdo.
 - Personas que asistieron: Las personas que asisten a un evento no tienen por qué ser las mismas que están en las fotos del mismo
 - Lugar: Igual que la foto
 - Un evento puede pertenecer a otro evento (En un viaje, distintas paradas, por ejemplo)
 - Comentarios: 
 - Estos campos también deberán poder guardarse como confirmados o no.

Persona: Para registrar todas las personas que están en las fotos o en un evento
 - Nombre: 
 - Apodo:
 - Fecha de nacimiento?
 - Relaciones con otras personas (hermano de, marido de, padre de, etc.).
 - Comentarios: 
 - Estos campos también deberán poder guardarse como confirmados o no.