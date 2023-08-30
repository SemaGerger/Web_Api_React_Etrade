import React from 'react'
import Login from './Login'
import Register from './Register'

const LoginCart = () => {
    return (
      <>
      <h2 className='container d-flex justify-content-center'> Hoşgeldiniz</h2>
        <div className='container d-flex justify-content-center align-items-center bg-body-tertiary' >
        
        <div className='card ratio ratio-1x1 d-inline p-2 '>
          <Register />
        </div>
      
        <div className='card ratio ratio-1x1 d-inline p-2 '>
          <Login />
        </div>
      </div>
      </>
    )
}

export default LoginCart
