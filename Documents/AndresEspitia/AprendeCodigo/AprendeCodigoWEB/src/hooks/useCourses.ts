import { useState, useEffect } from 'react';
import { Curso, cursoService } from '../services/courses.service';


export const useCursos = () => {
  const [cursos, setCursos] = useState<Curso[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const fetchCursos = async () => {
    try {
      setLoading(true);
      const data = await cursoService.getCursos();
      setCursos(data);
      setError(null);
    } catch (err) {
      setError('Error al cargar los cursos');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchCursos();
  }, []);

  return { cursos, loading, error, refetch: fetchCursos };
};