import CourseCard from './CourseCard';
import { Loader } from 'lucide-react';
import { useCursos } from '../../hooks/useCourses';

const CourseList = () => {
  const { cursos, loading, error } = useCursos();

  if (loading) {
    return (
      <div className="flex items-center justify-center min-h-[400px]">
        <Loader className="w-8 h-8 animate-spin text-blue-600" />
      </div>
    );
  }

  if (error) {
    return (
      <div className="bg-red-50 p-4 rounded-lg text-red-800">
        {error}
      </div>
    );
  }

  if (!cursos.length) {
    return (
      <div className="text-center py-12">
        <p className="text-gray-600">No hay cursos disponibles</p>
      </div>
    );
  }

  return (
    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      {cursos.map((curso) => (
        <CourseCard key={curso.cursoId} curso={curso} />
      ))}
    </div>
  );
};

export default CourseList;