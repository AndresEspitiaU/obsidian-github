
import CourseList from '../components/courses/CourseList';

const Courses = () => {
  return (
    <div className="container mx-auto px-4 py-8">
      <div className="mb-8">
        <h1 className="text-3xl font-bold mb-2">Cursos Disponibles</h1>
        <p className="text-gray-600">
          Explora nuestra colección de cursos y comienza tu viaje de aprendizaje
        </p>
      </div>

      <CourseList />
    </div>
  );
};

export default Courses;