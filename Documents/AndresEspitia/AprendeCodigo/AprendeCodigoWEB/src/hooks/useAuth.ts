import { useNavigate } from 'react-router-dom';
import { useAuthStore } from '../store/auth.store';
import { authService } from '../services/auth.service';

export const useAuth = () => {
  const navigate = useNavigate();
  const { setAuth, logout } = useAuthStore();

  const login = async (email: string, password: string) => {
    try {
      const response = await authService.login({ email, password });
      setAuth(response.user, response.token);
      navigate('/');
    } catch (error) {
      throw error;
    }
  };

  const register = async (username: string, email: string, password: string) => {
    try {
      const response = await authService.register({ username, email, password });
      setAuth(response.user, response.token);
      navigate('/');
    } catch (error) {
      throw error;
    }
  };

  return { login, register, logout };
};