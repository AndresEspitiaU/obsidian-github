import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import ReactMarkdown from 'react-markdown';
import { Editor } from '@monaco-editor/react';
import api from '../utils/axios.config';

interface Lesson {
  leccionId: number;
  titulo: string;
  contenidoMarkdown: string;
  codigoEjemplos: string;
}

const LessonPage = () => {
  const { courseId, lessonId } = useParams();
  const [lesson, setLesson] = useState<Lesson | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchLesson = async () => {
      try {
        const response = await api.get(`/cursos/${courseId}/lecciones/${lessonId}`);
        setLesson(response.data);
      } catch (error) {
        console.error('Error fetching lesson:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchLesson();
  }, [courseId, lessonId]);

  if (loading) {
    return <div>Cargando...</div>;
  }

  if (!lesson) {
    return <div>Lección no encontrada</div>;
  }

  return (
    <div className="container mx-auto px-4">
      <div className="bg-white rounded-lg shadow p-6">
        <h1 className="text-3xl font-bold mb-6">{lesson.titulo}</h1>
        
        {/* Contenido de la lección */}
        <div className="prose max-w-none mb-8">
          <ReactMarkdown>{lesson.contenidoMarkdown}</ReactMarkdown>
        </div>

        {/* Editor de código si hay ejemplos */}
        {lesson.codigoEjemplos && (
          <div className="mt-8">
            <h2 className="text-2xl font-bold mb-4">Ejemplos de Código</h2>
            <div className="h-96">
            <Editor
                height="100%"
                language="csharp"
                theme="vs-dark"
                value={lesson.codigoEjemplos}
                options={{
                    readOnly: true,
                    minimap: { enabled: false }
                }}
                />
            </div>
          </div>
        )}

        {/* Navegación entre lecciones */}
        <div className="mt-8 flex justify-between">
          <button className="bg-gray-200 px-4 py-2 rounded">
            Lección Anterior
          </button>
          <button className="bg-blue-600 text-white px-4 py-2 rounded">
            Siguiente Lección
          </button>
        </div>
      </div>
    </div>
  );
};

export default LessonPage;