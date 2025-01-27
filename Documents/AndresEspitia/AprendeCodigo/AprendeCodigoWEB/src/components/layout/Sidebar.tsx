import { Link } from 'react-router-dom';

const Sidebar = () => {
  return (
    <aside className="w-64 bg-white shadow h-screen">
      <div className="p-4">
        <nav className="space-y-2">
          <Link 
            to="/" 
            className="block px-4 py-2 rounded hover:bg-gray-100"
          >
            Inicio
          </Link>
          <Link 
            to="/courses" 
            className="block px-4 py-2 rounded hover:bg-gray-100"
          >
            Cursos
          </Link>
        </nav>
      </div>
    </aside>
  );
};

export default Sidebar;