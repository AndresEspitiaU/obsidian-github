import React, { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { Loader, BookOpen, ChevronRight } from 'lucide-react';
import api from '../utils/axios.config';
import { leccionService, Leccion } from '../services/leccion.service';

interface Course {
  id: string;
  title: string;
  description: string;
  // Agrega más campos según sea necesario
}

const CourseDetail = () => {
  const { courseId } = useParams<{ courseId: string }>();
  const [course, setCourse] = useState<Course | null>(null);
  const [lecciones, setLecciones] = useState<Leccion[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCourseData = async () => {
      try {
        setIsLoading(true);
        const [courseData, leccionesData] = await Promise.all([
          api.get(`/courses/${courseId}`),
          leccionService.getLeccionesByCurso(Number(courseId))
        ]);
        
        setCourse(courseData.data);
        setLecciones(leccionesData);
      } catch (err: unknown) {
        if (err instanceof Error) {
          setError(err.message);
        } else {
          setError('Error al cargar el curso');
        }
      } finally {
        setIsLoading(false);
      }
    };

    if (courseId) {
      fetchCourseData();
    }
  }, [courseId]);

  if (isLoading) {
    return (
      <div className="flex justify-center items-center min-h-screen">
        <Loader className="w-8 h-8 animate-spin text-blue-600" />
      </div>
    );
  }

  if (error || !course) {
    return (
      <div className="container mx-auto px-4 py-8">
        <div className="bg-red-50 p-4 rounded-lg text-red-700">
          {error || 'Curso no encontrado'}
        </div>
      </div>
    );
  }

  return (
    <div className="container mx-auto px-4 py-8">
      {/* Header del curso */}
      <div className="bg-white rounded-xl shadow-sm p-8 mb-8">
        <h1 className="text-3xl font-bold mb-4">{course.title}</h1>
        <p className="text-gray-600 mb-6">{course.description}</p>
        <div className="flex items-center gap-4">
         
          <span className="text-gray-500">
            {lecciones.length} lecciones
          </span>
        </div>
      </div>

      {/* Lista de lecciones */}
      <div className="bg-white rounded-xl shadow-sm">
        <div className="p-6 border-b">
          <h2 className="text-xl font-bold">Contenido del curso</h2>
        </div>
        <div className="divide-y">
          {lecciones.map((leccion) => (
            <Link
              key={leccion.leccionId}
              to={`/courses/${courseId}/lessons/${leccion.leccionId}`}
              className="flex items-center justify-between p-6 hover:bg-gray-50"
            >
              <div className="flex items-center gap-4">
                <BookOpen className="w-5 h-5 text-blue-600" />
                <div>
                  <h3 className="font-medium">{leccion.titulo}</h3>
                  <p className="text-sm text-gray-500">{leccion.descripcion}</p>
                </div>
              </div>
              <ChevronRight className="w-5 h-5 text-gray-400" />
            </Link>
          ))}
        </div>
      </div>
    </div>
  );
};

export default CourseDetail;