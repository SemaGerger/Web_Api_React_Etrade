
 import React, { useState } from 'react';
 import axios from 'axios';
 const Register = () => {
   const [email, setEmail] = useState('');
   const [name, setName] = useState('');
   const [surname, setSurname] = useState('');
   const [password, setPassword] = useState('');
   const [registrationStatus, setRegistrationStatus] = useState('');

   
   const handleRegistration = async () => {
     try {
       const newUser = {
         Email: email,
         Name: name,
         Surname: surname,
         Password: password,
         Role: 'user' 
       };
       const response = await axios.post('https://localhost:7203/api/User/Register', newUser); 
       if (response.data) {
         setRegistrationStatus('User registered successfully!');
       } else {
         setRegistrationStatus('Registration failed.');
       }
     } catch (error) {
       console.error('API request error:', error);
     }
   };
   return (
     <div>
       <h2>Registration Form</h2>
       <input
         type="email"
         value={email}
         onChange={(e) => setEmail(e.target.value)}
         placeholder="Enter your email"
       />
       <input
         type="text"
         value={name}
         onChange={(e) => setName(e.target.value)}
         placeholder="Enter your name"
       />
       <input
         type="text"
         value={surname}
         onChange={(e) => setSurname(e.target.value)}
         placeholder="Enter your surname"
       />
       <input
         type="password"
         value={password}
         onChange={(e) => setPassword(e.target.value)}
         placeholder="Enter your password"
       />
       <button onClick={handleRegistration}>Register</button>
       <p>{registrationStatus}</p>
     </div>
   );
 };
 export default Register;
