import React from 'react'

const Footer = () => {
  return (
    
       <footer id="header">
        <section id="top_header" 
        className="bg-primary py-3 text-white d-none d-md-block">
          <div className="container">
            <div className='row'>
              <div className='col-md-4 pt-2'>
                <h6><i className='bi bi-headset'> +9 0123 456 78 91</i></h6>
              </div>
              <div className='col-md-4 pt-2'>
              <h6><i className='bi bi-envelope'> asdfjkş@hotmail.com</i></h6>
              </div>
              <div className='col-md-4 text-end'>
                <a href='#' className='btn btn-primary text-white'><i className='bi bi-facebook'></i></a>
                <a href='#' className='btn btn-primary text-white'><i className='bi bi-instagram'></i></a>
                <a href='#' className='btn btn-primary text-white'><i className='bi bi-twitter'></i></a>
              </div>
            </div>
          </div>
        </section>
      </footer>
   
  )
}

export default Footer
