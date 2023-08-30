import React from 'react'
import Footer from '../Footer'
import Slider2 from './Slider2'
import Products from '../product/Products'
import './Home.css';

const Home = () => {



  return (
    <div>

      <header>
        <div className="container">
          <Slider2 />
        </div>
      </header>

      <section>
        <div className="container">
          <Products />
        </div>
      </section>


      <Footer />

    </div>
  )
}

export default Home;
