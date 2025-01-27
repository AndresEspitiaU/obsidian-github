import api from '../utils/axios.config';

export interface Curso {
  cursoId: number;
  categoriaId: number;
  titulo: string;
  descripcion: string;
  nivel: string;
  imagenUrl: string;
  estado: boolean;
  categoria?: string;
}

export const cursoService = {
  // Obtener todos los cursos
  getCursos: async () => {
    const response = await api.get<Curso[]>('/cursos');
    return response.data;
  },

  // Obtener un curso por ID
  getCursoById: async (id: number) => {
    const response = await api.get<Curso>(`/cursos/${id}`);
    return response.data;
  },

  // Obtener cursos por categoría
  getCursosByCategoria: async (categoriaId: number) => {
    const response = await api.get<Curso[]>(`/cursos/categoria/${categoriaId}`);
    return response.data;
  }
};