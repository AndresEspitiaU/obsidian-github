import { Link } from 'react-router-dom';
import { useAuthStore } from '../store/auth.store';
import { BookOpen, Award, Clock, Activity } from 'lucide-react';
import HomeCourseList from '../components/courses/HomeCourseList';

const Home = () => {
 const user = useAuthStore(state => state.user);

 return (
   <div className="min-h-screen bg-gray-50">
     <div className="container mx-auto px-4 py-8">
       {/* Header Section */}
       <div className="bg-gradient-to-r from-blue-600 to-indigo-600 rounded-2xl p-8 mb-8 text-white">
         <h1 className="text-4xl font-bold mb-2">
           ¡Bienvenido, {user?.username}!
         </h1>
         <p className="text-blue-100">
           Continúa tu viaje de aprendizaje
         </p>
       </div>

       {/* Stats Grid */}
       <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-8">
         <div className="bg-white p-6 rounded-xl shadow-sm">
           <div className="flex items-center gap-4">
             <div className="p-3 bg-blue-100 rounded-lg">
               <BookOpen className="w-6 h-6 text-blue-600" />
             </div>
             <div>
               <p className="text-gray-600">Cursos Activos</p>
               <h3 className="text-2xl font-bold">3</h3>
             </div>
           </div>
         </div>
         
         <div className="bg-white p-6 rounded-xl shadow-sm">
           <div className="flex items-center gap-4">
             <div className="p-3 bg-green-100 rounded-lg">
               <Award className="w-6 h-6 text-green-600" />
             </div>
             <div>
               <p className="text-gray-600">Cursos Completados</p>
               <h3 className="text-2xl font-bold">2</h3>
             </div>
           </div>
         </div>

         <div className="bg-white p-6 rounded-xl shadow-sm">
           <div className="flex items-center gap-4">
             <div className="p-3 bg-purple-100 rounded-lg">
               <Clock className="w-6 h-6 text-purple-600" />
             </div>
             <div>
               <p className="text-gray-600">Horas de Estudio</p>
               <h3 className="text-2xl font-bold">24h</h3>
             </div>
           </div>
         </div>
       </div>

       {/* Main Content Grid */}
       <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
         {/* Cursos en Progreso */}
         <div className="bg-white p-6 rounded-xl shadow-sm">
           <div className="flex items-center justify-between mb-6">
             <h2 className="text-xl font-bold">Mis Cursos</h2>
             <Link 
               to="/courses" 
               className="text-blue-600 hover:text-blue-700 font-medium"
             >
               Ver todos →
             </Link>
           </div>
           <HomeCourseList />
         </div>

         {/* Actividad Reciente */}
         <div className="bg-white p-6 rounded-xl shadow-sm">
           <div className="flex items-center gap-2 mb-6">
             <Activity className="w-5 h-5 text-blue-600" />
             <h2 className="text-xl font-bold">Actividad Reciente</h2>
           </div>
           <div className="space-y-4">
             {/* Timeline de actividad */}
             <div className="flex gap-4">
               <div className="w-2 h-2 mt-2 rounded-full bg-blue-600"></div>
               <div>
                 <p className="font-medium">Completaste la lección "Variables"</p>
                 <p className="text-sm text-gray-600">Hace 2 horas</p>
               </div>
             </div>
             <div className="flex gap-4">
               <div className="w-2 h-2 mt-2 rounded-full bg-green-600"></div>
               <div>
                 <p className="font-medium">Obtuviste una insignia</p>
                 <p className="text-sm text-gray-600">Ayer</p>
               </div>
             </div>
           </div>
         </div>
       </div>
     </div>
   </div>
 );
};

export default Home;