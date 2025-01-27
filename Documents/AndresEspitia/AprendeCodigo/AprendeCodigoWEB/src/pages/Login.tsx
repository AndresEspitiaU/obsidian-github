import React, { useState } from 'react';
import { BookOpen, Mail, Lock, Loader } from 'lucide-react';
import { Link, useNavigate } from 'react-router-dom';
import api from '../utils/axios.config';
import { useAuthStore } from '../store/auth.store';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const navigate = useNavigate();
  const setAuth = useAuthStore(state => state.setAuth);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setError('');
    
    if (!email || !password) {
      setError('Por favor, completa todos los campos.');
      return;
    }
  
    try {
      setIsLoading(true);
      const response = await api.post('/auth/login', {
        email,
        password
      });
  
      const { token, usuarioId, username, email: userEmail } = response.data;
      
      // Guardar en el store
      setAuth(
        { 
          id: usuarioId,
          username, 
          email: userEmail 
        }, 
        token
      );
      
      // Redireccionar al home
      navigate('/');
    } catch (err: unknown) {
      if (err instanceof Error) {
        setError(err.message);
      } else {
        setError('Error al iniciar sesión');
      }
    } finally {
      setIsLoading(false);
    }
  };

 return (
   <div className="min-h-screen flex items-center justify-center bg-gradient-to-br from-blue-50 to-indigo-100">
     <div className="max-w-md w-full mx-4">
       <div className="bg-white rounded-2xl shadow-xl overflow-hidden">
         {/* Header igual */}
         <div className="px-8 pt-8 pb-6 bg-gradient-to-r from-blue-600 to-indigo-600">
           <div className="flex justify-center mb-6">
             <div className="p-4 bg-white/10 rounded-xl">
               <BookOpen className="w-12 h-12 text-white" />
             </div>
           </div>
           <h2 className="text-center text-3xl font-bold text-white">
             Bienvenido de nuevo
           </h2>
           <p className="text-center text-blue-100 mt-2">
             Accede a tu cuenta para continuar aprendiendo
           </p>
         </div>

         {/* Form */}
         <div className="p-8">
           {error && (
             <div className="mb-6 bg-red-50 border-l-4 border-red-500 p-4 rounded">
               <p className="text-red-700 text-sm">{error}</p>
             </div>
           )}

           <form onSubmit={handleSubmit} className="space-y-6">
             <div className="space-y-2">
               <label className="text-sm font-medium text-gray-700 flex items-center gap-2">
                 <Mail className="w-4 h-4" />
                 Email
               </label>
               <input
                 type="email"
                 value={email}
                 onChange={(e) => setEmail(e.target.value)}
                 className="w-full px-4 py-3 rounded-lg border border-gray-200 focus:border-blue-500 focus:ring-2 focus:ring-blue-500 focus:ring-opacity-20 transition-colors"
                 placeholder="tu@email.com"
               />
             </div>

             <div className="space-y-2">
               <label className="text-sm font-medium text-gray-700 flex items-center gap-2">
                 <Lock className="w-4 h-4" />
                 Contraseña
               </label>
               <input
                 type="password"
                 value={password}
                 onChange={(e) => setPassword(e.target.value)}
                 className="w-full px-4 py-3 rounded-lg border border-gray-200 focus:border-blue-500 focus:ring-2 focus:ring-blue-500 focus:ring-opacity-20 transition-colors"
                 placeholder="••••••••"
               />
             </div>

             <div className="flex items-center justify-between text-sm">
               <label className="flex items-center gap-2 cursor-pointer">
                 <input type="checkbox" className="rounded border-gray-300 text-blue-600 focus:ring-blue-500" />
                 <span className="text-gray-600">Recordarme</span>
               </label>
               <Link to="/forgot-password" className="text-blue-600 hover:text-blue-500 font-medium">
                 ¿Olvidaste tu contraseña?
               </Link>
             </div>

             <button
               type="submit"
               disabled={isLoading}
               className="w-full bg-gradient-to-r from-blue-600 to-indigo-600 text-white py-3 px-4 rounded-lg font-medium hover:from-blue-700 hover:to-indigo-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transition-all disabled:opacity-50 flex items-center justify-center gap-2"
             >
               {isLoading ? (
                 <>
                   <Loader className="w-5 h-5 animate-spin" />
                   Iniciando sesión...
                 </>
               ) : (
                 'Iniciar Sesión'
               )}
             </button>
           </form>

           <div className="mt-8 text-center">
             <p className="text-gray-600">
               ¿No tienes una cuenta?{' '}
               <Link to="/register" className="text-blue-600 hover:text-blue-500 font-medium">
                 Regístrate gratis
               </Link>
             </p>
           </div>
         </div>
       </div>

       <p className="text-center text-gray-600 text-sm mt-6">
         © 2025 Tu Plataforma de Aprendizaje. Todos los derechos reservados.
       </p>
     </div>
   </div>
 );
};

export default Login;