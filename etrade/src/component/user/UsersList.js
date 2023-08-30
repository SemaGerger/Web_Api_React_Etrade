import React, { useState, useEffect } from 'react';
import axios from 'axios';

const UserList = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchUserList();
  }, []);

  const fetchUserList = async () => {
    try {
      const response = await axios.get('https://localhost:7203/api/User/GetUserList');
      setUsers(response.data);
      setLoading(false);
    } catch (error) {
      console.error('API request error:', error);
      setLoading(false);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  if (!users.length) {
    return <div>No users found.</div>;
  }

  return (
    <div>
      <h2>User List</h2>
      <ul>
        {users.map(user => (
          <li key={user.email}>
            <p>Email: {user.email} Name: {user.name} Surname: {user.surname}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default UserList;
