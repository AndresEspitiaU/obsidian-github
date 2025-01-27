import React from 'react';
import { Link } from 'react-router-dom';
import { Curso } from '../../services/courses.service';


interface CourseCardProps {
  curso: Curso;
}

const CourseCard: React.FC<CourseCardProps> = ({ curso }) => {
  return (
    <div className="bg-white rounded-xl shadow-md overflow-hidden hover:shadow-lg transition-shadow">
      <div className="h-48 overflow-hidden">
        <img 
          src={curso.imagenUrl || '/placeholder-course.jpg'} 
          alt={curso.titulo}
          className="w-full h-full object-cover"
        />
      </div>
      
      <div className="p-6">
        <div className="flex items-center gap-2 mb-2">
          <span className="px-3 py-1 text-xs font-semibold bg-blue-100 text-blue-800 rounded-full">
            {curso.nivel}
          </span>
          {curso.categoria && (
            <span className="px-3 py-1 text-xs font-semibold bg-gray-100 text-gray-800 rounded-full">
              {curso.categoria}
            </span>
          )}
        </div>

        <h3 className="text-xl font-bold mb-2">{curso.titulo}</h3>
        <p className="text-gray-600 text-sm mb-4 line-clamp-2">
          {curso.descripcion}
        </p>

        <div className="flex items-center justify-between mt-4">
        <Link 
          to={`/courses/${curso.cursoId}`}
          className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors"
        >
          Ver curso
        </Link>
        </div>
      </div>
    </div>
  );
};

export default CourseCard;