import api from '../utils/axios.config';

export interface Leccion {
  leccionId: number;
  cursoId: number;
  titulo: string;
  descripcion: string;
  ordenLeccion: number;
  contenidoMarkdown: string;
  metadatosJson: string;
  codigoEjemplos: string;
}

export const leccionService = {
  getLeccionesByCurso: async (cursoId: number) => {
    const response = await api.get<Leccion[]>(`/lecciones?cursoId=${cursoId}`);
    return response.data;
  },

  getLeccionById: async (leccionId: number) => {
    const response = await api.get<Leccion>(`/lecciones/${leccionId}`);
    return response.data;
  }
};