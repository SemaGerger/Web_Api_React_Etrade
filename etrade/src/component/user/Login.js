import React, { useState } from 'react';
import axios from 'axios';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [loginStatus, setLoginStatus] = useState('');

  const handleLogin = async () => {
    try {
      const loginData = {
        Email: email,
        Password: password,
      };

      const response = await axios.put('https://localhost:7203/api/User/Login', loginData);

      if (response.data.status) {
        setLoginStatus('Login successful');
      } else {
        setLoginStatus('Email/Password is incorrect or missing.');
      }
    } catch (error) {
      console.error('API request error:', error);
    }
  };

  return (
    <div>
      <h2>Login</h2>
      <input
        type="email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        placeholder="Enter your email"
      />
      <input 
        type="password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        placeholder="Enter your password"
      />
      <button onClick={handleLogin}>Login</button>
      <p>{loginStatus}</p>
    </div>
  );
};

export default Login;
