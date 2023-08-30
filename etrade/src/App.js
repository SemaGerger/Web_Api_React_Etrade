import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

import Admin from './component/admin/Admin';
import About from './component/nav/About';
import Home from './component/home/Home';
import Nav from './component/nav/Nav';
import BasketDetail from './component/basket/BasketDetail';
import LoginCart from './component/user/LoginCart';

function App() {
  return (
    <div>
  <BrowserRouter>
    <Nav />
      <Routes>
        <Route path='/' element={<Home />}></Route>
        <Route path='/home' element={<Home />}></Route>
        <Route path='/admin' element={<Admin />}></Route>
        <Route path='/about' element={<About />}></Route>

        <Route path='/basketDetail' element={<BasketDetail />}></Route>
        <Route path='/loginCart' element={<LoginCart />}></Route>
       
       
      </Routes>
  </BrowserRouter>
    </div>
  );
}

export default App;
