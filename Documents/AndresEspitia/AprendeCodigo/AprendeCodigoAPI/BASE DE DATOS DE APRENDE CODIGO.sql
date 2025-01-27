CREATE DATABASE AprendeCodigo

USE AprendeCodigo

-- Usuarios del sistema
CREATE TABLE Usuarios (
   UsuarioId INT PRIMARY KEY IDENTITY(1,1),
   Username NVARCHAR(50) UNIQUE,
   Email NVARCHAR(100) UNIQUE NOT NULL,
   Password NVARCHAR(255) NOT NULL,
   HashPassword NVARCHAR(512),
   FechaRegistro DATETIME DEFAULT GETDATE()
)

-- Categorías de cursos
CREATE TABLE CategoriasCurso (
   CategoriaId INT PRIMARY KEY IDENTITY(1,1),
   Nombre NVARCHAR(100) NOT NULL,
   Descripcion NVARCHAR(MAX)
)

-- Cursos disponibles
CREATE TABLE Cursos (
   CursoId INT PRIMARY KEY IDENTITY(1,1),
   CategoriaId INT FOREIGN KEY REFERENCES CategoriasCurso(CategoriaId),
   Titulo NVARCHAR(100) NOT NULL,
   Descripcion NVARCHAR(MAX),
   Nivel NVARCHAR(20),
   ImagenURL NVARCHAR(500),
   Estado BIT DEFAULT 1
)

-- Tags para lecciones
CREATE TABLE Tags (
   TagId INT PRIMARY KEY IDENTITY(1,1),
   Nombre NVARCHAR(50) UNIQUE
)

-- Lecciones de cada curso
CREATE TABLE Lecciones (
   LeccionId INT PRIMARY KEY IDENTITY(1,1),
   CursoId INT FOREIGN KEY REFERENCES Cursos(CursoId),
   Titulo NVARCHAR(100) NOT NULL,
   Descripcion NVARCHAR(MAX),
   OrdenLeccion INT NOT NULL,
   ContenidoMarkdown NVARCHAR(MAX),
   MetadatosJSON NVARCHAR(MAX),
   CodigoEjemplos NVARCHAR(MAX)
)

-- Relación Lecciones-Tags
CREATE TABLE LeccionesTags (
   LeccionId INT FOREIGN KEY REFERENCES Lecciones(LeccionId),
   TagId INT FOREIGN KEY REFERENCES Tags(TagId),
   PRIMARY KEY (LeccionId, TagId)
)

-- Recursos de lección
CREATE TABLE RecursosLeccion (
   RecursoId INT PRIMARY KEY IDENTITY(1,1),
   LeccionId INT FOREIGN KEY REFERENCES Lecciones(LeccionId),
   Tipo NVARCHAR(50),
   Titulo NVARCHAR(100),
   URL NVARCHAR(500),
   Descripcion NVARCHAR(MAX)
)

-- Tipos de ejercicios
CREATE TABLE TiposEjercicio (
   TipoEjercicioId INT PRIMARY KEY IDENTITY(1,1),
   Nombre NVARCHAR(50) NOT NULL,
   Descripcion NVARCHAR(MAX)
)

-- Ejercicios
CREATE TABLE Ejercicios (
   EjercicioId INT PRIMARY KEY IDENTITY(1,1),
   LeccionId INT FOREIGN KEY REFERENCES Lecciones(LeccionId),
   TipoEjercicioId INT FOREIGN KEY REFERENCES TiposEjercicio(TipoEjercicioId),
   Titulo NVARCHAR(100),
   Instrucciones NVARCHAR(MAX),
   ConfiguracionJSON NVARCHAR(MAX),
   SolucionJSON NVARCHAR(MAX)
)

-- Inscripción a cursos
CREATE TABLE UsuariosCursos (
   UsuarioId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
   CursoId INT FOREIGN KEY REFERENCES Cursos(CursoId),
   FechaInscripcion DATETIME DEFAULT GETDATE(),
   FechaCompletado DATETIME,
   ProgresoTotal DECIMAL(5,2) DEFAULT 0,
   Estado NVARCHAR(20) DEFAULT 'Inscrito',
   PRIMARY KEY (UsuarioId, CursoId)
)

-- Progreso en lecciones
CREATE TABLE ProgresoLecciones (
   UsuarioId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
   LeccionId INT FOREIGN KEY REFERENCES Lecciones(LeccionId),
   Estado NVARCHAR(20) DEFAULT 'No iniciado',
   FechaInicio DATETIME,
   FechaCompletado DATETIME,
   PRIMARY KEY (UsuarioId, LeccionId)
)

-- Intentos ejercicios
CREATE TABLE IntentosEjercicio (
   IntentoId INT PRIMARY KEY IDENTITY(1,1),
   UsuarioId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
   EjercicioId INT FOREIGN KEY REFERENCES Ejercicios(EjercicioId),
   FechaIntento DATETIME DEFAULT GETDATE(),
   RespuestaJSON NVARCHAR(MAX),
   EsCorrecta BIT,
   TiempoCompletado INT
)

-- Comentarios de lecciones
CREATE TABLE ComentariosLeccion (
   ComentarioId INT PRIMARY KEY IDENTITY(1,1),
   LeccionId INT FOREIGN KEY REFERENCES Lecciones(LeccionId),
   UsuarioId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
   Contenido NVARCHAR(MAX),
   FechaCreacion DATETIME DEFAULT GETDATE(),
   ParentId INT FOREIGN KEY REFERENCES ComentariosLeccion(ComentarioId),
   Likes INT DEFAULT 0
)

-- Likes de comentarios
CREATE TABLE LikesComentario (
   UsuarioId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
   ComentarioId INT FOREIGN KEY REFERENCES ComentariosLeccion(ComentarioId),
   PRIMARY KEY (UsuarioId, ComentarioId)
)