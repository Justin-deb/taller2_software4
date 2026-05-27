import './App.css'
import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider } from 'react-router-dom'
import ProductPage from './pages/ProductPage';
import UserPage from './pages/UserPage';
import { HomePage } from './pages/HomePage';

function App() {
  const routes = createBrowserRouter(createRoutesFromElements(
    <>
      <Route path='/' element={<HomePage/>}/>
      <Route path='/products' element={<ProductPage/>}/>
      <Route path='/users' element={<UserPage/>}/>
    </>
  ));

  return (
    <RouterProvider router={routes}/>
  );
}

export default App
