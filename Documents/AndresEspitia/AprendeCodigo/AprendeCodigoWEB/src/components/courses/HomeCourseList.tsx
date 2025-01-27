// src/components/courses/HomeCourseList.tsx

import { Link } from 'react-router-dom';

import { Loader } from 'lucide-react';
import { useCursos } from '../../hooks/useCourses';

const HomeCourseList = () => {
  const { cursos, loading, error } = useCursos();

  if (loading) {
    return <Loader className="w-6 h-6 animate-spin text-blue-600" />;
  }

  if (error) {
    return <p className="text-red-600">Error al cargar los cursos</p>;
  }

  return (
    <div className="space-y-4">
      {cursos.slice(0, 3).map((curso) => (
        <div key={curso.cursoId} className="p-4 border rounded-lg hover:bg-gray-50">
          <div className="flex justify-between items-center">
            <div>
              <h3 className="font-semibold">{curso.titulo}</h3>
              <p className="text-sm text-gray-600">{curso.nivel}</p>
            </div>
            <Link 
              to={`/courses/${curso.cursoId}`}
              className="text-blue-600 hover:text-blue-700"
            >
              Ver curso →
            </Link>
          </div>
        </div>
      ))}
    </div>
  );
};

export default HomeCourseList;